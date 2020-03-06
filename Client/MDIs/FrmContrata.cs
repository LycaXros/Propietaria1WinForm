using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utils;
using Data.Models;

namespace Client.MDIs
{
    public partial class FrmContrata : Form
    {
        private double SalarioOptimo;
        private List<Candidatos> ListaCandidatos;

        public FrmContrata()
        {
            InitializeComponent();
            panel1.BackColor = Color.AliceBlue;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            string info =
                $"[Candidato: {row.Cells["Nombre"].Value.ToString()}] \n" +
                $"[Puesto: {row.Cells["Puesto"].Value.ToString()}]";

            if(MessageBox.Show($"Contratar a:\n{info}", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Contrata(row.Cells["Cedula"].Value.ToString());
            }
        }

        private void Contrata(string cedula)
        {
            try
            {
                var c = Context.Candidatos.Include("PuestoAspira").FirstOrDefault(x=> x.Cedula == cedula);

                if (c == null) throw new NotFoundException("No se encontro Candidato");

                c.PuestoAspira.Estado = EstadoPersistencia.Inactivo;
                Context.Empleados.Add(new Empleados {
                    Cedula = c.Cedula,
                    Departamento = c.Departamento,
                    Estado = EstadoPersistencia.Activo,
                    FechaIngreso = DateTime.Now,
                    Nombre = c.Nombre,
                    PuestoId = c.PuestoId,
                    Salario = SalarioOptimo
                });
                MessageBox.Show("Contratado");
                FillCheckBoxList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        public RRHHContext Context { get; internal set; }

        private void FrmContrata_Load(object sender, EventArgs e)
        {
            FillCheckBoxList();
        }

        private void FillCheckBoxList()
        {
            ListaCandidatos = Context.Candidatos
                .Include("PuestoAspira")
                .Where(x => x.PuestoAspira.Estado == EstadoPersistencia.Activo)
                .OrderBy(x => x.PuestoId)
                .ToList();

            DataTable tb = new DataTable();
            tb.Columns.Add("Nombre");
            tb.Columns.Add("Cedula");
            tb.Columns.Add("Puesto");


            foreach (var item in l)
            {
                var row = tb.NewRow();

                row[0] = item.Nombre;
                row[1] = item.Cedula;
                row[2] = item.PuestoAspira.Nombre;

                tb.Rows.Add(row);
            }

            dataGridView1.DataSource = tb;
            dataGridView1.Refresh();
        }
    }
}
