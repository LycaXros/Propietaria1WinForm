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

namespace Client.WorkForms
{
    public partial class workCandidatos : Form
    {
        public Candidatos Candidato { get; internal set; }
        public RRHHContext Context { get; internal set; }
        public workCandidatos()
        {
            InitializeComponent();

        }

        private void workCandidatos_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(153, 88, 61);
            panel3.BackColor = Color.FromArgb(232, 69, 67);
            this.BackColor = Color.FromArgb(181, 78, 34);
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            CheckData();
        }

        private void CheckData()
        {
            Candidato.Nombre = txtNombre.Text;

        }

        private void cbxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PID = (int)cbxPuesto.SelectedValue;
            Candidato.PuestoId = PID;

            string dep = Context.Puestos.Include("Departammento").FirstOrDefault(x => x.Id == PID).Departamento.Nombre ?? null;
            if (dep != null)
            {
                txtDepartamento.Text = dep;
                Candidato.Departamento = dep;
            }
        }
    }
}
