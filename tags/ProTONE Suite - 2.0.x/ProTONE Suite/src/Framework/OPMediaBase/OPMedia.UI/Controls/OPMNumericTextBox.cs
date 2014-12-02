#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using OPMedia.UI.Controls;
#endregion

namespace OPMedia.UI.Controls
{
    #region Enums
    /// <summary>
    /// Defines the numbering bases.
    /// </summary>
    public enum NumberingBase
    {
        /// <summary>
        /// Base 2 (Binar).
        /// </summary>
        Base2,
        /// <summary>
        /// Base 8 (Octal).
        /// </summary>
        Base8,
        /// <summary>
        /// Base 10 (Decimal).
        /// </summary>
        Base10,
        /// <summary>
        /// base 12 (Used for station numbers).
        /// </summary>
        Base12,
        /// <summary>
        /// Base 16 (Hexadecimal).
        /// </summary>
        Base16
    }
    #endregion

    /// <summary>
    /// Implements a text box that only accepts numbers as input.
    /// Only 2, 8, 10, 12 and 16 are supported as numbering bases.
    /// </summary>
    public class OPMNumericTextBox : OPMTextBox
    {
        #region Members
        /// <summary>
        /// The numbering base that is allowed for this control.
        /// </summary>
        private NumberingBase numBase;
        #endregion

        #region Properties
        /// <summary>
        /// Gets/sets the numbering base that is allowed for this control.
        /// </summary>
        public NumberingBase NumBase
        {
            get
            {
                return numBase;
            }

            set
            {
                numBase = value;
            }
        }
        #endregion

        #region Construction
        /// <summary>
        /// Parameter-based constructor that allows specifying the
        /// numbering base.
        /// </summary>
        /// <param name="numBase">The numbering base.</param>
        public OPMNumericTextBox(NumberingBase numBase) : base()
        {
            // Set the numbering base to the specified value.
            this.numBase = numBase;
            // Auto convert to uppercase.
            this.CharacterCasing = CharacterCasing.Upper;
            this.MaxLength = 5;

            // Add event handler to filter the input.
            txtField.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        /// <summary>
        /// Standard constructor. Calls the parameter-based constructor
        /// to specify the default numbering base = base 10.
        /// </summary>
        public OPMNumericTextBox() : this(NumberingBase.Base10)
        {
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Occurs whenever the user presses a key .
        /// </summary>
        /// <param name="sender">The text box object.</param>
        /// <param name="e">The key down event data.</param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Delete:
                case Keys.Left:
                case Keys.Right:
                case Keys.End:
                case Keys.Home:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.D0:
                case Keys.D1:
                    // These keys are valid no matter of the numbering base.
                    e.SuppressKeyPress = e.Shift;
                    break;
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                    // These keys are valid only in base 8 and higher.
                    // Do not allow SHIFT pressed and get chars like: !@#$%^&*()
                    e.SuppressKeyPress = (e.Shift) || (numBase < NumberingBase.Base8);
                    break;
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.D8:
                case Keys.D9:
                    // These keys are valid only in base 10 and higher.
                    // Do not allow SHIFT pressed and get chars like: !@#$%^&*()
                    e.SuppressKeyPress = (e.Shift) || (numBase < NumberingBase.Base10);
                    break;
                case Keys.A:
                case Keys.B:
                    // These keys are valid only in base 12 and higher.
                    // SHIFT can be pressed for these keys.
                    e.SuppressKeyPress = (numBase < NumberingBase.Base12);
                    break;
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                    // These keys are valid only in base 16.
                    // SHIFT can be pressed for these keys.
                    e.SuppressKeyPress = (numBase < NumberingBase.Base16);
                    break;
                default:
                    // Other keys are not valid.
                    e.SuppressKeyPress = true;
                    break;
            }
        }
        #endregion
    }
}
