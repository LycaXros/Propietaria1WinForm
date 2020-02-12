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

namespace Client.Forms
{
    public partial class workCapacitaciones : Form
    {
        public bool Editing { get; set; }
        public Capacitaciones cap { get; set; }
        public int CandidatoID { get; internal set; }
        public RRHHContext context { get; internal set; }

        public workCapacitaciones()
        {
            InitializeComponent();
        }

        private void workCapacitaciones_Load(object sender, EventArgs e)
        {

            var d = DateTime.Now;
            dtpInicio.MaxDate = d.AddDays(-1);
            dtpFin.MaxDate = d.AddDays(1).AddTicks(-1);

            if (!Editing)
            {
                cmdEliminar.Visible = false;
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
                if (cbxNivel.SelectedItem == null )
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
            if (Editing)
            {
                SaveEdit();
            }
            else
            {

                context.Capacitaciones.Add(
                    new Capacitaciones
                    {
                        CandidatoId = CandidatoID,
                        Descripcion = txtDescipcion.Text,
                        FechaDesde = dtpInicio.Value,
                        FechaHasta = dtpFin.Value,
                        Institucion = txtInstitucion.Text,
                        Nivel = cbxNivel.SelectedItem.ToString()
                    }
                    );
                context.SaveChanges();
            }
            MessageBox.Show("Guardado Exitoso");

        }

        private void SaveEdit()
        {
            cap.Descripcion = txtDescipcion.Text;
            cap.FechaDesde = dtpInicio.Value;
            cap.FechaHasta = dtpFin.Value;
            cap.Institucion = txtInstitucion.Text;
            cap.Nivel = cbxNivel.SelectedText;
            context.Entry(cap).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro","Eliminando?",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Elemento Eliminado");
                this.Close();
            }
        }
    }
}
