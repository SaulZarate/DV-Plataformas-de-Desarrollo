
namespace TP2_Grupo4.Views
{
    partial class VistaHoteles
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
            this.lblHoteles = new System.Windows.Forms.Label();
            this.dgvHoteles = new System.Windows.Forms.DataGridView();
            this.groupBoxHoteles = new System.Windows.Forms.GroupBox();
            this.btnTopModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblPrecioPorPersona = new System.Windows.Forms.Label();
            this.lblCantDePersonas = new System.Windows.Forms.Label();
            this.lblEstrellas = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtPrecioPorPersona = new System.Windows.Forms.TextBox();
            this.checkBoxTV = new System.Windows.Forms.CheckBox();
            this.comboBoxCantPersonas = new System.Windows.Forms.ComboBox();
            this.comboBoxEstrellas = new System.Windows.Forms.ComboBox();
            this.comboBoxBarrio = new System.Windows.Forms.ComboBox();
            this.comboBoxCiudad = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panelHoteles = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoteles)).BeginInit();
            this.groupBoxHoteles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHoteles
            // 
            this.lblHoteles.AutoSize = true;
            this.lblHoteles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.lblHoteles.ForeColor = System.Drawing.Color.Black;
            this.lblHoteles.Location = new System.Drawing.Point(498, 37);
            this.lblHoteles.Name = "lblHoteles";
            this.lblHoteles.Size = new System.Drawing.Size(54, 15);
            this.lblHoteles.TabIndex = 0;
            this.lblHoteles.Text = "HOTELES";
            // 
            // dgvHoteles
            // 
            this.dgvHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoteles.Location = new System.Drawing.Point(12, 263);
            this.dgvHoteles.Name = "dgvHoteles";
            this.dgvHoteles.RowTemplate.Height = 25;
            this.dgvHoteles.Size = new System.Drawing.Size(976, 287);
            this.dgvHoteles.TabIndex = 1;
            this.dgvHoteles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoteles_CellContentClick);
            // 
            // groupBoxHoteles
            // 
            this.groupBoxHoteles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.groupBoxHoteles.Controls.Add(this.btnTopModificar);
            this.groupBoxHoteles.Controls.Add(this.btnAgregar);
            this.groupBoxHoteles.Controls.Add(this.lblPrecioPorPersona);
            this.groupBoxHoteles.Controls.Add(this.lblCantDePersonas);
            this.groupBoxHoteles.Controls.Add(this.lblEstrellas);
            this.groupBoxHoteles.Controls.Add(this.lblBarrio);
            this.groupBoxHoteles.Controls.Add(this.lblCiudad);
            this.groupBoxHoteles.Controls.Add(this.lblCodigo);
            this.groupBoxHoteles.Controls.Add(this.txtPrecioPorPersona);
            this.groupBoxHoteles.Controls.Add(this.checkBoxTV);
            this.groupBoxHoteles.Controls.Add(this.comboBoxCantPersonas);
            this.groupBoxHoteles.Controls.Add(this.comboBoxEstrellas);
            this.groupBoxHoteles.Controls.Add(this.comboBoxBarrio);
            this.groupBoxHoteles.Controls.Add(this.comboBoxCiudad);
            this.groupBoxHoteles.Controls.Add(this.txtCodigo);
            this.groupBoxHoteles.ForeColor = System.Drawing.Color.Black;
            this.groupBoxHoteles.Location = new System.Drawing.Point(148, 65);
            this.groupBoxHoteles.Name = "groupBoxHoteles";
            this.groupBoxHoteles.Size = new System.Drawing.Size(751, 172);
            this.groupBoxHoteles.TabIndex = 2;
            this.groupBoxHoteles.TabStop = false;
            this.groupBoxHoteles.Text = "Agregar";
            // 
            // btnTopModificar
            // 
            this.btnTopModificar.BackColor = System.Drawing.Color.White;
            this.btnTopModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopModificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTopModificar.Location = new System.Drawing.Point(605, 126);
            this.btnTopModificar.Name = "btnTopModificar";
            this.btnTopModificar.Size = new System.Drawing.Size(114, 25);
            this.btnTopModificar.TabIndex = 14;
            this.btnTopModificar.Text = "Modificar";
            this.btnTopModificar.UseVisualStyleBackColor = false;
            this.btnTopModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(605, 126);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 25);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblPrecioPorPersona
            // 
            this.lblPrecioPorPersona.AutoSize = true;
            this.lblPrecioPorPersona.Location = new System.Drawing.Point(532, 42);
            this.lblPrecioPorPersona.Name = "lblPrecioPorPersona";
            this.lblPrecioPorPersona.Size = new System.Drawing.Size(106, 15);
            this.lblPrecioPorPersona.TabIndex = 12;
            this.lblPrecioPorPersona.Text = "Precio por Persona";
            // 
            // lblCantDePersonas
            // 
            this.lblCantDePersonas.AutoSize = true;
            this.lblCantDePersonas.Location = new System.Drawing.Point(406, 80);
            this.lblCantDePersonas.Name = "lblCantDePersonas";
            this.lblCantDePersonas.Size = new System.Drawing.Size(98, 15);
            this.lblCantDePersonas.TabIndex = 11;
            this.lblCantDePersonas.Text = "Cant de Personas";
            // 
            // lblEstrellas
            // 
            this.lblEstrellas.AutoSize = true;
            this.lblEstrellas.Location = new System.Drawing.Point(405, 42);
            this.lblEstrellas.Name = "lblEstrellas";
            this.lblEstrellas.Size = new System.Drawing.Size(49, 15);
            this.lblEstrellas.TabIndex = 10;
            this.lblEstrellas.Text = "Estrellas";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(12, 80);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(38, 15);
            this.lblBarrio.TabIndex = 9;
            this.lblBarrio.Text = "Barrio";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(172, 42);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(45, 15);
            this.lblCiudad.TabIndex = 8;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 42);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 7;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtPrecioPorPersona
            // 
            this.txtPrecioPorPersona.Location = new System.Drawing.Point(644, 39);
            this.txtPrecioPorPersona.Name = "txtPrecioPorPersona";
            this.txtPrecioPorPersona.Size = new System.Drawing.Size(75, 23);
            this.txtPrecioPorPersona.TabIndex = 6;
            // 
            // checkBoxTV
            // 
            this.checkBoxTV.AutoSize = true;
            this.checkBoxTV.Location = new System.Drawing.Point(680, 81);
            this.checkBoxTV.Name = "checkBoxTV";
            this.checkBoxTV.Size = new System.Drawing.Size(39, 19);
            this.checkBoxTV.TabIndex = 5;
            this.checkBoxTV.Text = "TV";
            this.checkBoxTV.UseVisualStyleBackColor = true;
            // 
            // comboBoxCantPersonas
            // 
            this.comboBoxCantPersonas.FormattingEnabled = true;
            this.comboBoxCantPersonas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxCantPersonas.Location = new System.Drawing.Point(510, 77);
            this.comboBoxCantPersonas.Name = "comboBoxCantPersonas";
            this.comboBoxCantPersonas.Size = new System.Drawing.Size(99, 23);
            this.comboBoxCantPersonas.TabIndex = 4;
            // 
            // comboBoxEstrellas
            // 
            this.comboBoxEstrellas.FormattingEnabled = true;
            this.comboBoxEstrellas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxEstrellas.Location = new System.Drawing.Point(460, 39);
            this.comboBoxEstrellas.Name = "comboBoxEstrellas";
            this.comboBoxEstrellas.Size = new System.Drawing.Size(55, 23);
            this.comboBoxEstrellas.TabIndex = 3;
            // 
            // comboBoxBarrio
            // 
            this.comboBoxBarrio.FormattingEnabled = true;
            this.comboBoxBarrio.Location = new System.Drawing.Point(64, 77);
            this.comboBoxBarrio.Name = "comboBoxBarrio";
            this.comboBoxBarrio.Size = new System.Drawing.Size(121, 23);
            this.comboBoxBarrio.TabIndex = 2;
            // 
            // comboBoxCiudad
            // 
            this.comboBoxCiudad.FormattingEnabled = true;
            this.comboBoxCiudad.Location = new System.Drawing.Point(223, 39);
            this.comboBoxCiudad.Name = "comboBoxCiudad";
            this.comboBoxCiudad.Size = new System.Drawing.Size(91, 23);
            this.comboBoxCiudad.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(64, 39);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(82, 23);
            this.txtCodigo.TabIndex = 0;
            // 
            // panelHoteles
            // 
            this.panelHoteles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panelHoteles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHoteles.Location = new System.Drawing.Point(0, 0);
            this.panelHoteles.Name = "panelHoteles";
            this.panelHoteles.Size = new System.Drawing.Size(1000, 562);
            this.panelHoteles.TabIndex = 4;
            // 
            // VistaHoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.groupBoxHoteles);
            this.Controls.Add(this.dgvHoteles);
            this.Controls.Add(this.lblHoteles);
            this.Controls.Add(this.panelHoteles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaHoteles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHoteles";
            this.Load += new System.EventHandler(this.FormHoteles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoteles)).EndInit();
            this.groupBoxHoteles.ResumeLayout(false);
            this.groupBoxHoteles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHoteles;
        private System.Windows.Forms.DataGridView dgvHoteles;
        private System.Windows.Forms.GroupBox groupBoxHoteles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblPrecioPorPersona;
        private System.Windows.Forms.Label lblCantDePersonas;
        private System.Windows.Forms.Label lblEstrellas;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtPrecioPorPersona;
        private System.Windows.Forms.CheckBox checkBoxTV;
        private System.Windows.Forms.ComboBox comboBoxCantPersonas;
        private System.Windows.Forms.ComboBox comboBoxEstrellas;
        private System.Windows.Forms.ComboBox comboBoxBarrio;
        private System.Windows.Forms.ComboBox comboBoxCiudad;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnTopModificar;
        private System.Windows.Forms.Panel panelHoteles;
    }
}