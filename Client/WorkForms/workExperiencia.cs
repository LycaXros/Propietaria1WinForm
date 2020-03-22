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
using Data.Models;

namespace Client.WorkForms
{
    public partial class workExperiencia : Form
    {
        public event EventHandler DeletingExpEvent;
        public bool Editing { get; set; }
        public string CedulaCandidato { get; internal set; }
        public ExperienciaLaboralViewModel ExperienciaLab { get; internal set; }
        public bool SaveData { get; internal set; }

        public workExperiencia()
        {
            InitializeComponent();
            cmdEliminar.Visible = false;
            BackColor = Color.FromArgb(179, 125, 255);
            panel1.BackColor = Color.FromArgb(192, 102, 232);
            flowLayoutPanel1.BackColor = Color.FromArgb(121, 102, 232);
            SaveData = false;
            dtpInicio.ValueChanged += DtpInicio_ValueChanged;
        }

        private void DtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInicio.Value >= dtpFin.Value) dtpFin.Value = dtpInicio.Value.AddDays(1);

            dtpFin.MinDate = dtpInicio.Value;
        }

        #region Button Methods

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CheckData();

                Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Save()
        {
            ExperienciaLab.Empresa = txtEmpresa.Text;
            ExperienciaLab.PuestoOcupado= txtPuesto.Text;
            ExperienciaLab.Salario=Convert.ToDouble( nupSalario.Value);
            ExperienciaLab.FechaDesde= dtpInicio.Value;
            ExperienciaLab.FechaHasta= dtpFin.Value;
            SaveData = true;
        }

        private void CheckData()
        {
            if (string.IsNullOrEmpty(txtEmpresa.Text))
            {
                txtEmpresa.Focus();
                throw new NoNullAllowedException("Campo de [Empresa] Vacio, Favor de llenar;");
            } else if (string.IsNullOrEmpty(txtPuesto.Text))
            {
                txtPuesto.Focus();
                throw new NoNullAllowedException("Campo de [Puesto] Vacio, Favor de llenar;");
            }
            else if (nupSalario.Value <= 0)
            {
                nupSalario.Focus();
                throw new NoNullAllowedException("Campo de [Salario] no puede ser cero, Favor de llenar;");
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro", "Eliminando?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //MessageBox.Show("Elemento Eliminado");
                OnTrigerEvent(e, DeletingExpEvent);
                this.Close();
            }
        }

        #endregion

        private void workExperiencia_Load(object sender, EventArgs e)
        {

            if (Editing)
            {
                Text += ": Editando";
                cmdEliminar.Visible = true;
                txtEmpresa.Text = ExperienciaLab.Empresa;
                txtPuesto.Text = ExperienciaLab.PuestoOcupado;
                nupSalario.Value =(decimal)ExperienciaLab.Salario;
                dtpFin.Value = ExperienciaLab.FechaHasta;
                dtpInicio.Value = ExperienciaLab.FechaDesde;

            }
            else
            {
                Text += ": Nuevo Registro";
            }

            lbCedula.Text = CedulaCandidato;
        }



        protected virtual void OnTrigerEvent(EventArgs e, EventHandler eventHandler)
        {
            EventHandler handler = eventHandler;
            handler?.Invoke(this, e);
        }
    }
}
