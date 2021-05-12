
namespace TP2_Grupo4.Views
{
    partial class VistaUsuario
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
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.groupBoxHoteles = new System.Windows.Forms.GroupBox();
            this.checkBoxBloqueado = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnTopModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblPrecioPorPersona = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBoxHoteles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsuarios.Location = new System.Drawing.Point(390, 7);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(219, 45);
            this.lblUsuarios.TabIndex = 0;
            this.lblUsuarios.Text = "USUARIOS";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 174);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowTemplate.Height = 25;
            this.dgvUsuarios.Size = new System.Drawing.Size(976, 376);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // groupBoxHoteles
            // 
            this.groupBoxHoteles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.groupBoxHoteles.Controls.Add(this.checkBoxBloqueado);
            this.groupBoxHoteles.Controls.Add(this.txtEmail);
            this.groupBoxHoteles.Controls.Add(this.txtNombre);
            this.groupBoxHoteles.Controls.Add(this.btnTopModificar);
            this.groupBoxHoteles.Controls.Add(this.lblPrecioPorPersona);
            this.groupBoxHoteles.Controls.Add(this.lblBarrio);
            this.groupBoxHoteles.Controls.Add(this.lblNombre);
            this.groupBoxHoteles.Controls.Add(this.lblDni);
            this.groupBoxHoteles.Controls.Add(this.txtPassword);
            this.groupBoxHoteles.Controls.Add(this.checkBoxAdmin);
            this.groupBoxHoteles.Controls.Add(this.txtDni);
            this.groupBoxHoteles.ForeColor = System.Drawing.Color.Black;
            this.groupBoxHoteles.Location = new System.Drawing.Point(84, 51);
            this.groupBoxHoteles.Name = "groupBoxHoteles";
            this.groupBoxHoteles.Size = new System.Drawing.Size(842, 117);
            this.groupBoxHoteles.TabIndex = 3;
            this.groupBoxHoteles.TabStop = false;
            this.groupBoxHoteles.Text = "Modificar";
            // 
            // checkBoxBloqueado
            // 
            this.checkBoxBloqueado.AutoSize = true;
            this.checkBoxBloqueado.Location = new System.Drawing.Point(518, 71);
            this.checkBoxBloqueado.Name = "checkBoxBloqueado";
            this.checkBoxBloqueado.Size = new System.Drawing.Size(83, 19);
            this.checkBoxBloqueado.TabIndex = 17;
            this.checkBoxBloqueado.Text = "Bloqueado";
            this.checkBoxBloqueado.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(296, 34);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(175, 23);
            this.txtEmail.TabIndex = 16;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(70, 72);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(129, 23);
            this.txtNombre.TabIndex = 15;
            // 
            // btnTopModificar
            // 
            this.btnTopModificar.BackColor = System.Drawing.Color.White;
            this.btnTopModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopModificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTopModificar.Location = new System.Drawing.Point(658, 38);
            this.btnTopModificar.Name = "btnTopModificar";
            this.btnTopModificar.Size = new System.Drawing.Size(114, 57);
            this.btnTopModificar.TabIndex = 14;
            this.btnTopModificar.Text = "Modificar";
            this.btnTopModificar.UseVisualStyleBackColor = false;
            this.btnTopModificar.Click += new System.EventHandler(this.btnTopModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(841, 12);
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
            this.lblPrecioPorPersona.Location = new System.Drawing.Point(233, 75);
            this.lblPrecioPorPersona.Name = "lblPrecioPorPersona";
            this.lblPrecioPorPersona.Size = new System.Drawing.Size(57, 15);
            this.lblPrecioPorPersona.TabIndex = 12;
            this.lblPrecioPorPersona.Text = "Password";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(233, 37);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(36, 15);
            this.lblBarrio.TabIndex = 9;
            this.lblBarrio.Text = "Email";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(13, 75);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(18, 37);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(27, 15);
            this.lblDni.TabIndex = 7;
            this.lblDni.Text = "DNI";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(296, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(175, 23);
            this.txtPassword.TabIndex = 6;
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(518, 38);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(62, 19);
            this.checkBoxAdmin.TabIndex = 5;
            this.checkBoxAdmin.Text = "Admin";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(70, 34);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(129, 23);
            this.txtDni.TabIndex = 0;
            // 
            // VistaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.groupBoxHoteles);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUsuario";
            this.Load += new System.EventHandler(this.VistaUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBoxHoteles.ResumeLayout(false);
            this.groupBoxHoteles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox groupBoxHoteles;
        private System.Windows.Forms.Button btnTopModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblPrecioPorPersona;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox checkBoxBloqueado;
    }
}