using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Models;

namespace Client.Forms
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        public RRHHContext Context { get; internal set; }
        public List<Empleados> Listado { get; private set; }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                if (Listado == null || Listado.Count <= 0)
                {
                    Listado = Context.Empleados
                        .Include("LoginData")
                        .Include("Puesto")
                        .Where(x => x.PuestoId.HasValue)
                        .ToList();
                }

                var l = Listado.Where(x => x.Nombre.Contains(txtValorABuscar.Text.Trim())).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Cedula");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Fecha Ingreso");
                dt.Columns.Add("Departamento");
                dt.Columns.Add("Puesto");
                dt.Columns.Add("Salario");
                dt.Columns.Add("ID");


                foreach (var item in l)
                {
                    var row = dt.NewRow();
                    row[0] = item.Cedula;
                    row[1] = item.Nombre;
                    row[2] = item.FechaIngreso.ToLongDateString();
                    row[3] = item.Departamento;
                    row[4] = item.Puesto.Nombre;
                    row[5] = item.Salario.ToString("RD$ ###,###,###.##") ;
                    row["ID"] = item.Id;
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
