using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdmLCI
{
    public partial class mostrarlista : Form
    {
        public mostrarlista(List<String> list)
        {
            list.Reverse();
            InitializeComponent();
            for (int i = 0; i < list.Count; i++)
            {
                richTextBox1.Text = list[i] + "\n" + richTextBox1.Text;

            }
        }

        
    }
}
