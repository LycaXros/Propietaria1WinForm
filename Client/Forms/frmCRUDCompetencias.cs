using Data.Models;
using Data.Utils;
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
    public partial class frmCRUDCompetencias : Form
    {
        RRHHContext context;
        private int _itemId;
        public frmCRUDCompetencias()
        {
            InitializeComponent();
        }
        public frmCRUDCompetencias(
            RRHHContext _context)
        {
            InitializeComponent();
            this.context = _context;
        }


        private void frmCRUDCompetencias_Load(object sender, EventArgs e)
        {
            _itemId = 0;
            dataGridView1.RowHeaderMouseDoubleClick += DataGridView1_RowHeaderMouseDoubleClick;
            fillDataGrid();
           // fillEstadoCBX();


        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            var selectedEstado = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            cbxEstado.SelectedIndex = cbxEstado.Items.IndexOf(selectedEstado);
        }

        private void fillEstadoCBX()
        {
            var list = from Enum e in Enum.GetValues(typeof(EstadoPersistencia))
                       select e.ToString();
            foreach (var item in list)
            {
                cbxEstado.Items.Add(item);
            }
            cbxEstado.SelectedIndex = 0;
        }

        private void fillDataGrid()
        {

            var data = context.Competencias.ToList();
            dataGridView1.DataSource = data;
            dataGridView1.Refresh();
        }

        private void cmdClean_Click(object sender, EventArgs e)
        {
            cleanTxt();
        }

        private void cleanTxt()
        {
            txtId.Text = "0";
            txtDescripcion.Clear();
            cbxEstado.SelectedIndex = 0;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string desc = txtDescripcion.Text;
            string selected = cbxEstado.SelectedItem.ToString();
            EstadoPersistencia estado = EstadoPersistencia.Inactivo;

            estado = EnumUtil.ParseEnum<EstadoPersistencia>(selected);
            Competencias cpt = new Competencias();

            if (id > 0)
            {
                cpt = context.Competencias.Find(id);

                cpt.Descripcion = desc;
                cpt.Estado = estado;
            }
            else
            {
                cpt.Descripcion = desc;
                cpt.Estado = estado;
                context.Competencias.Add(cpt);
            }
            context.SaveChanges();
            cleanTxt();
            fillDataGrid();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if(_itemId==0)
            {
                MessageBox.Show("Seleccione un Item de la Grilla","PELIGRO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (BoxEliminar())
                {
                    var it = context.Competencias.Find(_itemId);
                    if (it == null) return;
                    context.Competencias.Remove(it);
                    context.SaveChanges();
                    fillDataGrid();
                }
            }
        }

        private static bool BoxEliminar()
        {
            return MessageBox.Show("Estas seguro de eliminar el Item", "Eliminando", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            _itemId=int.Parse((sender as TextBox).Text);
        }
    }
}
