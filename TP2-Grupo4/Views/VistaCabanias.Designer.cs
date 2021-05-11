
namespace TP2_Grupo4.Views
{
    partial class VistaCabanias
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
            this.lblCabanias = new System.Windows.Forms.Label();
            this.dgvCabanias = new System.Windows.Forms.DataGridView();
            this.groupBoxCabanias = new System.Windows.Forms.GroupBox();
            this.lblCantPersonas = new System.Windows.Forms.Label();
            this.comboBoxCantPersonas = new System.Windows.Forms.ComboBox();
            this.btnTopModificar = new System.Windows.Forms.Button();
            this.btnTopAgregar = new System.Windows.Forms.Button();
            this.lblBanios = new System.Windows.Forms.Label();
            this.lblHabitaciones = new System.Windows.Forms.Label();
            this.comboBoxBanios = new System.Windows.Forms.ComboBox();
            this.comboBoxHabitaciones = new System.Windows.Forms.ComboBox();
            this.lblPrecioPorDia = new System.Windows.Forms.Label();
            this.lblEstrellas = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtPrecioPorDia = new System.Windows.Forms.TextBox();
            this.checkBoxTV = new System.Windows.Forms.CheckBox();
            this.comboBoxEstrellas = new System.Windows.Forms.ComboBox();
            this.comboBoxBarrio = new System.Windows.Forms.ComboBox();
            this.comboBoxCiudad = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabanias)).BeginInit();
            this.groupBoxCabanias.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCabanias
            // 
            this.lblCabanias.AutoSize = true;
            this.lblCabanias.Location = new System.Drawing.Point(482, 20);
            this.lblCabanias.Name = "lblCabanias";
            this.lblCabanias.Size = new System.Drawing.Size(61, 15);
            this.lblCabanias.TabIndex = 0;
            this.lblCabanias.Text = "CABAÑAS";
            // 
            // dgvCabanias
            // 
            this.dgvCabanias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabanias.Location = new System.Drawing.Point(12, 198);
            this.dgvCabanias.Name = "dgvCabanias";
            this.dgvCabanias.RowTemplate.Height = 25;
            this.dgvCabanias.Size = new System.Drawing.Size(976, 352);
            this.dgvCabanias.TabIndex = 1;
            this.dgvCabanias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCabanias_CellContentClick);
            // 
            // groupBoxCabanias
            // 
            this.groupBoxCabanias.Controls.Add(this.lblCantPersonas);
            this.groupBoxCabanias.Controls.Add(this.comboBoxCantPersonas);
            this.groupBoxCabanias.Controls.Add(this.btnTopModificar);
            this.groupBoxCabanias.Controls.Add(this.btnTopAgregar);
            this.groupBoxCabanias.Controls.Add(this.lblBanios);
            this.groupBoxCabanias.Controls.Add(this.lblHabitaciones);
            this.groupBoxCabanias.Controls.Add(this.comboBoxBanios);
            this.groupBoxCabanias.Controls.Add(this.comboBoxHabitaciones);
            this.groupBoxCabanias.Controls.Add(this.lblPrecioPorDia);
            this.groupBoxCabanias.Controls.Add(this.lblEstrellas);
            this.groupBoxCabanias.Controls.Add(this.lblBarrio);
            this.groupBoxCabanias.Controls.Add(this.lblCiudad);
            this.groupBoxCabanias.Controls.Add(this.lblCodigo);
            this.groupBoxCabanias.Controls.Add(this.txtPrecioPorDia);
            this.groupBoxCabanias.Controls.Add(this.checkBoxTV);
            this.groupBoxCabanias.Controls.Add(this.comboBoxEstrellas);
            this.groupBoxCabanias.Controls.Add(this.comboBoxBarrio);
            this.groupBoxCabanias.Controls.Add(this.comboBoxCiudad);
            this.groupBoxCabanias.Controls.Add(this.txtCodigo);
            this.groupBoxCabanias.Location = new System.Drawing.Point(143, 48);
            this.groupBoxCabanias.Name = "groupBoxCabanias";
            this.groupBoxCabanias.Size = new System.Drawing.Size(752, 144);
            this.groupBoxCabanias.TabIndex = 2;
            this.groupBoxCabanias.TabStop = false;
            this.groupBoxCabanias.Text = "Cabañas";
            // 
            // lblCantPersonas
            // 
            this.lblCantPersonas.AutoSize = true;
            this.lblCantPersonas.Location = new System.Drawing.Point(462, 69);
            this.lblCantPersonas.Name = "lblCantPersonas";
            this.lblCantPersonas.Size = new System.Drawing.Size(54, 15);
            this.lblCantPersonas.TabIndex = 31;
            this.lblCantPersonas.Text = "Personas";
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
            this.comboBoxCantPersonas.Location = new System.Drawing.Point(522, 64);
            this.comboBoxCantPersonas.Name = "comboBoxCantPersonas";
            this.comboBoxCantPersonas.Size = new System.Drawing.Size(55, 23);
            this.comboBoxCantPersonas.TabIndex = 30;
            // 
            // btnTopModificar
            // 
            this.btnTopModificar.BackColor = System.Drawing.Color.White;
            this.btnTopModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopModificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTopModificar.Location = new System.Drawing.Point(617, 103);
            this.btnTopModificar.Name = "btnTopModificar";
            this.btnTopModificar.Size = new System.Drawing.Size(114, 25);
            this.btnTopModificar.TabIndex = 28;
            this.btnTopModificar.Text = "Modificar";
            this.btnTopModificar.UseVisualStyleBackColor = false;
            this.btnTopModificar.Click += new System.EventHandler(this.btnTopModificar_Click);
            // 
            // btnTopAgregar
            // 
            this.btnTopAgregar.BackColor = System.Drawing.Color.White;
            this.btnTopAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTopAgregar.Location = new System.Drawing.Point(617, 103);
            this.btnTopAgregar.Name = "btnTopAgregar";
            this.btnTopAgregar.Size = new System.Drawing.Size(114, 25);
            this.btnTopAgregar.TabIndex = 29;
            this.btnTopAgregar.Text = "Agregar";
            this.btnTopAgregar.UseVisualStyleBackColor = false;
            this.btnTopAgregar.Click += new System.EventHandler(this.btnTopAgregar_Click);
            // 
            // lblBanios
            // 
            this.lblBanios.AutoSize = true;
            this.lblBanios.Location = new System.Drawing.Point(583, 68);
            this.lblBanios.Name = "lblBanios";
            this.lblBanios.Size = new System.Drawing.Size(39, 15);
            this.lblBanios.TabIndex = 27;
            this.lblBanios.Text = "Baños";
            // 
            // lblHabitaciones
            // 
            this.lblHabitaciones.AutoSize = true;
            this.lblHabitaciones.Location = new System.Drawing.Point(417, 26);
            this.lblHabitaciones.Name = "lblHabitaciones";
            this.lblHabitaciones.Size = new System.Drawing.Size(76, 15);
            this.lblHabitaciones.TabIndex = 26;
            this.lblHabitaciones.Text = "Habitaciones";
            // 
            // comboBoxBanios
            // 
            this.comboBoxBanios.FormattingEnabled = true;
            this.comboBoxBanios.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxBanios.Location = new System.Drawing.Point(628, 64);
            this.comboBoxBanios.Name = "comboBoxBanios";
            this.comboBoxBanios.Size = new System.Drawing.Size(45, 23);
            this.comboBoxBanios.TabIndex = 25;
            // 
            // comboBoxHabitaciones
            // 
            this.comboBoxHabitaciones.FormattingEnabled = true;
            this.comboBoxHabitaciones.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxHabitaciones.Location = new System.Drawing.Point(499, 22);
            this.comboBoxHabitaciones.Name = "comboBoxHabitaciones";
            this.comboBoxHabitaciones.Size = new System.Drawing.Size(55, 23);
            this.comboBoxHabitaciones.TabIndex = 24;
            // 
            // lblPrecioPorDia
            // 
            this.lblPrecioPorDia.AutoSize = true;
            this.lblPrecioPorDia.Location = new System.Drawing.Point(560, 25);
            this.lblPrecioPorDia.Name = "lblPrecioPorDia";
            this.lblPrecioPorDia.Size = new System.Drawing.Size(81, 15);
            this.lblPrecioPorDia.TabIndex = 23;
            this.lblPrecioPorDia.Text = "Precio por Dia";
            // 
            // lblEstrellas
            // 
            this.lblEstrellas.AutoSize = true;
            this.lblEstrellas.Location = new System.Drawing.Point(346, 67);
            this.lblEstrellas.Name = "lblEstrellas";
            this.lblEstrellas.Size = new System.Drawing.Size(49, 15);
            this.lblEstrellas.TabIndex = 22;
            this.lblEstrellas.Text = "Estrellas";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(24, 63);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(38, 15);
            this.lblBarrio.TabIndex = 21;
            this.lblBarrio.Text = "Barrio";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(184, 25);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(45, 15);
            this.lblCiudad.TabIndex = 20;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 19;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtPrecioPorDia
            // 
            this.txtPrecioPorDia.Location = new System.Drawing.Point(656, 22);
            this.txtPrecioPorDia.Name = "txtPrecioPorDia";
            this.txtPrecioPorDia.Size = new System.Drawing.Size(75, 23);
            this.txtPrecioPorDia.TabIndex = 18;
            // 
            // checkBoxTV
            // 
            this.checkBoxTV.AutoSize = true;
            this.checkBoxTV.Location = new System.Drawing.Point(692, 68);
            this.checkBoxTV.Name = "checkBoxTV";
            this.checkBoxTV.Size = new System.Drawing.Size(39, 19);
            this.checkBoxTV.TabIndex = 17;
            this.checkBoxTV.Text = "TV";
            this.checkBoxTV.UseVisualStyleBackColor = true;
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
            this.comboBoxEstrellas.Location = new System.Drawing.Point(401, 64);
            this.comboBoxEstrellas.Name = "comboBoxEstrellas";
            this.comboBoxEstrellas.Size = new System.Drawing.Size(55, 23);
            this.comboBoxEstrellas.TabIndex = 16;
            // 
            // comboBoxBarrio
            // 
            this.comboBoxBarrio.FormattingEnabled = true;
            this.comboBoxBarrio.Location = new System.Drawing.Point(76, 60);
            this.comboBoxBarrio.Name = "comboBoxBarrio";
            this.comboBoxBarrio.Size = new System.Drawing.Size(121, 23);
            this.comboBoxBarrio.TabIndex = 15;
            // 
            // comboBoxCiudad
            // 
            this.comboBoxCiudad.FormattingEnabled = true;
            this.comboBoxCiudad.Location = new System.Drawing.Point(235, 22);
            this.comboBoxCiudad.Name = "comboBoxCiudad";
            this.comboBoxCiudad.Size = new System.Drawing.Size(91, 23);
            this.comboBoxCiudad.TabIndex = 14;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(76, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(82, 23);
            this.txtCodigo.TabIndex = 13;
            // 
            // VistaCabanias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.groupBoxCabanias);
            this.Controls.Add(this.dgvCabanias);
            this.Controls.Add(this.lblCabanias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaCabanias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCabanias";
            this.Load += new System.EventHandler(this.FormCabanias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabanias)).EndInit();
            this.groupBoxCabanias.ResumeLayout(false);
            this.groupBoxCabanias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCabanias;
        private System.Windows.Forms.DataGridView dgvCabanias;
        private System.Windows.Forms.GroupBox groupBoxCabanias;
        private System.Windows.Forms.Label lblPrecioPorDia;
        private System.Windows.Forms.Label lblEstrellas;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtPrecioPorDia;
        private System.Windows.Forms.CheckBox checkBoxTV;
        private System.Windows.Forms.ComboBox comboBoxEstrellas;
        private System.Windows.Forms.ComboBox comboBoxBarrio;
        private System.Windows.Forms.ComboBox comboBoxCiudad;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblBanios;
        private System.Windows.Forms.Label lblHabitaciones;
        private System.Windows.Forms.ComboBox comboBoxBanios;
        private System.Windows.Forms.ComboBox comboBoxHabitaciones;
        private System.Windows.Forms.Button btnTopModificar;
        private System.Windows.Forms.Button btnTopAgregar;
        private System.Windows.Forms.Label lblCantPersonas;
        private System.Windows.Forms.ComboBox comboBoxCantPersonas;
    }
}