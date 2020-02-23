using Data.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class VerReporte : Form
    {
        public RRHHContext _db { get; internal set; }
        public VerReporte()
        {
            InitializeComponent();
        }

        private void VerReporte_Load(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            fechaDesde.Value = DateTime.Now.AddDays(-100);
            fechaDesde.MaxDate = d.AddDays(-1);
            fechaHasta.MaxDate = d.AddDays(1).AddTicks(-1);
            fechaHasta.Value = d;
            //this.reportViewer1.RefreshReport();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var fechaI = fechaDesde.Value;
                var fechaF = fechaHasta.Value;
                var data = _db.V_EmployeePuesto
                    //.Where(x => x.FechaIngreso >= fechaI && x.FechaIngreso < fechaF)
                    .ToList();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.DataSources.Clear();
                var rds = new ReportDataSource("DataSet1", data);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes/Employees.rdlc";
                reportViewer1.LocalReport.ReportPath = @"Reportes/Employees.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n {ex.Message}");
            }
            //var db = new DB.Model.NorthwindEntities();
            //var productos = (from p in db.Products select p).ToList();
            //var cat = (from p in db.Sales_by_Category select p).ToList();
            //var ord = (from p in db.Orders
            //           where p.OrderDate.Value >= fechaI && p.OrderDate.Value <=fechaF
            //           select p).ToList();
            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            //reportViewer1.LocalReport.DataSources.Clear();
            //var rds = new ReportDataSource("DataSet1", productos);
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", cat));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", ord));
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes/Employees.rdlc";
            //reportViewer1.LocalReport.ReportPath = @"Reportes/Employees.rdlc";
            ////reportViewer1.LocalReport.Refresh();
            //reportViewer1.RefreshReport();

        }

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {
            fechaHasta.MinDate = fechaDesde.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
