using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Views
{
    public partial class VistaReservasCliente : Form
    {
        AgenciaManager reservas = new AgenciaManager();
        int num1;
        public VistaReservasCliente(AgenciaManager userLogged)
        {
            InitializeComponent();
            this.reservas = userLogged;
            int dni = userLogged.GetUsuarioLogeado().GetDni();
            num1 = dni;
        }

        private void VistaReservasCliente_Load(object sender, EventArgs e)
        {
            // Boton reservar
            var btnCancelar = new DataGridViewButtonColumn
            {
                Text = "CANCELAR",
                UseColumnTextForButtonValue = true,
                Name = "CANCELAR",
                DataPropertyName = "CANCELAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnCancelar.DefaultCellStyle.BackColor = Color.IndianRed;

            dgvReservaciones.Columns.Add("Codigo", "Código");
            dgvReservaciones.Columns.Add("Fecha Inicio", "Fecha Inicio");
            dgvReservaciones.Columns.Add("Fecha Fin", "Fecha Fin");
            //dgvReservaciones.Columns.Add("Usuario", "Usuario");
            dgvReservaciones.Columns.Add("Precio", "Precio");

            dgvReservaciones.Columns.Add(btnCancelar);
            dgvReservaciones.ReadOnly = false;
            getTextReservaciones();
        }
        private void getTextReservaciones()
        {
            List<Reserva> reservaciones = this.reservas.GetAllReservasForUsuario(num1);
            foreach (Reserva reservacion in reservaciones)
            {
                this.dgvReservaciones.Rows.Add(
                    reservacion.GetId(),
                    reservacion.GetFechaDesde(),
                    reservacion.GetFechaHasta(),
                    //num1,
                    reservacion.GetPrecio()
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacemos click en Button CANCELAR
            if (dgvReservaciones.Columns[e.ColumnIndex].Name == "CANCELAR")
            {
                if (MessageBox.Show("Estas seguro que quieres cancelar este alojamiento?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvReservaciones.CurrentCell.RowIndex;
                    // Codigo del Alojamiento
                    int codigo = Int32.Parse(dgvReservaciones.Rows[rowIndex].Cells["Codigo"].Value.ToString());
                    // Eliminar reserva
                    this.reservas.EliminarReserva((codigo).ToString());
                    // Guardar Datos
                    this.reservas.GuardarCambiosDeLasReservas();

                    // Actualizar GridView
                    this.dgvReservaciones.Rows.Clear();
                    getTextReservaciones();
                }
            }
        }
    }
}
