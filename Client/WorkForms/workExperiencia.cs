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
        }
        
        #region Button Methods

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

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
                dtpInicio.Value = ExperienciaLab.FechaDesde;
                dtpFin.Value = ExperienciaLab.FechaHasta;

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
