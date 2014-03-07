#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
#endregion

namespace TranslationEditor
{
	/// <summary>
	/// Implements a custom list view subitem that provides support
	/// for displaying custom edit controls and also for dynamic read-only/editable
	/// behavior.
	/// Replaces the base class in the ListViewItem.SubItems collection.
	/// </summary>
	/// <remarks>
	/// Usage: Create an editable or read only subitem and add it to the ListViewItem instance.
	/// Set/unset 
	/// </remarks>
	public class EditableListViewSubItem : ListViewItem.ListViewSubItem, ISelfValidable
	{	
		#region Members
		/// <summary>
		/// The control to be displayed for in-place editing.
		/// </summary>
		private Control editControl = null;
		/// <summary>
		/// Whether the subitem is read only or not.
		/// </summary>
		private bool readOnly = false;
		/// <summary>
		/// Whether the subitem is valid or not. 
		/// Invalid items are drawn in a specific color by the parent list view.
		/// </summary>
		private bool isValid = false;
		/// <summary>
		/// The validator to check the item text against.
		/// </summary>
		private IValidator validator = null;
		/// <summary>
		/// The event that gets fired whenever the IsValid property changes.
		/// </summary>
		public event EventHandler<ValidationEventArgs> IsValidChanged = null;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets whether this subitem is read only or allows editing.
		/// </summary>
		public bool ReadOnly
		{
			get
			{
				return (editControl == null || readOnly);
			}
			set
			{
				readOnly = (editControl == null ? true : value);
				IsValid = (validator == null ? true : validator.Check(Text));
			}
		}

		/// <summary>
		/// Gets or sets whether the subitem text is valid or not.
		/// </summary>
		/// <remarks>The read only items are considered always valid.</remarks>
		public bool IsValid
		{
			get
			{
				return readOnly || isValid;
			}
			set
			{
				isValid = readOnly || value;
				if (IsValidChanged != null)
				{
					IsValidChanged(this, new ValidationEventArgs(isValid));
				}
			}
		}

		/// <summary>
		/// Gets or sets the custom validator that handles the subitem text validation.
		/// </summary>
		/// <remarks>The existing text is auto-validated during set.</remarks>
		public IValidator Validator
		{
			get
			{
				return validator;
			}
			set
			{
				validator = value;
				IsValid = (validator == null ? true : validator.Check(Text));
			}
		}

		/// <summary>
		/// Gets or sets the text of the subitem. When the validation 
		/// handler is specified, it also validates the text to be set and updates
		/// the IsValid flag accordingly.
		/// </summary>
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				IsValid = (validator == null ? true : validator.Check(value));
				base.Text = value;
			}
		}

		/// <summary>
		/// Gets the editable control used for in-place editing.
		/// </summary>
		public Control EditControl
		{
			get
			{
				return editControl;
			}
		}
		#endregion

		#region Methods
        /// <summary>
        /// Forces a validation on demand.
        /// </summary>
        public void Validate()
        {
            IsValid = (validator == null ? true : validator.Check(Text));
        }
		#endregion

		#region Construction
		/// <summary>
		/// Creates a new readonly list view subitem.
		/// </summary>
		/// <param name="owner">The owner of the subitem.</param>
		/// <param name="text">The text to be displayed.</param>
		public EditableListViewSubItem(ListViewItem owner, string text) : 
			base(owner, text)
		{
			readOnly = true;
			IsValid = true;
		}

		/// <summary>
		/// Creates a new editable list view subitem.
		/// </summary>
		/// <param name="editControl">The edit control that pops-up when the 
		/// subitem is clicked. If null, the subitem is made read-only.</param>
		/// <param name="owner">The owner of the subitem.</param>
		/// <param name="text">The text to be displayed.</param>
		public EditableListViewSubItem(Control editControl, 
			ListViewItem owner, string text) : 
			base(owner, text)
		{
			this.editControl = editControl;
			readOnly = (editControl == null);
			IsValid = true;
		}
		#endregion
	}
}
