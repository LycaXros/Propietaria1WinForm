using Client.SimpleModels;
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

namespace Client.MDIs
{
    public partial class MDI_User : Form
    {
        public static int IdentificadorEmpleado { get; internal set; }
        private RRHHContext Context;
        private readonly EmpleadoDataModel _emp;

        public MDI_User()
        {
            InitializeComponent();
            Context = new RRHHContext();
        }
        public MDI_User(RRHHContext context, EmpleadoDataModel emp)
        {
            InitializeComponent();
            Context = context;
            _emp = emp;
        }

        private void MDI_User_Load(object sender, EventArgs e)
        {
            userData.Text = _emp.ProfileInfo;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void MDI_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void ShowForm(Form frm)
        {
            frm.MdiParent = this;            
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now;

            timerLabel.Text = date.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void reporteNuevosEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new VerReporte() {_db = Context });
        }

        private void competenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ShowForm(new Forms.frmCRUDCompetencias() { context = _context });
        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.frmIdiomas() { _context = Context});
        }

        private void capacitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.frmCapacitaciones() { context = Context });
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.FrmCandidatos() { context = Context });
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.FrmPuestos() { context = Context });
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new Forms.FrmDepartamento() { _context = Context });
        }
    }
}
