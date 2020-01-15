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
        public VerReporte()
        {
            InitializeComponent();
        }

        private void VerReporte_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            var db = new DB.Model.NorthwindEntities();
            var productos = (from p in db.Products select p).ToList();
            var cat = (from p in db.Sales_by_Category select p).ToList();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            var rds = new ReportDataSource("DataSet1", productos);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", cat));
            reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes/Employees.rdlc";
            reportViewer1.LocalReport.ReportPath = @"Reportes/Employees.rdlc";
            //reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

        }
    }
}
