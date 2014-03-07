using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPMedia.Core.Utilities;

namespace OPMedia.UI.Controls
{
    public class MultilineEditTextBox : TextBox
    {
        public string MultiLineText
        {
            get
            {
                return StringUtils.FromStringArray(this.Lines, this.MultiLineTextSeparator);
            }

            set
            {
                base.Lines = StringUtils.ToStringArray(value, MultiLineTextSeparator);
            }
        }

        public char MultiLineTextSeparator { get; set; }

        public MultilineEditTextBox()
            : base()
        {
            this.MultiLineText = "";
            this.MultiLineTextSeparator = ';';
        }
    }
}
