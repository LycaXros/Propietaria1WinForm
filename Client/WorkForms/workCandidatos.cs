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
        private Dictionary<int, CapacitacionViewModel> dictionaryCap;
        private Dictionary<int, IdiomaViewModel> dictionaryIdioma;
        private Dictionary<int, ExperienciaLaboralViewModel> dictionaryExp;
        private int idCurrentCap = 0;
        private int idCurrentIdio = 0;
        private int idCurrentExp = 0;

        public List<SimpleModel> PuestosList { get; set; }
        public CandidatoViewModel Candidato { get; internal set; }
        public RRHHContext Context { get; internal set; }
        public bool Editing { get; set; }
        public workCandidatos()
        {
            InitializeComponent();
            dictionaryCap = new Dictionary<int, CapacitacionViewModel>();
            dictionaryExp = new Dictionary<int, ExperienciaLaboralViewModel>();
            dictionaryIdioma = new Dictionary<int, IdiomaViewModel>();
            dgvCapacitaciones.CellDoubleClick += DgvCapacitaciones_CellDoubleClick;
            dgvExpLaboral.CellDoubleClick += DgvExpLaboral_CellDoubleClick;
            dgvIdiomas.CellDoubleClick += DgvIdiomas_CellDoubleClick;
        }

        private void workCandidatos_Load(object sender, EventArgs e)
        {
            fillCbxPuestos();
            toolTip1.SetToolTip(btnInfo, "Ver informacion del Puesto");
            panel1.BackColor = Color.FromArgb(153, 88, 61);
            panel3.BackColor = Color.FromArgb(232, 69, 67);
            this.BackColor = Color.FromArgb(181, 78, 34);
            if (Editing)
            {
                this.Text += ": Editar";
                mtxtCedula.Text = Candidato.Cedula;
                mtxtCedula.ReadOnly = true;
                txtNombre.Text = Candidato.Nombre;
                var i = PuestosList.Find(x => x.Id == Candidato.PuestoId);
                if (i != null) cbxPuesto.SelectedIndex = cbxPuesto.Items.IndexOf(i);
            }
            else
            {
                //Candidato = new CandidatoViewModel();
                Candidato.RecomiendaId = MDIs.MDI_User.IdentificadorEmpleado;
                Candidato.ExperienciaLaborales = new List<ExperienciaLaboralViewModel>();
                Candidato.Idiomas = new List<IdiomaViewModel>();
                Candidato.Capacitaciones = new List<CapacitacionViewModel>();
                this.Text += ": Nuevo";
            }
            FillDictionary();
            this.fillCapacitaciones();
            this.fillExperiencia();
            this.fillIdiomas();
        }

        private void FillDictionary()
        {
            //Capacitaciones
            if (dictionaryCap.Count > 0) dictionaryCap.Clear();
            int c = 0;
            foreach (var item in Candidato.Capacitaciones)
            {
                dictionaryCap.Add(++c, item);
            }
            //Experiencia
            if (dictionaryExp.Count > 0) dictionaryExp.Clear();
            c = 0;
            foreach (var item in Candidato.ExperienciaLaborales)
            {
                dictionaryExp.Add(++c, item);
            }
            //Idiomas
            if (dictionaryIdioma.Count > 0) dictionaryIdioma.Clear();
            c = 0;
            foreach (var item in Candidato.Idiomas)
            {
                dictionaryIdioma.Add(++c, item);
            }
        }


        private void PrepareLists()
        {
            Candidato.Capacitaciones.Clear();
            Candidato.Idiomas.Clear();
            Candidato.ExperienciaLaborales.Clear();

            Candidato.Capacitaciones.AddRange(dictionaryCap.Values);
            Candidato.Idiomas.AddRange(dictionaryIdioma.Values);
            Candidato.ExperienciaLaborales.AddRange(dictionaryExp.Values);
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
            Candidato.Cedula = mtxtCedula.Text;

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

        #region Delete Events

        private void DeleteCapacitacion(object sender, EventArgs e)
        {
            if (idCurrentCap > 0)
            {
                dictionaryCap.Remove(idCurrentCap);
                MessageBox.Show("Eliminado");
                idCurrentCap = 0;
            }
        }
        private void DeleteExp(object sender, EventArgs e)
        {
            if (idCurrentExp > 0)
            {
                dictionaryExp.Remove(idCurrentExp);
                MessageBox.Show("Eliminado");
                idCurrentExp = 0;
            }
        }
        private void DeleteIdioma(object sender, EventArgs e)
        {
            if (idCurrentIdio > 0)
            {
                dictionaryIdioma.Remove(idCurrentIdio);
                MessageBox.Show("Eliminado");
                idCurrentIdio = 0;
            }
        }
        #endregion

        #region Fill Methods

        private void fillCapacitaciones()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Nivel");
                dt.Columns.Add("Fecha de Inicio");
                dt.Columns.Add("Fecha de Finalizacion");
                dt.Columns.Add("Institucion");
                dt.Columns.Add("ID");

                //var query = ca.Capacitaciones.Where(x => x.CandidatoCedula == Candidato.Cedula);

                foreach (var item in dictionaryCap)
                {
                    var cap = item.Value;
                    var row = dt.NewRow();
                    row[0] = cap.Descripcion;
                    row[1] = cap.Nivel;
                    row[2] = cap.FechaDesde.ToString("dd-MMM-yyyy");
                    row[3] = cap.FechaHasta.ToString("dd-MMM-yyyy");
                    row[4] = cap.Institucion;
                    row["ID"] = item.Key;
                    dt.Rows.Add(row);
                }
                dgvCapacitaciones.DataSource = dt;
                dgvCapacitaciones.Refresh();
                dgvCapacitaciones.Columns["ID"].Visible = false;
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

                //var data = Candidato.ExperienciaLaborales;
                foreach (var item in dictionaryExp)
                {
                    var row = dt.NewRow();
                    var exp = item.Value;
                    row[0] = exp.Empresa;
                    row[1] = exp.PuestoOcupado;
                    row[2] = exp.FechaDesde.ToString("dd-MMM-yyyy"); ;
                    row[3] = exp.FechaHasta.ToString("dd-MMM-yyyy"); ;
                    row[4] = exp.Salario;
                    row["ID"] = item.Key;
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

                //var data = Candidato.Idiomas;
                foreach (var item in dictionaryIdioma)
                {
                    var row = dt.NewRow();
                    var idioma = item.Value;
                    row[0] = item.Key;
                    row[1] = idioma.Nombre;
                    row[2] = idioma.Grado;
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

        #endregion


        private PuestoViewModel GetPuesto()
        {
            var simple = (SimpleModel)cbxPuesto.SelectedItem;
            var p = Context.Puestos
                .Include("Competencias")
                .FirstOrDefault(x => x.Id == simple.Id);
            //.Find(simple.Id);
            if (p == null) { return null; }
            return p.Adapt<PuestoViewModel>();
        }

        #region DataGridView CellClickMethods

        private void DgvCapacitaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dgvCapacitaciones.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            var c = dictionaryCap[id].Adapt<CapacitacionViewModel>();
            idCurrentCap = id;
            var frm = new workCapacitaciones()
            {
                Editing = true,
                cap = c,
                //ContextCapacitaciones = context,
                CedulaCandidato =mtxtCedula.Text
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DeletingCapacitacionesEvent += DeleteCapacitacion;
            frm.ShowDialog();
            frm.DeletingCapacitacionesEvent -= DeleteCapacitacion;
            if (frm.SaveData) { dictionaryCap[id] = c; }
            fillCapacitaciones();
        }

        private void DgvIdiomas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dgvIdiomas.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            var c = dictionaryIdioma[id].Adapt<IdiomaViewModel>();
            idCurrentIdio = id;
        }

        private void DgvExpLaboral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dgvExpLaboral.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            var c = dictionaryExp[id].Adapt<ExperienciaLaboralViewModel>();
            idCurrentExp = id;
            var frm = new workExperiencia()
            {
                Editing = true,
                CedulaCandidato = Candidato.Cedula,
                ExperienciaLab = c
            };
            frm.DeletingExpEvent += DeleteExp;
            frm.ShowDialog();
            frm.DeletingExpEvent -= DeleteExp;
            if (frm.SaveData) { dictionaryExp[id] = c; }
            fillExperiencia();
        }

        #endregion

        #region Button Clicks
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
                PrepareLists();

                //c.Capacitaciones.ToList().ForEach(x => x.CandidatoCedula = c.Cedula);
                //c.ExperienciaLaborales.ToList().ForEach(x => x.CandidatoCedula = c.Cedula);


                if (Editing)
                {
                    var c = Context.Candidatos
                        .Include("PuestoAspira")                        
                        .FirstOrDefault(x=> x.Cedula == Candidato.Cedula);

                    c.PuestoAspira.IsAvailable = true;
                    c.Nombre = Candidato.Nombre;
                    c.PuestoId = Candidato.PuestoId;
                    c.Departamento = Candidato.Departamento;

                    //c = Candidato.Adapt<Candidatos>();

                    var caps =Candidato.Capacitaciones.Select(x => x.Id);
                    c.Capacitaciones = c.Capacitaciones.Where(x => caps.Contains(x.Id)).ToList();
                    c.Capacitaciones.ToList().ForEach(x=> {
                        var data = Candidato.Capacitaciones.First(cc => cc.Id == x.Id);
                        x.Institucion = data.Institucion;
                        x.Nivel = data.Nivel;
                        x.FechaDesde = data.FechaDesde;
                        x.FechaHasta = data.FechaHasta;
                        x.Descripcion = data.Descripcion;
                    });
                    var exps = Candidato.ExperienciaLaborales.Select(x => x.Id);
                    c.ExperienciaLaborales = c.ExperienciaLaborales.Where(x => exps.Contains(x.Id)).ToList();
                    c.ExperienciaLaborales.ToList().ForEach(x=> {
                        var data = Candidato.ExperienciaLaborales.First(cc => cc.Id == x.Id);
                        x.Empresa = data.Empresa;
                        x.FechaDesde = data.FechaDesde;
                        x.FechaHasta = data.FechaHasta;
                        x.PuestoOcupado = data.PuestoOcupado;
                        x.Salario = data.Salario;
                    });

                    c.Idiomas = Candidato.Idiomas.Adapt<IList<Idiomas>>();
                }
                else
                {
                    var c = Candidato.Adapt<Candidatos>();
                    //c.RecomiendaId = MDIs.MDI_User.IdentificadorEmpleado;
                    Context.Candidatos.Add(c);
                }
                Context.SaveChanges();
                Context.Database.ExecuteSqlCommand($" update [RRHH_DATA].[dbo].[Puestos] set [IsAvailable] = 0 where [Id] = {Candidato.PuestoId} ");
                MessageBox.Show("Saved!!!!!!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Guardar Candidato: {ex.Message}");
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            var frm = new DetailForm.PuestoDetail() { Puesto = GetPuesto() };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
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
                //ContextCapacitaciones = Context,
                Editing = false,
                CedulaCandidato =mtxtCedula.Text,// Candidato.Cedula,
                cap = cap
            };
            frm.ShowDialog();
            if (frm.SaveData)
            {
                //Candidato.Capacitaciones.Add(cap);
                dictionaryCap.Add(dictionaryCap.Count + 1, cap);
            }
            fillCapacitaciones();
        }

        private void btnAddExp_Click(object sender, EventArgs e)
        {
            var cap = new ExperienciaLaboralViewModel();
            var frm = new workExperiencia()
            {
                Editing = false,
                CedulaCandidato = Candidato.Cedula,
                ExperienciaLab = cap
            };
            frm.ShowDialog();
            if (frm.SaveData)
            {
                dictionaryExp.Add(dictionaryExp.Count + 1, cap);
            }
            fillExperiencia();
        }

        private void btnIdiomasAdd_Click(object sender, EventArgs e)
        {

        }


        #endregion

    }
}
