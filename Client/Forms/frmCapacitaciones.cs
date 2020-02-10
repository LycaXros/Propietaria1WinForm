using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class frmCapacitaciones : Form
    {
        public frmCapacitaciones()
        {
            InitializeComponent();
        }

        public RRHHContext context { get; internal set; }

        private void frmCapacitaciones_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(52, 128, 86);
        }

        private void frmCapacitaciones_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var l = context.Capacitaciones.ToList();



            dgvCapacitaciones.DataSource = l;
            dgvCapacitaciones.Refresh();
        }
    }
}
