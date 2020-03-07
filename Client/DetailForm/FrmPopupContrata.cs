using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ViewModels;

namespace Client.DetailForm
{
    public partial class FrmPopupContrata : Form
    {
        private double _sueldo;
        public bool Contratar { get; set; }
        

        public FrmPopupContrata()
        {
            InitializeComponent();
            _sueldo = 0;
            Contratar = false;
        }

        public string Info { get; internal set; }

        public double Sueldo
        {
            get => _sueldo;
        }
        public PuestoViewModel Puesto { get; internal set; }

        private void FirmContrata()
        {
            _sueldo = Convert.ToDouble( numericUpDown1.Value);
            Contratar = true;
            this.Close();
        }

        private void FrmPopupContrata_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = (decimal)(Puesto.SalarioMaximo * 1.5);
            numericUpDown1.Value = (decimal)Puesto.SalarioMinimo + 1;
            numericUpDown1.Minimum = (decimal)Puesto.SalarioMinimo;
            lblSMin.Text = "Salario Minimo: " + Puesto.SalarioMinimo.ToString("RD$ ###,###,###.##");
            lblSMax.Text = "Salario Maximo: " + Puesto.SalarioMaximo.ToString("RD$ ###,###,###.##");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Contratar a:\n{Info}", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FirmContrata();
            }
        }
    }
}
