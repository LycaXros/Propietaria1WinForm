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
using Mapster;

namespace Client.WorkForms
{
    public partial class workCapacitaciones : Form
    {
        public event EventHandler DeletingCapacitacionesEvent;
        //public event EventHandler SavePuestoEvent;
        public bool SaveData { get; private set; }
        public bool Editing { get; set; }
        public CapacitacionViewModel cap { get; set; }
        public string CedulaCandidato { get; internal set; }
        //public RRHHContext ContextCapacitaciones { get; internal set; }

        public workCapacitaciones()
        {
            InitializeComponent();
            SaveData = false;
        }

        private void workCapacitaciones_Load(object sender, EventArgs e)
        {

            var d = DateTime.Now;
            dtpInicio.MaxDate = d.AddDays(-1);
            dtpFin.MaxDate = d.AddDays(1).AddTicks(-1);

            if (!Editing)
            {
                cmdEliminar.Visible = false;
                cap = new CapacitacionViewModel();
            }
            else
            {
                lblID.Text = cap.Id.ToString();
                txtDescipcion.Text = cap.Descripcion;
                txtInstitucion.Text = cap.Institucion;
                dtpInicio.Value = cap.FechaDesde;
                dtpFin.Value = cap.FechaHasta;
                cbxNivel.SelectedIndex = cbxNivel.Items.IndexOf(cap.Nivel);
            }
            lbCedula.Text = CedulaCandidato;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtDescipcion.Text))
                {
                    MessageBox.Show("Campo Descripcion Vacio Favor de Llenar");
                    txtDescipcion.Focus();
                    return;
                }
                else
                if (cbxNivel.SelectedItem == null)
                {

                    MessageBox.Show("Campo Nivel Vacio Favor de Seleccionar Uno");
                    cbxNivel.Focus();
                    return;
                }
                else
                if (string.IsNullOrEmpty(txtInstitucion.Text))
                {

                    MessageBox.Show("Campo Institucion Vacio Favor de Llenar");
                    txtInstitucion.Focus();
                    return;
                }
                Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Save()
        {
            try
            {

                if (Editing)
                {
                    SaveEdit();
                }
                else
                {
                    cap.CandidatoCedula = CedulaCandidato;
                    cap.Descripcion = txtDescipcion.Text;
                    cap.FechaDesde = dtpInicio.Value;
                    cap.FechaHasta = dtpFin.Value;
                    cap.Institucion = txtInstitucion.Text;
                    cap.Nivel = cbxNivel.SelectedItem.ToString();

                    //ContextCapacitaciones.Capacitaciones.Add(cap.Adapt<Capacitaciones>());
                    //ContextCapacitaciones.SaveChanges();
                }
                MessageBox.Show("Guardado Exitoso");
                SaveData = true;
            }
            catch (Exception)
            {
            }
        }

        private void SaveEdit()
        {
            try
            {
                cap.Descripcion = txtDescipcion.Text;
                cap.FechaDesde = dtpInicio.Value;
                cap.FechaHasta = dtpFin.Value;
                cap.Institucion = txtInstitucion.Text;
                cap.Nivel = cbxNivel.SelectedText;
                var c = cap.Adapt<Capacitaciones>();
                //ContextCapacitaciones.Entry(c).State = System.Data.Entity.EntityState.Modified;
                //ContextCapacitaciones.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error") ;
                throw ex;
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro", "Eliminando?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //MessageBox.Show("Elemento Eliminado");
                OnTrigerEvent(e, DeletingCapacitacionesEvent);
                this.Close();
            }
        }


        protected virtual void OnTrigerEvent(EventArgs e, EventHandler eventHandler)
        {
            EventHandler handler = eventHandler;
            handler?.Invoke(this, e);
        }

    }
}
