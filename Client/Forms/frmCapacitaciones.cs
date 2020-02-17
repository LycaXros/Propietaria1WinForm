using Client.WorkForms;
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
        public List<Capacitaciones> Capacitaciones { get; set; }
        public RRHHContext context { get; internal set; }
        public string Cedula { get; internal set; }

        public frmCapacitaciones()
        {
            InitializeComponent();
            dgvCapacitaciones.CellMouseDoubleClick += DgvCapacitaciones_CellMouseDoubleClick;
        }

        private void DgvCapacitaciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dgvCapacitaciones.Rows[e.RowIndex].Cells[0].Value.ToString());
            var frm = new workCapacitaciones() { Editing = true, cap = Capacitaciones[id], context = context, CedulaCandidato =  Cedula};
            frm.StartPosition = FormStartPosition.CenterScreen;            
            frm.ShowDialog();

        }

        private void frmCapacitaciones_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(52, 128, 86);
            RefreshData();
        }

        private void frmCapacitaciones_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
           // var l = context.Capacitaciones.ToList();



            dgvCapacitaciones.DataSource = Capacitaciones;
            dgvCapacitaciones.Refresh();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            var frm = new workCapacitaciones() { context = context };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Editing = false;
            frm.ShowDialog();
        }
    }
}
