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
    public partial class FrmCandidatos : Form
    {
        public RRHHContext context { get; set; }
        public FrmCandidatos()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(255, 160, 71);
            this.panel1.BackColor = Color.FromArgb(153, 139, 104);
            dgvResultados.CellMouseDoubleClick += DgvResultados_CellMouseDoubleClick;
        }

        private void DgvResultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var frm = new WorkForms.workCandidatos() { Context = context }; 
            frm.Text += ": Editar";
            frm.ShowDialog();
        }

        private void FrmCandidatos_Load(object sender, EventArgs e)
        {
            SearchData();
        }

        private void SearchData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Cedula");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Puesto");
                dt.Columns.Add("Departamento");
                dt.Columns.Add("Cantidad Competencias");
                dt.Columns.Add("Cantidad Capacitaciones");
                dt.Columns.Add("Cantidad Experiencias");
                dt.Columns.Add("Recomendado Por");

                var query = context.Candidatos
                    .Include("Competencias")
                    .Include("Capacitaciones")
                    .Include("ExperienciaLaborales")
                    .Include("RecomendadoPor")
                    .AsQueryable();

                if (!string.IsNullOrEmpty(cbxCriterio.SelectedText) && !string.IsNullOrEmpty(txtValorABuscar.Text))
                {
                    var criterio = cbxCriterio.SelectedText.Substring(0, 1);
                    string dato = txtValorABuscar.Text.Trim();
                    switch (criterio)
                    {
                        case "C":
                            query = query.Where(x => x.Cedula.Contains(dato));
                            break;
                        case "N":
                            query = query.Where(x => x.Nombre.Contains(dato));
                            break;
                        case "P":
                            query = query.Where(x => x.PuestoAspira.Nombre.Contains(dato));
                            break;
                        case "D":
                            query = query.Where(x => x.Departamento.Contains(dato));
                            break;
                        default: break;
                    }
                }

                var data = query.ToList();
                foreach (var item in data)
                {
                    var row = dt.NewRow();
                    row[0] = item.Cedula;
                    row[1] = item.Nombre;
                    row[2] = item.PuestoAspira.Nombre;
                    row[3] = item.Departamento;
                    row[4] = item.Competencias.Count;
                    row[5] = item.Capacitaciones.Count;
                    row[6] = item.ExperienciaLaborales.Count;
                    row[7] = $"{item.RecomendadoPor.Nombre} ({item.RecomendadoPor.Cedula})";
                    dt.Rows.Add(row);
                }
                dgvResultados.DataSource = dt;
                dgvResultados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //throw ex;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            var frm = new WorkForms.workCandidatos() { Context = context};
            frm.Text += ": Nuevo";
            frm.ShowDialog();
        }
    }
}
