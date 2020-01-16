namespace Client
{
    partial class VerReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NorthwindDataSet = new Client.NorthwindDataSet();
            this.salesByCatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductsTableAdapter = new Client.NorthwindDataSetTableAdapters.ProductsTableAdapter();
            this.salesByCatTableAdapter = new Client.NorthwindDataSetTableAdapters.SalesByCatTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NorthwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesByCatBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(18, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh Informe";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Client.Reportes.Employees.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(189, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(599, 426);
            this.reportViewer1.TabIndex = 2;
            // 
            // ProductsBindingSource
            // 
            this.ProductsBindingSource.DataMember = "Products";
            this.ProductsBindingSource.DataSource = this.NorthwindDataSet;
            // 
            // NorthwindDataSet
            // 
            this.NorthwindDataSet.DataSetName = "NorthwindDataSet";
            this.NorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesByCatBindingSource
            // 
            this.salesByCatBindingSource.DataMember = "SalesByCat";
            this.salesByCatBindingSource.DataSource = this.NorthwindDataSet;
            // 
            // ProductsTableAdapter
            // 
            this.ProductsTableAdapter.ClearBeforeFill = true;
            // 
            // salesByCatTableAdapter
            // 
            this.salesByCatTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fechaHasta);
            this.groupBox1.Controls.Add(this.fechaDesde);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 426);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Configuracion";
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(6, 50);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(125, 20);
            this.fechaDesde.TabIndex = 2;
            this.fechaDesde.ValueChanged += new System.EventHandler(this.fechaDesde_ValueChanged);
            // 
            // fechaHasta
            // 
            this.fechaHasta.Location = new System.Drawing.Point(8, 130);
            this.fechaHasta.MaxDate = new System.DateTime(2020, 1, 16, 10, 17, 6, 0);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(125, 20);
            this.fechaHasta.TabIndex = 3;
            this.fechaHasta.Value = new System.DateTime(2020, 1, 16, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Hasta";
            // 
            // VerReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VerReporte";
            this.Text = "VerReporte";
            this.Load += new System.EventHandler(this.VerReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NorthwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesByCatBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductsBindingSource;
        private NorthwindDataSet NorthwindDataSet;
        private NorthwindDataSetTableAdapters.ProductsTableAdapter ProductsTableAdapter;
        private System.Windows.Forms.BindingSource salesByCatBindingSource;
        private NorthwindDataSetTableAdapters.SalesByCatTableAdapter salesByCatTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.DateTimePicker fechaDesde;
    }
}