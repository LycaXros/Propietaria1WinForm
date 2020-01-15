using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.MDIs
{
    public partial class MDI_User : Form
    {
        public MDI_User()
        {
            InitializeComponent();
        }

        private void MDI_User_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void MDI_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToLocalTime().ToString();

            timerLabel.Text = date;
        }

    }
}
