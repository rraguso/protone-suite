using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TranslationEditor.EditableListView
{
    public class YesNoComboBox : ComboBox
    {
        public new bool SelectedValue
        {
            get
            {
                return (Text.ToUpperInvariant() == "YES");
            }
        }

        public YesNoComboBox()
            : base()
        {
            Items.Add("NO");
            Items.Add("YES");

            this.FlatStyle = FlatStyle.Popup;
        }
    }

}
