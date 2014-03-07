
#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
#endregion

namespace TranslationEditor
{
	#region Event Args
	/// <summary>
	/// Implements event arguments wrapper for the SubItemEditing/Edited events.
	/// </summary>
	public class ListViewSubItemEventArgs : HandledEventArgs
	{
		#region Members
		/// <summary>
		/// Reference to the editable control for the subitem.
		/// </summary>
		private Control editableControl = null;
		/// <summary>
		/// The edited subitem.
		/// </summary>
		private ListViewItem.ListViewSubItem editedSubItem = null;
		/// <summary>
		/// The edited item (whose subitem is edited).
		/// </summary>
		private ListViewItem editedItem = null;
		/// <summary>
		/// The edited subitem index (column index).
		/// </summary>
		private int editedSubItemIndex = -1;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the editable control that is used for editing this item.
		/// </summary>
		public Control EditableControl
		{
			get
			{
				return editableControl;
			}
		}

		/// <summary>
		/// Gets the edited subitem.
		/// </summary>
		public ListViewItem.ListViewSubItem SubItem
		{
			get
			{
				return editedSubItem;
			}
		}

		/// <summary>
		/// Gets the edited item.
		/// </summary>
		public ListViewItem Item
		{
			get
			{
				return editedItem;
			}
		}

		/// <summary>
		/// Gets the index of the subitem in the item list 
		/// (the edited column index).
		/// </summary>
		public int SubItemIndex
		{
			get
			{
				return editedSubItemIndex;
			}
		}
		#endregion

		#region Construction
		/// <summary>
		/// Creates an empty new event argument instance.
		/// </summary>
		public ListViewSubItemEventArgs() 
			: base()
		{
		}

		/// <summary>
		/// Creates a new event argument instance.
		/// </summary>
		/// <param name="editableControl">The editable control.</param>
		/// <param name="editedItem">The edited item.</param>
		/// <param name="editedSubItem">The edited subitem.</param>
		/// <param name="editedSubItemIndex">The edited subitem index (the edited
		/// column).</param>
		public ListViewSubItemEventArgs(Control editableControl, ListViewItem editedItem,
			ListViewItem.ListViewSubItem editedSubItem, int editedSubItemIndex)
			: base()
		{
			this.editableControl = editableControl;
			this.editedItem = editedItem;
			this.editedSubItem = editedSubItem;
			this.editedSubItemIndex = editedSubItemIndex;
		}
		#endregion
	}
	#endregion

	/// <summary>
	/// Implements a custom editable list view control.
	/// </summary>
	public class OPMEditableListView : ListView
    {
        //
        // TODO:
        //
        // 1. Add more supported in-place edit controls.
        // 2. Find a way to define and edit the in-place edit controls directly
        //    in the properties of the column headers (in designer).
		//

		#region Delegates
		/// <summary>
		/// Type of delegate used to raise EditableListViewXXX events.
		/// Usually, this will be used to display and handle in-place
		/// edit controls, other than the supported ones.
		/// Use carefully since it is currently under development.
		public delegate void EditableListViewEventHandler(object sender,
			ListViewSubItemEventArgs args);
		#endregion

		#region Members
		/// <summary>
        /// A reference to the active edit control (that is,
        /// the control that is used to edit the list contents 
        /// at a given moment.
        /// </summary>
        private Control activeEditControl = null;
        /// <summary>
        /// The collection of edit controls, represented by column/control pairs.
        /// </summary>
        private Dictionary<int, Control> editControls = new Dictionary<int, Control>();
        /// <summary>
        /// The 0-based index of the edited subitem row.
        /// </summary>
        private int row = -1;
        /// <summary>
        /// The 0-based index of the edited subitem column.
        /// </summary>
        private int column = -1;
        /// <summary>
        /// The method that will be called when raising StartEditing events.
        /// Usually, this will be used to display and handle in-place
        /// edit controls, other than the supported ones.
        /// Use carefully since it is currently under development.
        /// </summary>
        public event EditableListViewEventHandler SubItemEditing = null;
        /// <summary>
        /// The method that will be called when raising EndEditing events.
        /// Usually, this will be used to display and handle in-place
        /// edit controls, other than the supported ones.
        /// Use carefully since it is currently under development.
        /// </summary>
        public event EditableListViewEventHandler SubItemEdited = null;

        public event EditableListViewEventHandler SubItemEndEditing = null;

        #region Win32 Constants
        // Windows Messages (Win32 Legacy programming)
        private const int WM_PAINT = 0x000F;
        #endregion

        #endregion

        #region Properties
        /// <summary>
        /// Gets/sets the grid row height.
        /// Trivia: Grid row height can be manipulated via the size
        /// of the image list associated with the list view.
        /// Hint: Set the row height so as your edit comboboxes can
        /// fit exactly in a grid cell.
        /// </summary>
        public int RowHeight
        {
            get
            {
                return this.SmallImageList.ImageSize.Height;
            }
            set
            {
                ImageList il = new ImageList();
                il.ImageSize = new Size(1, value);
                this.SmallImageList = il;
            }
        }

        /// <summary>
        /// Gets the 0-based index of the edited subitem row.
        /// </summary>
        public int EditedRow
        {
            get
            {
                return row;
            }
        }

        /// <summary>
        /// Gets the 0-based index of the edited subitem column.
        /// </summary>
        public int EditedColumn
        {
            get
            {
                return column;
            }
        }

        /// <summary>
        /// Gets if multiple items selction is allowed for this
        /// list view. For an EditableListView control, it must
        /// be always false.
        /// </summary>
        [ReadOnly(true)]
        public new bool MultiSelect
        {
            get
            {
                return base.MultiSelect;
            }
        }

        /// <summary>
        /// Gets how items are displayed in the control.
        /// For an EditableListView control, it must be always
        /// View.Details, so the property is made read only.
        /// </summary>
        [ReadOnly(true)]
        public new View View
        {
            get
            {
                return base.View;
            }
        }

        /// <summary>
        /// Gets a value indicating whether grid lines appear
        /// between the rows and columns containing the items
        /// and subitems in the control. 
        /// For an EditableListView control, it must be always
        /// true, so the property is made read only.
        /// </summary>
        [ReadOnly(true)]
        public new bool GridLines
        {
            get
            {
                return base.GridLines;
            }
        }

        /// <summary>
        /// Gets a value indicating whether clicking an item
        /// selects all its subitems.  
        /// For an EditableListView control, it must be always
        /// true, so the property is made read only.
        /// </summary>
        [ReadOnly(true)]
        public new bool FullRowSelect
        {
            get
            {
                return base.FullRowSelect;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the selected item
        /// in the control remains highlighted when the control
        /// loses focus. 
        /// For an EditableListView control, it must be always
        /// false, so the property is made read only.
        /// </summary>
        [ReadOnly(true)]
        public new bool HideSelection
        {
            get
            {
                return base.HideSelection;
            }
        }
        #endregion
        
        #region Construction
        /// <summary>
        /// Default contructor. Calls also the base
        /// class contructor to ensure complete
        /// initialization.
        /// </summary>
        public OPMEditableListView() : base()
        {
            // Set properties to their default values
            // for an EditableListView.
            base.View = View.Details;
            base.GridLines = true;
            base.FullRowSelect = true;
            base.HideSelection = false;
            base.MultiSelect = false;

            // Set grid row height equal with default combo box height.
            // With this all "regular" comboboxes should fit exactly
            // in a grid cell.
            this.RowHeight = new ComboBox().Height;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Window procedure. Legacy Win32 programming.
        /// Neither ListView nor its base classes do expose have an
        /// OnScroll event handler. If we want to catch these events,
        /// we must do it in Win32 style. However, the best way to
        /// scroll in-place controls together with the list view is 
        /// to do via WM_PAINT.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            Color nonEditableColor = this.BackColor;
            switch (m.Msg)
            {
                case WM_PAINT:

                    // Set distinctive background for editable fields and also reposition the
					// subitem being edited (if any)
					ListViewItem.ListViewSubItem editedSubItem = null;
					foreach (ListViewItem item in Items)
                    {
                        item.UseItemStyleForSubItems = false;
                        item.BackColor = nonEditableColor;
                        item.ForeColor = Color.FromKnownColor(KnownColor.ControlText);

						int subItemIndex = 0;
						foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
							Control editControl = null;
                            Color editableColor = Color.FromKnownColor(KnownColor.Wheat);
							EditableListViewSubItem editableSubItem =
								subItem as EditableListViewSubItem;
							if (editableSubItem != null)
							{
								if (!editableSubItem.ReadOnly)
								{
									// possibly editable (unless the developer forgot
									// to specify the control)
									editControl = editableSubItem.EditControl;
									if (!editableSubItem.IsValid)
									{
                                        editableColor = Color.Wheat;
									}
								}
							}
							else
							{
								// editable
								editControls.TryGetValue(subItemIndex, out editControl);
							}

                            if (editControl != null)
                            {
                                // editable item
								// see if it's being edited right now
                                subItem.BackColor = editableColor;
								if (item.Index == EditedRow && subItemIndex == EditedColumn)
								{
									editedSubItem = subItem;
								}
                            }
                            else
                            {
                                // non-editable item
                                subItem.BackColor = nonEditableColor;
                            }
							subItemIndex++;
                        }
                    }

                    // Reposition edit control.
					if (editedSubItem != null  && activeEditControl != null)
					{
						DisplayEditControl(true, activeEditControl, editedSubItem);
					}
                    break;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Overrides the default behaviour of the list view when 
        /// an item is clicked with the mouse. This is done in order
        /// to be able to display the edit controls. If no edit control
        /// can be displayed then the default event is raised.
        /// </summary>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            ListViewItem item = this.GetItemAt(e.X, e.Y);
            if (item == null)
                return;

            ListViewItem.ListViewSubItem subItem = 
                item.GetSubItemAt(e.X, e.Y);

            if (subItem == null)
                return;

            row = item.Index;
            column = item.SubItems.IndexOf(subItem);

            StartEditing(item, subItem);
            base.OnMouseClick(e);
        }

        public void StartEditing(int row, int column)
        {
            if (row < 0 || column < 0 ||
                row >= Items.Count || column >= Columns.Count)
                return;
            
            this.row = row;
            this.column = column;

            ListViewItem item = this.Items[row];
            ListViewItem.ListViewSubItem subItem = item.SubItems[column];

            StartEditing(item, subItem);
        }

        /// <summary>
        /// Event handler for the Leave event of the in-place edit control.
        /// This must result in ending the editing action. By design in this
        /// case it is assumed that the user accepts the changes.
        /// </summary>
        private void OnEditorLeave(object sender, EventArgs e)
        {
            if (row < 0 || column < 0)
                return;

            EndEditing(true);
        }

        /// <summary>
        /// Occurs when a key is pressed in the area of the in-place edit control.
        /// </summary>
        /// <param name="sender">The object that has sent the event.</param>
        /// <param name="e">The event argumets.</param>
        private void OnEditorKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = false;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    EndEditing(false);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Enter:
                    EndEditing(true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Methods
        //public void ShowSortGlyph(int lastSortedColumn, int columnToSort, SortOrder order)
        //{
        //    if (this.HeaderStyle == ColumnHeaderStyle.Clickable)
        //    {
        //        IntPtr hHeader = User32.SendMessage(this.Handle,
        //            (int)HeaderItemFlags.LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero); //Get the handle of the ListView header

        //        IntPtr newColumn = new IntPtr(columnToSort);
        //        IntPtr prevColumn = new IntPtr(lastSortedColumn);
        //        HDITEM hdItem;

        //        IntPtr rtn;

        //        if (lastSortedColumn != -1 && lastSortedColumn != columnToSort) //If the last sorted column exists
        //        {
        //            hdItem = new HDITEM();
        //            hdItem.mask = (int)HeaderItemFlags.HDI_FORMAT;
        //            rtn = User32.SendMessage(hHeader, (int)HeaderItemFlags.HDM_GETITEM, prevColumn, ref hdItem);
        //            hdItem.fmt &= ~(int)HeaderItemFlags.HDF_SORTDOWN & ~(int)HeaderItemFlags.HDF_SORTUP;
        //            rtn = User32.SendMessage(hHeader, (int)HeaderItemFlags.HDM_SETITEM, prevColumn, ref hdItem);//Clear the sort glyph
        //        }

        //        hdItem = new HDITEM();
        //        hdItem.mask = (int)HeaderItemFlags.HDI_FORMAT;
        //        rtn = User32.SendMessage(hHeader, (int)HeaderItemFlags.HDM_GETITEM, newColumn, ref hdItem);

        //        hdItem.fmt &= ~(int)HeaderItemFlags.HDF_SORTDOWN & ~(int)HeaderItemFlags.HDF_SORTUP;

        //        int sortFmt = (order == SortOrder.Ascending ? (int)HeaderItemFlags.HDF_SORTUP : (int)HeaderItemFlags.HDF_SORTDOWN);

        //        hdItem.fmt |= sortFmt;

        //        rtn = User32.SendMessage(hHeader, (int)HeaderItemFlags.HDM_SETITEM, newColumn, ref hdItem); //Send message to the column header to show the sort glyph
        //    }
        //}

        /// <summary>
        /// Checks if the specified control is a supported in-place edit
        /// control. Derived classes of a supported in-place edit control 
        /// are also considered a supported in-place edit controls.
        /// </summary>
        /// <param name="editControl">The control that must be checked.</param>
        /// <returns>True if supported, false otherwise.</returns>
        public bool IsSupportedEditControl(Control editControl)
        {
            System.Type inPlaceEditorType = editControl.GetType();

            if (inPlaceEditorType == typeof(TextBox) ||
                inPlaceEditorType == typeof(ComboBox) ||
                inPlaceEditorType == typeof(NumericUpDown) ||
                inPlaceEditorType == typeof(DateTimePicker))
                return true;

            if (inPlaceEditorType.IsSubclassOf(typeof(TextBox)) ||
                inPlaceEditorType.IsSubclassOf(typeof(ComboBox)) ||
                inPlaceEditorType.IsSubclassOf(typeof(NumericUpDown)) ||
                inPlaceEditorType.IsSubclassOf(typeof(DateTimePicker)))
                return true;

            return false;
        }

        /// <summary>
        /// Overloaded. Retrieves the in-place edit control that was assigned
        /// for a given column.
        /// </summary>
        /// <param name="column">The column index.</param>
        /// <returns>The edit control for the specified column.</returns>
        public Control GetEditControl(int column)
        {
            // Check the column bounds.
			Control editControl;
			editControls.TryGetValue(column, out editControl);
            return editControl;
        }

        /// <summary>
        /// Overloaded. Retrieves the in-place edit control that was assigned
        /// for a given column.
        /// </summary>
        /// <param name="columnHeader">The column header.</param>
        /// <returns>The edit control for the specified column.</returns>
        public Control GetEditControl(ColumnHeader columnHeader)
        {
            return GetEditControl(this.Columns.IndexOf(columnHeader));
        }

        /// <summary>
        /// Overloaded. Assigns the in-place edit control for a given column.
        /// Also ensures that the size of the edit controls collection is 
        /// grown automatically if needed. 
        /// CAUTIONS: 
        /// 1. The in-place edit control and the list view must be siblings, 
        /// children of the same UI component, otherwise the SetEditControl
        /// action will be ignored.
        /// 2. The in-place edit control must be a suppeorted edit control 
        /// otherwise the SetEditControl action will be ignored. Use 
        /// IsSupportedEditControl to verify is a specified control is a
        /// supported in-place edit control.
        /// </summary>
        /// <param name="column">The column index.</param>
        /// <param name="editControl">The edit control that must be assigned
        /// for the specified column.
        /// </param>
        public void SetEditControl(int column, Control editControl)
        {
            // Check the in-place edit control is a supported in-place
            // edit control.
            if (!IsSupportedEditControl(editControl))
                return;

            // Check the column bounds.
            if (column < 0 || column >= this.Columns.Count)
                return;

            // Set parent for the in-place edit control.
            if (this != editControl.Parent)
            {
                this.SuspendLayout();
                editControl.Parent = this;
                editControl.Visible = false;
                this.ResumeLayout();
            }

			editControls[column] = editControl;

            editControl.Height = this.RowHeight;
        }

        /// <summary>
        /// Overloaded. Assigns the in-place edit control for a given column.
        /// Also ensures that the size of the edit controls collection is 
        /// grown automatically if needed. 
        /// CAUTIONS: 
        /// 1. The in-place edit control and the list view must be siblings, 
        /// children of the same UI component, otherwise the SetEditControl
        /// action will be ignored.
        /// 2. The in-place edit control must be a suppeorted edit control 
        /// otherwise the SetEditControl action will be ignored. Use 
        /// IsSupportedEditControl to verify is a specified control is a
        /// supported in-place edit control.
        /// </summary>
        /// <param name="columnHeader">The column header.</param>
        /// <param name="editControl">The edit control that must be assigned
        /// for the specified column.
        /// </param>
        public void SetEditControl(ColumnHeader columnHeader, Control editControl)
        {
            SetEditControl(this.Columns.IndexOf(columnHeader), editControl);
        }

        /// <summary>
        /// Overloaded. Unassigns the in-place edit control (if existing) for a given column.
        /// </summary>
        /// <param name="column">The column header.</param>
        public void ResetEditControl(ColumnHeader columnHeader)
        {
            ResetEditControl(this.Columns.IndexOf(columnHeader));
        }

        /// <summary>
        /// Overloaded. Unassigns the in-place edit control (if existing) for a given column.
        /// </summary>
        /// <param name="column">The column index.</param>
        public void ResetEditControl(int column)
        {
            // Check the column bounds.
            if (column < 0 || column >= this.Columns.Count)
                return;

            editControls[column] = null;
        }
        #endregion

        #region Implementation
        bool _restoreKeyPreview = false;

        /// <summary>
        /// Displays the in-place edit control for a given list view subitem.
        /// It is assumed that the in-place edit control was previously created
        /// and assigned to the proper column, by means of the SetEditControl
        /// method.
        /// </summary>
		/// <param name="editedItem">The item to be edited.</param>
		/// <param name="editedSubItem">The subitem to be edited.</param>
        public void StartEditing(ListViewItem editedItem,
			ListViewItem.ListViewSubItem editedSubItem)
        {
            if (row < 0 || column < 0 || editedSubItem == null)
                return;

            // Check if event handler available and if positive, raise the event

			Control editControl;
			editControls.TryGetValue(column, out editControl);
			// Override the editable control in the custom subitem, if such an item is used.
			EditableListViewSubItem customSubItem = editedSubItem as EditableListViewSubItem;
			if (customSubItem != null)
			{
				if (customSubItem.ReadOnly)
				{
					// non-editable item
					return;
				}
				else
				{
					// override the edit control
					editControl = customSubItem.EditControl;
				}
			}

			ListViewSubItemEventArgs args =
				new ListViewSubItemEventArgs(editControl, editedItem, 
				editedSubItem, column);
			if (SubItemEditing != null && editControl != null)
			{
				SubItemEditing(this, args);
			}

			// Check if the event was handled - thus the in-place edit controls
			// displayed.
			if (!args.Handled)
			{
				// Display edit control and also set text.
				DisplayEditControl(false, editControl, editedSubItem);
			}

            Form frm = FindForm();
            if (frm != null && frm.KeyPreview)
            {
                frm.KeyPreview = false;
                _restoreKeyPreview = true;
            }
        }

        /// <summary>
        /// End the in-place editing action. It results in "hiding" the
        /// in-place edit control.
        /// </summary>
        /// <param name="acceptChanges">Set to true to accept the new value,
        /// that is resulting after the editing action.</param>
        private void EndEditing(bool acceptChanges)
        {
            Form frm = FindForm();
            if (frm != null && _restoreKeyPreview)
            {
                frm.KeyPreview = true;
                _restoreKeyPreview = false;
            }

            // Check the row bounds.
            if (row < 0 || row >= this.Items.Count)
                return;
            // Check the column bounds.
            if (column < 0 || column >= this.Columns.Count)
                return;

            if (!activeEditControl.Visible)
                return;

			ListViewItem editedItem = this.Items[row];
			ListViewItem.ListViewSubItem editedSubItem = editedItem.SubItems[column];
            if (acceptChanges)
            {
                // Editing results should be handled differently
                // for each type of supported in-place edit control.
                EditableListViewSubItem customSubItem =
                    editedSubItem as EditableListViewSubItem;
                if (customSubItem != null)
                {
                    customSubItem.Text = activeEditControl.Text;
                }
                else
                {
                    editedSubItem.Text = activeEditControl.Text;
                }

                // Check if event handler available and if positive, raise the event
                if (SubItemEdited != null)
                {

                    ListViewSubItemEventArgs args =
                        new ListViewSubItemEventArgs(activeEditControl, editedItem,
                        editedSubItem, column);
                    SubItemEdited(this, args);

                    // Check if the event was handled - thus the in-place edit controls
                    // displayed.
                    if (args.Handled)
                    {
                        return;
                    }
                }
            }

            if (SubItemEndEditing != null)
            {
                ListViewSubItemEventArgs args =
                       new ListViewSubItemEventArgs(activeEditControl, editedItem,
                       editedSubItem, column);
                SubItemEndEditing(this, args);
            }

            // Nothing is edited right now.
            row = column = -1;

            // Disable the control and make it invisible ("hide" it).
			//>>>> FIXUP for nasty bug
			// for some strange reason (which we don't have time to investigate)
			// the SubItemEdited event fucks up the activeEditControl of the list.
			// So we put an extra protection here to prevent exceptions popping up
			if (activeEditControl != null)
			{
				activeEditControl.Hide();
				activeEditControl.Enabled = false;
				activeEditControl.BringToFront();
				// Unsubscribe for the event handlers.
				activeEditControl.Leave -= new EventHandler(OnEditorLeave);
				activeEditControl.KeyDown -= new KeyEventHandler(OnEditorKeyDown);

				// Set activeEditControl as null
				activeEditControl = null;
			}
            // Focus back to the list.
            Focus();
        }

        /// <summary>
        /// Displays the proper in-place edit control.
        /// </summary>
		/// <param name="positioningOnly">Indicates that we only require repositioning the 
		/// given edit control in the current row/column.</param>
		/// <param name="editControl">The edit control to display/reposition.</param>
		/// <param name="editedSubItem">The subitem being edited (to display
		/// the edit control for).</param>
        private void DisplayEditControl(bool positioningOnly, Control editControl,
			ListViewItem.ListViewSubItem editedSubItem)
        {
			// see if the subitem is a customized one
			activeEditControl = editControl;
			if (activeEditControl == null)
			{
				// non-editable column
				return;
			}

            // Set the bounding rectangle for the in-place edit control
            // Check if edit control is overlayed on column header.
            if (editedSubItem.Bounds.Location.Y + ClientSize.Height >= Height - 3)
            {
                int origHeight = activeEditControl.Height;

                // Not overlayed, so display the edit control.
                activeEditControl.Bounds = editedSubItem.Bounds;
                activeEditControl.Height = origHeight;
                
            }
            else
            {
                // Overlayed, so control must be hidden.
                // Caution, Setting visible to false will trigger OnLeave event.
                // So the "hiding" control must be done by means of resizing.
                activeEditControl.Bounds = new Rectangle(0, 0, 0, 0);
            }

            // Enable the control
            activeEditControl.Visible = true;
            activeEditControl.Enabled = true;

            // If the control had only to be repositined, return.
            if (positioningOnly)
                return;

            // Subscribe for the event handlers.
            activeEditControl.Leave += new EventHandler(OnEditorLeave);
            activeEditControl.KeyDown += new KeyEventHandler(OnEditorKeyDown);

            // Set the focus on the control.
            activeEditControl.Focus();

            // Finally also display the text
            DisplayEditControlText(editedSubItem.Text);
        }

        /// <summary>
        /// Sets the text to be displayed in the edit control.
        /// Depending on the type of the edit control, this sometimes can be
        /// done in various ways.
        /// </summary>
        /// <param name="text">The text to display.</param>
        private void DisplayEditControlText(string text)
        {
            try
            {
                TextBox tbInPlaceEditor = activeEditControl as TextBox;
                if (tbInPlaceEditor != null)
                {
                    // In-place edit control is a TextBox
                    tbInPlaceEditor.Text = text;
                    tbInPlaceEditor.SelectAll();
                    return;
                }

                ComboBox comboInPlaceEditor = activeEditControl as ComboBox;
                if (comboInPlaceEditor != null)
                {
                    // In-place edit control is a ComboBox
                    comboInPlaceEditor.Text = text;
                    return;
                }

                DateTimePicker dtp = activeEditControl as DateTimePicker;
                if (dtp != null)
                {
                    DateTimeConverter dtc = new DateTimeConverter();
                    dtp.Value = (DateTime)dtc.ConvertFromInvariantString(text);
                    return;
                }

                NumericUpDown nud = activeEditControl as NumericUpDown;
                if (nud != null)
                {
                    DecimalConverter dc = new DecimalConverter();
                    nud.Value = (decimal)dc.ConvertFromInvariantString(text);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}

