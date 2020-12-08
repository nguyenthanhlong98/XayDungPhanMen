using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmFlashScreen : Form
    {
        public frmFlashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int percentage = 0;
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 20;
                percentage = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                lblProgressbar.Text = percentage.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void frmFlashScreen_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; //The time per tick
            progressBar1.Value = 0;
            timer1.Start();
        }
    }
}
