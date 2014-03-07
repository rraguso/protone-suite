using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TranslationEditor
{
    public partial class FindDialog : Form
    {
        public string TextToFind
        {
            get
            {
                return textBox1.Text;
            }
        }

        public FindDialog()
        {
            InitializeComponent();
        }
    }
}
