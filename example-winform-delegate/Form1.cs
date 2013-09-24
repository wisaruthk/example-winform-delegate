using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        delegate void TextBoxDelegate(string message);
        delegate void ProgressBarDelegate(int percentage);

        public Form1()
        {
            InitializeComponent();
            Form2 f2 = new Form2(this);
            f2.MdiParent = this;
            f2.Show();
        }

        public void updateText(string text)
        {
            if (this.statusStrip1.InvokeRequired)
            {
                this.statusStrip1.Invoke(new TextBoxDelegate(updateText), new object[] { text });
            }
            else
            {
                this.toolStripStatusLabel1.Text = text;
            }
        }

        public void updateProgressbar(int percentage)
        {
            if (this.statusStrip1.InvokeRequired)
            {
                this.statusStrip1.Invoke(new ProgressBarDelegate(updateProgressbar), new object[] { percentage });

            }
            else
            {
                this.toolStripProgressBar1.Value = percentage;
            }
        }
    }
}
