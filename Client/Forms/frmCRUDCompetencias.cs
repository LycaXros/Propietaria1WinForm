using Client.Utils;
using Client.ViewModels;
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
        public List<CompetenciaViewModel> L_Competencias { get; set; }
        private int _itemId;
        public frmCRUDCompetencias()
        {
            InitializeComponent();
        }


        private void frmCRUDCompetencias_Load(object sender, EventArgs e)
        {
            _itemId = 0;
            dataGridView1.RowHeaderMouseDoubleClick += DataGridView1_RowHeaderMouseDoubleClick;
            fillDataGrid();
            // fillEstadoCBX();
            cmdEliminar.Visible = false;


        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            var selectedEstado = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            cbxEstado.SelectedIndex = cbxEstado.Items.IndexOf(selectedEstado);
            cmdEliminar.Visible = true;
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
            dataGridView1.DataSource = L_Competencias;
            dataGridView1.Refresh();
        }

        private void cmdClean_Click(object sender, EventArgs e)
        {
            cmdEliminar.Visible = false;
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
            CompetenciaViewModel cpt = new CompetenciaViewModel();

            if (id > 0)
            {
                cpt = L_Competencias.Find(x=> x.Id ==id);

                cpt.Descripcion = desc;
                cpt.Estado = estado;
            }
            else
            {
                cpt.Descripcion = desc;
                cpt.Estado = estado;
                L_Competencias.Add(cpt);
            }
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
                if (MessageUtils.BoxEliminar())
                {
                    var it = L_Competencias.Find(x=> x.Id== _itemId);
                    if (it == null) return;
                    L_Competencias.Remove(it);
                    fillDataGrid();
                }
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            _itemId=int.Parse((sender as TextBox).Text);
        }
    }
}
