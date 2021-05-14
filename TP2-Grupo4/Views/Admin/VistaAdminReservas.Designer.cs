
namespace TP2_Grupo4.Views
{
    partial class VistaAdminReservas
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
            this.lblReservas = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxHasta = new System.Windows.Forms.TextBox();
            this.textBoxDesde = new System.Windows.Forms.TextBox();
            this.textBoxAloja = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.Precio = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.TBDesde = new System.Windows.Forms.Label();
            this.Estrellas = new System.Windows.Forms.Label();
            this.Localidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Modificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReservas
            // 
            this.lblReservas.AutoSize = true;
            this.lblReservas.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReservas.Location = new System.Drawing.Point(406, 7);
            this.lblReservas.Name = "lblReservas";
            this.lblReservas.Size = new System.Drawing.Size(188, 45);
            this.lblReservas.TabIndex = 0;
            this.lblReservas.Text = "Reservas";
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(12, 174);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.RowTemplate.Height = 25;
            this.dgvReservas.Size = new System.Drawing.Size(976, 376);
            this.dgvReservas.TabIndex = 1;
            this.dgvReservas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservas_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxHasta);
            this.groupBox1.Controls.Add(this.textBoxDesde);
            this.groupBox1.Controls.Add(this.textBoxAloja);
            this.groupBox1.Controls.Add(this.textBoxPrecio);
            this.groupBox1.Controls.Add(this.textBoxID);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.Precio);
            this.groupBox1.Controls.Add(this.textBoxUsuario);
            this.groupBox1.Controls.Add(this.TBDesde);
            this.groupBox1.Controls.Add(this.Estrellas);
            this.groupBox1.Controls.Add(this.Localidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Modificar);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(84, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenamiento";
            // 
            // textBoxHasta
            // 
            this.textBoxHasta.Location = new System.Drawing.Point(326, 74);
            this.textBoxHasta.Name = "textBoxHasta";
            this.textBoxHasta.Size = new System.Drawing.Size(100, 23);
            this.textBoxHasta.TabIndex = 10;
            // 
            // textBoxDesde
            // 
            this.textBoxDesde.Location = new System.Drawing.Point(326, 26);
            this.textBoxDesde.Name = "textBoxDesde";
            this.textBoxDesde.Size = new System.Drawing.Size(100, 23);
            this.textBoxDesde.TabIndex = 9;
            // 
            // textBoxAloja
            // 
            this.textBoxAloja.Enabled = false;
            this.textBoxAloja.Location = new System.Drawing.Point(115, 29);
            this.textBoxAloja.Name = "textBoxAloja";
            this.textBoxAloja.Size = new System.Drawing.Size(120, 23);
            this.textBoxAloja.TabIndex = 8;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Enabled = false;
            this.textBoxPrecio.Location = new System.Drawing.Point(531, 29);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrecio.TabIndex = 3;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(531, 74);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 23);
            this.textBoxID.TabIndex = 6;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(464, 77);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(64, 15);
            this.ID.TabIndex = 0;
            this.ID.Text = "ID Reserva:";
            this.ID.Click += new System.EventHandler(this.ID_Click);
            // 
            // Precio
            // 
            this.Precio.AutoSize = true;
            this.Precio.Location = new System.Drawing.Point(482, 29);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(43, 15);
            this.Precio.TabIndex = 0;
            this.Precio.Text = "Precio:";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Enabled = false;
            this.textBoxUsuario.Location = new System.Drawing.Point(114, 74);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(121, 23);
            this.textBoxUsuario.TabIndex = 4;
            // 
            // TBDesde
            // 
            this.TBDesde.AutoSize = true;
            this.TBDesde.Location = new System.Drawing.Point(278, 29);
            this.TBDesde.Name = "TBDesde";
            this.TBDesde.Size = new System.Drawing.Size(42, 15);
            this.TBDesde.TabIndex = 0;
            this.TBDesde.Text = "Desde:";
            // 
            // Estrellas
            // 
            this.Estrellas.AutoSize = true;
            this.Estrellas.Location = new System.Drawing.Point(278, 77);
            this.Estrellas.Name = "Estrellas";
            this.Estrellas.Size = new System.Drawing.Size(40, 15);
            this.Estrellas.TabIndex = 0;
            this.Estrellas.Text = "Hasta:";
            // 
            // Localidad
            // 
            this.Localidad.AutoSize = true;
            this.Localidad.Location = new System.Drawing.Point(78, 77);
            this.Localidad.Name = "Localidad";
            this.Localidad.Size = new System.Drawing.Size(30, 15);
            this.Localidad.TabIndex = 0;
            this.Localidad.Text = "DNI:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Alojamiento:";
            this.label1.Click += new System.EventHandler(this.TBTipo);
            // 
            // Modificar
            // 
            this.Modificar.BackColor = System.Drawing.Color.White;
            this.Modificar.Enabled = false;
            this.Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modificar.ForeColor = System.Drawing.Color.Black;
            this.Modificar.Location = new System.Drawing.Point(691, 59);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(106, 51);
            this.Modificar.TabIndex = 7;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = false;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // VistaAdminReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.lblReservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaAdminReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReservas";
            this.Load += new System.EventHandler(this.VistaAdminReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReservas;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label Precio;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label TBDesde;
        private System.Windows.Forms.Label Estrellas;
        private System.Windows.Forms.Label Localidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.TextBox textBoxHasta;
        private System.Windows.Forms.TextBox textBoxDesde;
        private System.Windows.Forms.TextBox textBoxAloja;
    }
}