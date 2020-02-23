using Client.Utils;
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
    public partial class FrmDepartamento : Form
    {
        private int _itemId;
        public RRHHContext _context { get; internal set; }
        public FrmDepartamento()
        {
            InitializeComponent();
            cmdEliminar.Visible = false;
            txtId.TextChanged += TxtId_TextChanged;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Favor de Llenar campo de Nombre");
                txtNombre.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(cbxEstado.Text))
            {
                MessageBox.Show("Favor de seleccionar un Estado");
                cbxEstado.Focus();
                return;
            }
            int id = int.Parse(txtId.Text);
            string nom = txtNombre.Text;
            string selected = cbxEstado.SelectedItem.ToString();
            EstadoPersistencia estado = EstadoPersistencia.Inactivo;

            estado = EnumUtil.ParseEnum<EstadoPersistencia>(selected);
            Departamentos cpt = new Departamentos();

            if (id > 0)
            {
                cpt = _context.Departamentos.Find(id);
                cpt.Nombre = nom;
                cpt.Estado = estado;
            }
            else
            {
                cpt.Nombre = nom;
                cpt.Estado = estado;
                _context.Departamentos.Add(cpt);
            }
            _context.SaveChanges();
            cleanTxt();
            RefreshData();
        }
        private void cleanTxt()
        {
            cmdEliminar.Visible = false;
            txtId.Text = "0";
            txtNombre.Clear();
            cbxEstado.SelectedIndex = 0;
            txtNombre.Focus();
        }
        private void RefreshData()
        {
            var l = _context.Departamentos.ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Estado");
            foreach (var item in l)
            {
                var r = dt.NewRow();
                r[0] = item.Id;
                r[1] = item.Nombre;
                r[2] = item.Estado.ToString();
                dt.Rows.Add(r);
            }
            dgvDepartamento.DataSource = dt;
            dgvDepartamento.Refresh();
            dgvDepartamento.Columns["Id"].Visible = false;
            
        }

        private void FrmDepartamento_Load(object sender, EventArgs e)
        {
            cmdEliminar.Visible = false;
            _itemId = 0;
            dgvDepartamento.RowHeaderMouseDoubleClick += DgvDepartamento_RowHeaderMouseDoubleClick; ;
            this.RefreshData();
        }

        private void DgvDepartamento_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvDepartamento.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvDepartamento.Rows[e.RowIndex].Cells[1].Value.ToString();
            var selectedItem = dgvDepartamento.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbxEstado.SelectedIndex = cbxEstado.FindString(selectedItem);
            cmdEliminar.Visible = true;


        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {

            if (MessageUtils.BoxEliminar())
            {
                var it = _context.Departamentos.Find(_itemId);
                if (it == null) return;
                _context.Departamentos.Remove(it);
                RefreshData();
            }
        }
        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            _itemId = int.Parse((sender as TextBox).Text);
        }

        private void cmdClean_Click(object sender, EventArgs e)
        {
            cleanTxt();
        }
    }
}
