
namespace TP2_Grupo4.Views
{
    partial class VistaDashboardCliente
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnReservas = new FontAwesome.Sharp.IconButton();
            this.btnAlojamiento = new FontAwesome.Sharp.IconButton();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.lblRoleUser = new System.Windows.Forms.Label();
            this.pbUserRole = new FontAwesome.Sharp.IconPictureBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelRole = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserRole)).BeginInit();
            this.panelRole.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.btnReservas);
            this.panelMenu.Controls.Add(this.btnAlojamiento);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 640);
            this.panelMenu.TabIndex = 1;
            // 
            // btnReservas
            // 
            this.btnReservas.AutoSize = true;
            this.btnReservas.BackColor = System.Drawing.Color.White;
            this.btnReservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReservas.FlatAppearance.BorderSize = 0;
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.ForeColor = System.Drawing.Color.Black;
            this.btnReservas.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            this.btnReservas.IconColor = System.Drawing.Color.Black;
            this.btnReservas.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnReservas.IconSize = 32;
            this.btnReservas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservas.Location = new System.Drawing.Point(0, 248);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnReservas.Size = new System.Drawing.Size(220, 60);
            this.btnReservas.TabIndex = 2;
            this.btnReservas.Text = "Mis Reservaciones";
            this.btnReservas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservas.UseVisualStyleBackColor = false;
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // btnAlojamiento
            // 
            this.btnAlojamiento.AutoSize = true;
            this.btnAlojamiento.BackColor = System.Drawing.Color.White;
            this.btnAlojamiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlojamiento.FlatAppearance.BorderSize = 0;
            this.btnAlojamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlojamiento.ForeColor = System.Drawing.Color.Black;
            this.btnAlojamiento.IconChar = FontAwesome.Sharp.IconChar.Hotel;
            this.btnAlojamiento.IconColor = System.Drawing.Color.Black;
            this.btnAlojamiento.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnAlojamiento.IconSize = 32;
            this.btnAlojamiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlojamiento.Location = new System.Drawing.Point(0, 188);
            this.btnAlojamiento.Name = "btnAlojamiento";
            this.btnAlojamiento.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnAlojamiento.Size = new System.Drawing.Size(220, 60);
            this.btnAlojamiento.TabIndex = 1;
            this.btnAlojamiento.Text = "Buscar Alojamientos";
            this.btnAlojamiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlojamiento.UseVisualStyleBackColor = false;
            this.btnAlojamiento.Click += new System.EventHandler(this.btnAlojamiento_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.AutoSize = true;
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCerrarSesion.IconSize = 32;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 580);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(220, 60);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.panelDesktop);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 188);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::TP2_Grupo4.Properties.Resources.alojamientos;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.LightGray;
            this.panelDesktop.Location = new System.Drawing.Point(220, 76);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(613, 377);
            this.panelDesktop.TabIndex = 0;
            // 
            // lblRoleUser
            // 
            this.lblRoleUser.AutoSize = true;
            this.lblRoleUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRoleUser.Location = new System.Drawing.Point(91, 27);
            this.lblRoleUser.Name = "lblRoleUser";
            this.lblRoleUser.Size = new System.Drawing.Size(50, 15);
            this.lblRoleUser.TabIndex = 0;
            this.lblRoleUser.Text = "roleUser";
            // 
            // pbUserRole
            // 
            this.pbUserRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.pbUserRole.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.pbUserRole.IconColor = System.Drawing.Color.White;
            this.pbUserRole.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbUserRole.Location = new System.Drawing.Point(17, 21);
            this.pbUserRole.Name = "pbUserRole";
            this.pbUserRole.Size = new System.Drawing.Size(32, 32);
            this.pbUserRole.TabIndex = 1;
            this.pbUserRole.TabStop = false;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRole.Location = new System.Drawing.Point(52, 27);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(33, 15);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "role: ";
            // 
            // panelRole
            // 
            this.panelRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.panelRole.Controls.Add(this.panel2);
            this.panelRole.Controls.Add(this.flowLayoutPanel1);
            this.panelRole.Controls.Add(this.panel1);
            this.panelRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRole.Location = new System.Drawing.Point(0, 0);
            this.panelRole.Name = "panelRole";
            this.panelRole.Size = new System.Drawing.Size(1220, 640);
            this.panelRole.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.panel2.Controls.Add(this.pbUserRole);
            this.panel2.Controls.Add(this.lblRole);
            this.panel2.Controls.Add(this.lblRoleUser);
            this.panel2.Location = new System.Drawing.Point(220, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 79);
            this.panel2.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1178, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(42, 640);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 571);
            this.panel1.TabIndex = 3;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panelMain.Location = new System.Drawing.Point(220, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 571);
            this.panelMain.TabIndex = 0;
            // 
            // VistaDashboardCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 640);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaDashboardCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaDashboardCliente";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserRole)).EndInit();
            this.panelRole.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnReservas;
        private FontAwesome.Sharp.IconButton btnAlojamiento;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label lblRoleUser;
        private FontAwesome.Sharp.IconPictureBox pbUserRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel panelRole;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}