namespace Client.DetailForm
{
    partial class PuestoDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSalMax = new System.Windows.Forms.Label();
            this.lblSalMin = new System.Windows.Forms.Label();
            this.lblRiesgo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lbxCompetencias = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSalMax);
            this.panel1.Controls.Add(this.lblSalMin);
            this.panel1.Controls.Add(this.lblRiesgo);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 240);
            this.panel1.TabIndex = 0;
            // 
            // lblSalMax
            // 
            this.lblSalMax.AutoSize = true;
            this.lblSalMax.BackColor = System.Drawing.Color.Transparent;
            this.lblSalMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalMax.Location = new System.Drawing.Point(22, 169);
            this.lblSalMax.Name = "lblSalMax";
            this.lblSalMax.Size = new System.Drawing.Size(65, 20);
            this.lblSalMax.TabIndex = 6;
            this.lblSalMax.Text = "Nombre";
            // 
            // lblSalMin
            // 
            this.lblSalMin.AutoSize = true;
            this.lblSalMin.BackColor = System.Drawing.Color.Transparent;
            this.lblSalMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalMin.Location = new System.Drawing.Point(22, 120);
            this.lblSalMin.Name = "lblSalMin";
            this.lblSalMin.Size = new System.Drawing.Size(65, 20);
            this.lblSalMin.TabIndex = 5;
            this.lblSalMin.Text = "Nombre";
            // 
            // lblRiesgo
            // 
            this.lblRiesgo.AutoSize = true;
            this.lblRiesgo.BackColor = System.Drawing.Color.Transparent;
            this.lblRiesgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiesgo.Location = new System.Drawing.Point(22, 74);
            this.lblRiesgo.Name = "lblRiesgo";
            this.lblRiesgo.Size = new System.Drawing.Size(65, 20);
            this.lblRiesgo.TabIndex = 4;
            this.lblRiesgo.Text = "Nombre";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(22, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 20);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdCancelar);
            this.panel2.Controls.Add(this.lbxCompetencias);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(269, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 240);
            this.panel2.TabIndex = 7;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackgroundImage = global::Client.Properties.Resources.cancel_red;
            this.cmdCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatAppearance.BorderSize = 0;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancelar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.Location = new System.Drawing.Point(321, 85);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(60, 55);
            this.cmdCancelar.TabIndex = 35;
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // lbxCompetencias
            // 
            this.lbxCompetencias.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCompetencias.FormattingEnabled = true;
            this.lbxCompetencias.ItemHeight = 20;
            this.lbxCompetencias.Location = new System.Drawing.Point(14, 39);
            this.lbxCompetencias.Name = "lbxCompetencias";
            this.lbxCompetencias.Size = new System.Drawing.Size(262, 184);
            this.lbxCompetencias.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Competencias";
            // 
            // PuestoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 290);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PuestoDetail";
            this.Text = "PuestoDetail";
            this.Load += new System.EventHandler(this.PuestoDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblRiesgo;
        private System.Windows.Forms.Label lblSalMin;
        private System.Windows.Forms.Label lblSalMax;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbxCompetencias;
        private System.Windows.Forms.Button cmdCancelar;
    }
}