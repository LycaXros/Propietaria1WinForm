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
        private Dictionary<int, CompetenciaViewModel> dC;
        private int _last = 0;
        private int _itemId;
        public frmCRUDCompetencias()
        {
            InitializeComponent();
            dC = new Dictionary<int, CompetenciaViewModel>();
        }


        private void frmCRUDCompetencias_Load(object sender, EventArgs e)
        {
            _itemId = 0;
            dataGridView1.RowHeaderMouseDoubleClick += DataGridView1_RowHeaderMouseDoubleClick;
            this.FormClosing += FrmCRUDCompetencias_FormClosing;

            FillDictionary();
            fillDataGrid();
            // fillEstadoCBX();
            cmdEliminar.Visible = false;



        }

        private void FrmCRUDCompetencias_FormClosing(object sender, FormClosingEventArgs e)
        {
            L_Competencias.Clear();
            L_Competencias.AddRange(dC.Values);
        }

        private void FillDictionary()
        {
            if (dC.Count > 0) dC.Clear();
            int c = 0;
            foreach (var item in L_Competencias)
            {
                dC.Add(++c, item);
            }
            _last = c;
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
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Estado");
            foreach (var item in dC)
            {
                var row = dt.NewRow();
                row[0] = item.Key;
                row[1] = item.Value.Descripcion;
                row[2] = item.Value.Estado;
                dt.Rows.Add(row);

            }

            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.Columns["ID"].Visible = false;
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
                cpt = dC[id];

                cpt.Descripcion = desc;
                cpt.Estado = estado;
            }
            else
            {
                cpt.Descripcion = desc;
                cpt.Estado = estado;
                dC.Add(++_last, cpt);
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
                    var it = dC[_itemId];
                    if (it == null) return;
                    dC.Remove(_itemId);
                    cleanTxt();
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
