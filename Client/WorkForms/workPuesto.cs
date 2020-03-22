using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.Events;
using Client.SimpleModels;
using Client.ViewModels;
using Data.Models;
using Data.Utils;

namespace Client.WorkForms
{
    public partial class workPuesto : Form
    {
        public event EventHandler DeletingPuestoEvent;
        public event EventHandler SavePuestoEvent;
        public PuestoViewModel PuestoD { get; internal set; }
        public bool Editing { get; internal set; }
        public List<SimpleModel> DepList { get; internal set; }

        public workPuesto()
        {
            InitializeComponent();
            Editing = false;
            nupSalMin.Maximum = Int32.MaxValue-2;
            nupSalMax.Maximum = Int32.MaxValue;
            nupSalMin.ValueChanged += NupSalMin_ValueChanged;
            this.Size = new System.Drawing.Size(572, 444);
            toolTip1.SetToolTip(cmdCompetencias, "Agregar/Editar Competencias");

        }

        private void NupSalMin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                nupSalMax.Value = nupSalMin.Value + 1;
                nupSalMax.Minimum = nupSalMin.Value;
            }
            catch (Exception)
            {
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            string tName = null;
            string tRiesgo = null;
            double dMin = 0d;
            double dMax = 0d;
            int dDep = 0;
            EstadoPersistencia dState = EstadoPersistencia.Activo;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Favor de Llenar campo de Nombre");
                txtNombre.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(cbxRiesgo.Text))
            {
                MessageBox.Show("Favor de Selecionar el Riesgo");
                cbxRiesgo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(cbxDepartamento.Text))
            {
                MessageBox.Show("Favor de Selecionar el Departamento");
                cbxDepartamento.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(cbxEstado.Text))
            {
                MessageBox.Show("Favor de Selecionar el Estado");
                cbxEstado.Focus();
                return;
            }else
            {
                tName = txtNombre.Text;
                tRiesgo = cbxRiesgo.Text;
                dState = EnumUtil.ParseEnum<EstadoPersistencia>(cbxEstado.Text);
                dDep = (int)cbxDepartamento.SelectedValue;
                dMin = Convert.ToDouble(nupSalMin.Value);
                dMax = Convert.ToDouble(nupSalMax.Value);
            }


            PuestoD.Nombre = tName;
            PuestoD.Riesgo = tRiesgo;
            PuestoD.SalarioMinimo = dMin;
            PuestoD.SalarioMaximo = dMax;
            PuestoD.DepartamentoID = dDep;
            PuestoD.Estado = dState;
            OnSavePuestoEvent(new SaveDataArgs(Editing));
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro de eliminar este registro", "Eliminando?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OnDeletingPuestoEvent(e);
                this.Close();
            }
        }

        protected virtual void OnDeletingPuestoEvent(EventArgs e)
        {
            EventHandler handler = DeletingPuestoEvent;
            handler?.Invoke(this, e);
        }
        protected virtual void OnSavePuestoEvent(SaveDataArgs e)
        {
            EventHandler handler = SavePuestoEvent;
            handler?.Invoke(this, e);
        }

        private void workPuesto_Load(object sender, EventArgs e)
        {
            cmdEliminar.Visible = false;
            cbxDepartamento.DisplayMember = "Nombre";
            cbxDepartamento.ValueMember = "Id";
            cbxDepartamento.DataSource = DepList;
            cbxDepartamento.Refresh();
            if (Editing)
            {
                
                txtNombre.Text = PuestoD.Nombre;
                cbxRiesgo.SelectedIndex = cbxRiesgo.FindString(PuestoD.Riesgo);
                cbxDepartamento.SelectedValue = PuestoD.DepartamentoID;
                cbxEstado.SelectedIndex = cbxEstado.FindString(PuestoD.Estado.ToString());
                nupSalMin.Value = (decimal)PuestoD.SalarioMinimo;
                nupSalMax.Value = (decimal)PuestoD.SalarioMaximo;
                cmdEliminar.Visible = true;
                
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCompetencias_Click(object sender, EventArgs e)
        {
            var frm = new Forms.frmCRUDCompetencias() {
                L_Competencias = PuestoD.Competencias
            };
            frm.ShowDialog();
        }
    }
}
