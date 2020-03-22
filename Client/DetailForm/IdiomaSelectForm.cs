using Client.ViewModels;
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

namespace Client.DetailForm
{
    public partial class IdiomaSelectForm : Form
    {
        public List<IdiomaViewModel> Idiomas { get; set; }

        public event EventHandler DeletingExpEvent;
        public bool Editing { get; set; }
        public IdiomaViewModel Idioma { get; internal set; }
        public bool SaveData { get; internal set; }

        public IdiomaSelectForm()
        {
            InitializeComponent();
            btnRemove.Enabled = false;
            btnRemove.Click += removeClick;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            Idioma = Idiomas.FirstOrDefault(x => x.Id == id) ?? null;
            LabelText();
        }

        private void removeClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar este Idioma", "Eliminar", buttons: MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {

            }
        }

        private void IdiomaSelectForm_Load(object sender, EventArgs e)
        {
            FillData();

            LabelText();

        }

        private void LabelText()
        {
            label1.Text = $"Nombre: {Idioma.Nombre}";
            label2.Text = $"Grado: {Idioma.Grado}";
        }

        private void FillData()
        {
            try
            {
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.DataSource = Idiomas;
                comboBox1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
