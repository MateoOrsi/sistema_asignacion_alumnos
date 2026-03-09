namespace sistema_asignacion_alumnos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbcurso = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.cmbp3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbldni = new System.Windows.Forms.Label();
            this.lblcurso = new System.Windows.Forms.Label();
            this.cmbp2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbp1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(259, 23);
            this.button3.TabIndex = 46;
            this.button3.Text = "SELECCIONAR ARCHIVO DESTINO";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "SELECCIONAR ARCHIVO ORIGEN";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(320, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 431);
            this.dataGridView1.TabIndex = 44;
            // 
            // cmbcurso
            // 
            this.cmbcurso.FormattingEnabled = true;
            this.cmbcurso.Location = new System.Drawing.Point(177, 143);
            this.cmbcurso.Name = "cmbcurso";
            this.cmbcurso.Size = new System.Drawing.Size(121, 21);
            this.cmbcurso.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "SELECCIONAR CURSO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblestado);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.cmbp3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbldni);
            this.groupBox1.Controls.Add(this.lblcurso);
            this.groupBox1.Controls.Add(this.cmbp2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbp1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(39, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 316);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ALUMNO SELECCIONADO";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(103, 114);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(54, 13);
            this.lblestado.TabIndex = 30;
            this.lblestado.Text = "ESTADO:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "CARGAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(12, 34);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(57, 13);
            this.lblname.TabIndex = 23;
            this.lblname.Text = "NOMBRE:";
            // 
            // cmbp3
            // 
            this.cmbp3.FormattingEnabled = true;
            this.cmbp3.Items.AddRange(new object[] {
            "ELECTROMECANICA",
            "ELECTRONICA",
            "AUTOMOTORES"});
            this.cmbp3.Location = new System.Drawing.Point(106, 231);
            this.cmbp3.Name = "cmbp3";
            this.cmbp3.Size = new System.Drawing.Size(121, 21);
            this.cmbp3.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "PRIORIDAD 3:";
            // 
            // lbldni
            // 
            this.lbldni.AutoSize = true;
            this.lbldni.Location = new System.Drawing.Point(12, 74);
            this.lbldni.Name = "lbldni";
            this.lbldni.Size = new System.Drawing.Size(29, 13);
            this.lbldni.TabIndex = 25;
            this.lbldni.Text = "DNI:";
            // 
            // lblcurso
            // 
            this.lblcurso.AutoSize = true;
            this.lblcurso.Location = new System.Drawing.Point(12, 114);
            this.lblcurso.Name = "lblcurso";
            this.lblcurso.Size = new System.Drawing.Size(48, 13);
            this.lblcurso.TabIndex = 27;
            this.lblcurso.Text = "CURSO:";
            // 
            // cmbp2
            // 
            this.cmbp2.FormattingEnabled = true;
            this.cmbp2.Items.AddRange(new object[] {
            "ELECTROMECANICA",
            "ELECTRONICA",
            "AUTOMOTORES"});
            this.cmbp2.Location = new System.Drawing.Point(106, 191);
            this.cmbp2.Name = "cmbp2";
            this.cmbp2.Size = new System.Drawing.Size(121, 21);
            this.cmbp2.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "PRIORIDAD 2:";
            // 
            // cmbp1
            // 
            this.cmbp1.FormattingEnabled = true;
            this.cmbp1.Items.AddRange(new object[] {
            "ELECTROMECANICA",
            "ELECTRONICA",
            "AUTOMOTORES"});
            this.cmbp1.Location = new System.Drawing.Point(106, 151);
            this.cmbp1.Name = "cmbp1";
            this.cmbp1.Size = new System.Drawing.Size(121, 21);
            this.cmbp1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "PRIORIDAD 1:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(453, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(311, 24);
            this.label10.TabIndex = 40;
            this.label10.Text = "E.E.S.T Nº5 - LOMAS DE ZAMORA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(406, 24);
            this.label9.TabIndex = 39;
            this.label9.Text = "INSCRIPCION 4to AÑO - CICLO LECTIVO 2026";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbcurso);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbcurso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.ComboBox cmbp3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbldni;
        private System.Windows.Forms.Label lblcurso;
        private System.Windows.Forms.ComboBox cmbp2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbp1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

