using Client.SimpleModels;
using Client.ViewModels;
using Data.Models;
using Mapster;
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
    public partial class FrmPuestos : Form
    {
        private PuestoViewModel workingPuestoDef;
        private bool editingPuesto;

        public RRHHContext context { get; set; }
        
        public FrmPuestos()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(198, 232, 88);
            this.panel1.BackColor = Color.FromArgb(255, 251, 109);
            dgvResultados.RowHeaderMouseDoubleClick += DgvResultados_RowHeaderMouseDoubleClick; ;
        }

        private void DgvResultados_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dgvResultados.Rows[e.RowIndex];

            int id = int.Parse(row.Cells["ID"].Value.ToString());
            Puestos dd = context.Puestos.FirstOrDefault(x => x.Id == id);

            if (dd == null) return;

            workingPuestoDef = dd.Adapt<PuestoViewModel>();
            var frm = new WorkForms.workPuesto() { Editing = true, DepList = GetDepartamentos() };
            editingPuesto = true;
            frm.PuestoD = workingPuestoDef;
            frm.DeletingPuestoEvent += DeletePuesto;
            frm.SavePuestoEvent += Frm_SavePuestoEvent;
            frm.ShowDialog();
            frm.DeletingPuestoEvent -= DeletePuesto;
            frm.SavePuestoEvent -= Frm_SavePuestoEvent;
            frm.Dispose();
        }




        private void FrmPuestos_Load(object sender, EventArgs e)
        {
            SearchData();
        }
        private void SearchData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Riesgo");
                dt.Columns.Add("Salario Minimo");
                dt.Columns.Add("Salario Maximo");
                dt.Columns.Add("Departamento");
                dt.Columns.Add("Cantidad Aspirantes");
                dt.Columns.Add("Cantidad Competencias");
                dt.Columns.Add("Estado");
                dt.Columns.Add("Disponibilidad");
                dt.Columns.Add("ID");
                var query = context.Puestos
                    .Include("Aspirantes")
                    .Include("Departamento")
                    .AsQueryable();

                string dato = txtNombre.Text.Trim().ToLower();
                query = query.Where(x => x.Nombre.ToLower().Contains(dato));

                var data = query.ToList();
                foreach (var item in data)
                {
                    var row = dt.NewRow();
                    row[0] = item.Nombre;
                    row[1] = item.Riesgo;
                    row[2] = item.SalarioMinimo.ToString("RD$ ###,###,###.##");
                    row[3] = item.SalarioMaximo.ToString("RD$ ###,###,###.##");
                    row[4] = item.Departamento.Nombre;
                    row[5] = item.Aspirantes.Count;
                    row[6] = item.Competencias.Count;
                    row[7] = item.Estado.ToString();
                    row[8] = item.IsAvailable ? "Disponible" : "No Disponible";
                    row["ID"] = item.Id;
                    dt.Rows.Add(row);
                }
                dgvResultados.DataSource = dt;
                dgvResultados.Refresh();
                dgvResultados.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //throw ex;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            workingPuestoDef = new PuestoViewModel();
            editingPuesto = false;
            var frm = new WorkForms.workPuesto() { DepList = GetDepartamentos(), Editing = false };
            frm.PuestoD = workingPuestoDef;
            frm.SavePuestoEvent += Frm_SavePuestoEvent;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void Frm_SavePuestoEvent(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                (sender as WorkForms.workPuesto).Close();
                SearchData();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo Guardar", "Error");
            }
        }

        private void SaveData()
        {
            if (editingPuesto)
            {
                var item = context.Puestos.FirstOrDefault(x => x.Id == workingPuestoDef.Id);
                item.Nombre = workingPuestoDef.Nombre;
                item.Riesgo = workingPuestoDef.Riesgo;
                item.SalarioMinimo= workingPuestoDef.SalarioMinimo;
                item.SalarioMaximo= workingPuestoDef.SalarioMaximo;
                item.DepartamentoID = workingPuestoDef.DepartamentoID;
                item.Estado = workingPuestoDef.Estado;
                item.IsAvailable = workingPuestoDef.IsAvailable;
                item.Competencias = workingPuestoDef.Competencias.Adapt<IList<Competencias>>();
            }
            else
            {
                var item = workingPuestoDef.Adapt<Puestos>();
                item.IsAvailable = true;
                context.Puestos.Add(item);                
            }
            context.SaveChanges();
            MessageBox.Show("SUCCESS!!!!");
        }
        private void DeletePuesto(object sender, EventArgs e)
        {
            try
            {
                var item = context.Puestos.Find(workingPuestoDef.Id);
                context.Puestos.Remove(item);
                context.SaveChanges();

                MessageBox.Show("Registro Eliminado");
                (sender as WorkForms.workPuesto).Close();
                SearchData();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo Eliminar el Registro", "Error");
            }
        }

        private List<SimpleModel> GetDepartamentos()
        {
            try
            {
                var d = context.Departamentos
                    .Where(x => x.Estado == EstadoPersistencia.Activo)
                    .Select(x => new SimpleModel
                    {
                        Id = x.Id,
                        Nombre = x.Nombre
                    }).ToList();
                return d;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo Generar lista de Departamentos");
            }
            return new List<SimpleModel>();
        }
    }
}
