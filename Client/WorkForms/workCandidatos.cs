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
using Client.Utils;
using Client.ViewModels;
using Mapster;
using Client.SimpleModels;

namespace Client.WorkForms
{
    public partial class workCandidatos : Form
    {
        public List<SimpleModel> PuestosList { get; set; }
        public CandidatoViewModel Candidato { get; internal set; }
        public RRHHContext Context { get; internal set; }
        public bool Editing { get; set; }
        public workCandidatos()
        {
            InitializeComponent();

        }

        private void workCandidatos_Load(object sender, EventArgs e)
        {
            fillCbxPuestos();
            panel1.BackColor = Color.FromArgb(153, 88, 61);
            panel3.BackColor = Color.FromArgb(232, 69, 67);
            this.BackColor = Color.FromArgb(181, 78, 34);
            if (Editing)
            {
                this.Text += ": Editar";
            }
            else
            {
                Candidato = new CandidatoViewModel();
                Candidato.RecomiendaId = MDIs.MDI_User.IdentificadorEmpleado;
                Candidato.Competencias = new List<CompetenciaViewModel>();
                Candidato.ExperienciaLaborales = new List<ExperienciaLaboralViewModel>();
                Candidato.Idiomas = new List<IdiomaViewModel>();
                Candidato.Capacitaciones = new List<CapacitacionViewModel>();
                this.Text += ": Nuevo";
            }

            this.fillCapacitaciones();
            this.fillCompetencias();
            this.fillExperiencia();
            this.fillIdiomas();
        }


        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!CheckData())
                {
                    MessageBox.Show("Complete los campos faltantes");
                    return;
                }
                var c = Candidato.Adapt<Candidatos>();
                if (Editing)
                {
                    Context.Entry(c).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    Context.Candidatos.Add(c);
                }
                Context.SaveChanges();
                MessageBox.Show("Saved!!!!!!");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Guardar Candidato");
            }
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || !mtxtCedula.ValidateMaskedTextbox() || false)
                return false;
            else if (!mtxtCedula.Text.validaCedula())
            {
                MessageBox.Show("Cedula Invalida");
                return false;
            }

            Candidato.Nombre = txtNombre.Text;

            return true;

        }

        private void cbxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PID = (int)cbxPuesto.SelectedValue;
            Candidato.PuestoId = PID;

            string dep = Context.Puestos.Include("Departamento").FirstOrDefault(x => x.Id == PID).Departamento.Nombre ?? null;
            if (dep != null)
            {
                txtDepartamento.Text = dep;
                Candidato.Departamento = dep;
            }
        }

        private void cmdADD_Capacitaciones_Click(object sender, EventArgs e)
        {
            if (!mtxtCedula.ValidateMaskedTextbox())
            {
                MessageBox.Show("Complete campo Cedula");
                return;
            }
            var cap = new CapacitacionViewModel();
            var frm = new workCapacitaciones()
            {
                context = Context,
                Editing = false,
                CedulaCandidato = Candidato.Cedula,
                cap = cap
            };

            frm.ShowDialog();
            Candidato.Capacitaciones.Add(cap);
            fillCapacitaciones();
        }

        private void fillCapacitaciones()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Nivel");
                dt.Columns.Add("Puesto");
                dt.Columns.Add("Fecha de Inicio");
                dt.Columns.Add("Fecha de Finalizacion");
                dt.Columns.Add("Institucion");

                //var query = ca.Capacitaciones.Where(x => x.CandidatoCedula == Candidato.Cedula);

                var data = Candidato.Capacitaciones;
                foreach (var item in data)
                {
                    var row = dt.NewRow();
                    row[0] = item.Descripcion;
                    row[1] = item.Nivel;
                    row[2] = item.FechaDesde;
                    row[3] = item.FechaDesde;
                    row[4] = item.Institucion;
                    dt.Rows.Add(row);
                }
                dgvCapacitaciones.DataSource = dt;
                dgvCapacitaciones.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //throw ex;
            }
        }

        private void fillCompetencias()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("ID");

                //var query = Context.Candidatos
                //    .Include("Competencias")
                //    .First(x => x.Cedula == Candidato.Cedula).Competencias;

                var data = Candidato.Competencias;
                foreach (var item in data)
                {
                    var row = dt.NewRow();
                    row[0] = item.Descripcion;
                    row["ID"] = item.Id;
                    dt.Rows.Add(row);
                }
                dgvCompetencias.DataSource = dt;
                dgvCompetencias.Refresh();
                dgvCompetencias.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //throw ex;
            }
        }

        private void fillExperiencia()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Empresa");
                dt.Columns.Add("Puesto ");
                dt.Columns.Add("Fecha de Inicio");
                dt.Columns.Add("Fecha de Finalizacion");
                dt.Columns.Add("Salario");
                dt.Columns.Add("ID");
                //var query = Context.ExpLaborales.Where(x => x.CandidatoCedula == Candidato.Cedula);

                var data = Candidato.ExperienciaLaborales;
                foreach (var item in data)
                {
                    var row = dt.NewRow();
                    row[0] = item.Empresa;
                    row[1] = item.PuestoOcupado;
                    row[2] = item.FechaDesde;
                    row[3] = item.FechaDesde;
                    row[4] = item.Salario;
                    row["ID"] = item.Id;
                    dt.Rows.Add(row);
                }
                dgvExpLaboral.DataSource = dt;
                dgvExpLaboral.Refresh();
                dgvExpLaboral.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //throw ex;
            }
        }

        private void fillCbxPuestos()
        {
            cbxPuesto.DisplayMember = "Nombre";
            cbxPuesto.ValueMember = "Id";
            cbxPuesto.DataSource = PuestosList;
            cbxPuesto.Refresh();
        }
        private void fillIdiomas()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Nombre ");
                dt.Columns.Add("Grado");

                //var query = Context.ExpLaborales.Where(x => x.CandidatoCedula == Candidato.Cedula);

                var data = Candidato.Idiomas;
                foreach (var item in data)
                {
                    var row = dt.NewRow();
                    row[0] = item.Id;
                    row[1] = item.Nombre;
                    row[2] = item.Grado;
                    dt.Rows.Add(row);
                }
                dgvIdiomas.DataSource = dt;
                dgvIdiomas.Refresh();
                dgvIdiomas.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                //throw ex;
            }
        }

        private void mtxtCedula_TextChanged(object sender, EventArgs e)
        {
            Candidato.Cedula = mtxtCedula.Text;
        }

        private void cmdADD_Competencias_Click(object sender, EventArgs e)
        {
            var fm = new Forms.frmCRUDCompetencias();
            fm.L_Competencias = Candidato.Competencias;

            fm.ShowDialog();
            Candidato.Competencias.ForEach(x => x.Id = 0);
            this.fillCompetencias();

        }
    }
}
