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
    public partial class frmIdiomas : Form
    {
        private int _itemId;
        public RRHHContext _context { get; internal set; }
        public frmIdiomas()
        {
            InitializeComponent();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtId.Text);
            string nom = txtNombre.Text;
            string selected = cbxEstado.SelectedItem.ToString();
            string gradop = cbxGrado.SelectedText;
            EstadoPersistencia estado = EstadoPersistencia.Inactivo;

            estado = EnumUtil.ParseEnum<EstadoPersistencia>(selected);
            Idiomas cpt = new Idiomas();

            if (id > 0)
            {
                cpt = _context.Idiomas.Find(id);
                cpt.Grado = gradop;
                cpt.Nombre = nom;
                cpt.Estado = estado;
            }
            else
            {
                cpt.Grado = gradop;
                cpt.Nombre = nom;
                cpt.Estado = estado;
                _context.Idiomas.Add(cpt);
            }
            _context.SaveChanges();
            cleanTxt();
            RefreshData();
        }

        private void frmIdiomas_Load(object sender, EventArgs e)
        {
            cmdEliminar.Visible = false;
            _itemId = 0;
            dgvIdiomas.RowHeaderMouseDoubleClick += DgvIdiomas_RowHeaderMouseDoubleClick;
            this.RefreshData();
        }

        private void DgvIdiomas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvIdiomas.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvIdiomas.Rows[e.RowIndex].Cells[1].Value.ToString();
            var selectedItem = dgvIdiomas.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbxGrado.SelectedIndex = cbxGrado.Items.IndexOf(selectedItem);
            cmdEliminar.Visible = true;

        }

        private void RefreshData()
        {
            var l = _context.Idiomas.ToList();

            dgvIdiomas.DataSource = l;
            dgvIdiomas.Refresh();
        }

        private void cleanTxt()
        {
            cmdEliminar.Visible = false;
            txtId.Text = "0";
            txtNombre.Clear();
            cbxEstado.SelectedIndex = 0;
            cbxGrado.SelectedIndex = 0;
        }

        private void cmdClean_Click(object sender, EventArgs e)
        {
            cleanTxt();
        }
    }
}
