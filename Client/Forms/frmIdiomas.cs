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
        public frmIdiomas()
        {
            InitializeComponent();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

        }

        private void frmIdiomas_Load(object sender, EventArgs e)
        {
            _itemId = 0;
            dgvIdiomas.RowHeaderMouseDoubleClick += DgvIdiomas_RowHeaderMouseDoubleClick;
            dgvIdiomas.Columns.AddRange(
                new DataGridViewColumn{},
                new DataGridViewColumn()
                );
        }

        private void DgvIdiomas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvIdiomas.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvIdiomas.Rows[e.RowIndex].Cells[1].Value.ToString();
            var selectedItem = dgvIdiomas.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbxGrado.SelectedIndex = cbxGrado.Items.IndexOf(selectedItem);

        }
    }
}
