using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.DetailForm
{
    public partial class PuestoDetail : Form
    {
        public PuestoViewModel Puesto { get; set; }
        public PuestoDetail()
        {
            InitializeComponent();
        }

        private void PuestoDetail_Load(object sender, EventArgs e)
        {

            panel1.BackColor = Color.FromArgb(62, 179, 122);
            panel2.BackColor = Color.FromArgb(140, 255, 200);
            this.BackColor = Color.FromArgb(114, 255, 188);
            lblNombre.Text = "Nombre: " + Puesto.Nombre;
            lblRiesgo.Text = "Riesgo: " + Puesto.Riesgo;
            lblSalMin.Text = "Salario Minimo: " + Puesto.SalarioMinimo.ToString("RD$ ###,###,###.##");
            lblSalMax.Text = "Salario Maximo: " + Puesto.SalarioMaximo.ToString("RD$ ###,###,###.##");
            var c = Puesto.Competencias.Where(ce=> ce.Estado == Data.Models.EstadoPersistencia.Activo).ToList();
            for (int i = 0; i < c.Count; i++)
            {
                lbxCompetencias.Items.Add($"{i + 1:D3}> {c[i].Descripcion}");
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
