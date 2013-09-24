using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        private Form1 form1;

        public Form3()
        {
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                form1.updateText("form3 "+i.ToString());
                Thread.Sleep(1000);
                bw.ReportProgress(i);
            }
        }

        public Form3(Form1 form1):this()
        {
            // TODO: Complete member initialization
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bw.RunWorkerAsync();
        }
    }
}
