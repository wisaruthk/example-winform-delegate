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
    public partial class Form2 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        private Form1 form1;
        public Form2()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.WorkerReportsProgress = true;
        }

        public Form2(Form1 form1):this()
        {
            this.form1 = form1;
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label1.Text = e.ProgressPercentage.ToString() ;
            form1.updateText(e.ProgressPercentage.ToString());
            form1.updateProgressbar(e.ProgressPercentage);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("running " + i);
                Thread.Sleep(1000);
                bw.ReportProgress(i);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
