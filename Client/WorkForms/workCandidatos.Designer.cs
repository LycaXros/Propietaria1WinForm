namespace Client.WorkForms
{
    partial class workCandidatos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxPuesto = new System.Windows.Forms.ComboBox();
            this.puestosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.mtxtCedula = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdADD_Competencias = new System.Windows.Forms.Button();
            this.dgvCompetencias = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmdADD_Capacitaciones = new System.Windows.Forms.Button();
            this.dgvCapacitaciones = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvExpLaboral = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puestosBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitaciones)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpLaboral)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cbxPuesto);
            this.panel1.Controls.Add(this.txtDepartamento);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.mtxtCedula);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 181);
            this.panel1.TabIndex = 0;
            // 
            // cbxPuesto
            // 
            this.cbxPuesto.DataSource = this.puestosBindingSource;
            this.cbxPuesto.DisplayMember = "Nombre";
            this.cbxPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbxPuesto.FormattingEnabled = true;
            this.cbxPuesto.Location = new System.Drawing.Point(18, 128);
            this.cbxPuesto.Name = "cbxPuesto";
            this.cbxPuesto.Size = new System.Drawing.Size(190, 28);
            this.cbxPuesto.TabIndex = 7;
            this.cbxPuesto.ValueMember = "Id";
            this.cbxPuesto.SelectedIndexChanged += new System.EventHandler(this.cbxPuesto_SelectedIndexChanged);
            // 
            // puestosBindingSource
            // 
            this.puestosBindingSource.DataSource = typeof(Data.Models.Puestos);
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartamento.Location = new System.Drawing.Point(293, 128);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.ReadOnly = true;
            this.txtDepartamento.Size = new System.Drawing.Size(224, 26);
            this.txtDepartamento.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(293, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(224, 26);
            this.txtNombre.TabIndex = 5;
            // 
            // mtxtCedula
            // 
            this.mtxtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtCedula.Location = new System.Drawing.Point(17, 45);
            this.mtxtCedula.Mask = "000-0000000-0";
            this.mtxtCedula.Name = "mtxtCedula";
            this.mtxtCedula.Size = new System.Drawing.Size(126, 26);
            this.mtxtCedula.TabIndex = 4;
            this.mtxtCedula.TextChanged += new System.EventHandler(this.mtxtCedula_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Departamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puesto Aspira";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cedula";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(17, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(670, 246);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmdADD_Competencias);
            this.tabPage1.Controls.Add(this.dgvCompetencias);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(662, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Competencias";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdADD_Competencias
            // 
            this.cmdADD_Competencias.BackgroundImage = global::Client.Properties.Resources.add_circle;
            this.cmdADD_Competencias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdADD_Competencias.FlatAppearance.BorderSize = 0;
            this.cmdADD_Competencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdADD_Competencias.Location = new System.Drawing.Point(537, 49);
            this.cmdADD_Competencias.Name = "cmdADD_Competencias";
            this.cmdADD_Competencias.Size = new System.Drawing.Size(75, 64);
            this.cmdADD_Competencias.TabIndex = 22;
            this.cmdADD_Competencias.UseVisualStyleBackColor = true;
            this.cmdADD_Competencias.Click += new System.EventHandler(this.cmdADD_Competencias_Click);
            // 
            // dgvCompetencias
            // 
            this.dgvCompetencias.AllowUserToAddRows = false;
            this.dgvCompetencias.AllowUserToDeleteRows = false;
            this.dgvCompetencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetencias.Location = new System.Drawing.Point(6, 22);
            this.dgvCompetencias.Name = "dgvCompetencias";
            this.dgvCompetencias.ReadOnly = true;
            this.dgvCompetencias.Size = new System.Drawing.Size(428, 181);
            this.dgvCompetencias.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmdADD_Capacitaciones);
            this.tabPage2.Controls.Add(this.dgvCapacitaciones);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(662, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Capacitaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmdADD_Capacitaciones
            // 
            this.cmdADD_Capacitaciones.BackgroundImage = global::Client.Properties.Resources.add_circle;
            this.cmdADD_Capacitaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdADD_Capacitaciones.FlatAppearance.BorderSize = 0;
            this.cmdADD_Capacitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdADD_Capacitaciones.Location = new System.Drawing.Point(29, 69);
            this.cmdADD_Capacitaciones.Name = "cmdADD_Capacitaciones";
            this.cmdADD_Capacitaciones.Size = new System.Drawing.Size(75, 64);
            this.cmdADD_Capacitaciones.TabIndex = 23;
            this.cmdADD_Capacitaciones.UseVisualStyleBackColor = true;
            this.cmdADD_Capacitaciones.Click += new System.EventHandler(this.cmdADD_Capacitaciones_Click);
            // 
            // dgvCapacitaciones
            // 
            this.dgvCapacitaciones.AllowUserToAddRows = false;
            this.dgvCapacitaciones.AllowUserToDeleteRows = false;
            this.dgvCapacitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapacitaciones.Location = new System.Drawing.Point(125, 15);
            this.dgvCapacitaciones.Name = "dgvCapacitaciones";
            this.dgvCapacitaciones.ReadOnly = true;
            this.dgvCapacitaciones.Size = new System.Drawing.Size(513, 190);
            this.dgvCapacitaciones.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.dgvExpLaboral);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(662, 220);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Experiencia Laboral";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Client.Properties.Resources.add_circle;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(554, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 64);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgvExpLaboral
            // 
            this.dgvExpLaboral.AllowUserToAddRows = false;
            this.dgvExpLaboral.AllowUserToDeleteRows = false;
            this.dgvExpLaboral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpLaboral.Location = new System.Drawing.Point(41, 14);
            this.dgvExpLaboral.Name = "dgvExpLaboral";
            this.dgvExpLaboral.ReadOnly = true;
            this.dgvExpLaboral.Size = new System.Drawing.Size(471, 193);
            this.dgvExpLaboral.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(662, 220);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Idiomas";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Client.Properties.Resources.add_circle;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(550, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 64);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(471, 193);
            this.dataGridView1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(12, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 274);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.cmdGuardar);
            this.panel3.Controls.Add(this.cmdEliminar);
            this.panel3.Location = new System.Drawing.Point(597, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 181);
            this.panel3.TabIndex = 4;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.BackgroundImage = global::Client.Properties.Resources.save;
            this.cmdGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdGuardar.FlatAppearance.BorderSize = 0;
            this.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGuardar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGuardar.Location = new System.Drawing.Point(24, 93);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(60, 70);
            this.cmdGuardar.TabIndex = 29;
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.BackgroundImage = global::Client.Properties.Resources.trashCan;
            this.cmdEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdEliminar.FlatAppearance.BorderSize = 0;
            this.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEliminar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEliminar.Location = new System.Drawing.Point(24, 17);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(60, 70);
            this.cmdEliminar.TabIndex = 31;
            this.cmdEliminar.UseVisualStyleBackColor = true;
            // 
            // workCandidatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 485);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "workCandidatos";
            this.Text = "Candidato";
            this.Load += new System.EventHandler(this.workCandidatos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puestosBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapacitaciones)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpLaboral)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCompetencias;
        private System.Windows.Forms.DataGridView dgvCapacitaciones;
        private System.Windows.Forms.DataGridView dgvExpLaboral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxPuesto;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.MaskedTextBox mtxtCedula;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdEliminar;
        private System.Windows.Forms.BindingSource puestosBindingSource;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button cmdADD_Competencias;
        private System.Windows.Forms.Button cmdADD_Capacitaciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}