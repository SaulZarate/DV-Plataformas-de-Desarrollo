using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4.Views
{
    public partial class VistaReservasCliente : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaReservasCliente(AgenciaManager userLogged)
        {
            InitializeComponent();
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
            btnCancelar.DefaultCellStyle.BackColor = Color.Green;

            dgvReservaciones.Columns.Add("Codigo", "Código");
            dgvReservaciones.Columns.Add("Fecha Inicio", "Fecha Inicio");
            dgvReservaciones.Columns.Add("Fecha Fin", "Fecha Fin");
            dgvReservaciones.Columns.Add("Usuario", "Usuario");
            dgvReservaciones.Columns.Add("Precio", "Precio");

            dgvReservaciones.Columns.Add(btnCancelar);
            dgvReservaciones.ReadOnly = false;
            getTextAlojamientos();
        }
        private void getTextAlojamientos()
        {
            List<Reserva> reservaciones = this.reservas
            foreach (Reserva reservacion in reservaciones)
            {
                this.dgvReservaciones.Rows.Add(
                    reservacion.GetCodigo(),
                    reservacion.GetCiudad(),
                    reservacion.GetBarrio(),
                    reservacion.GetEstrellas(),
                    reservacion.GetCantidadDePersonas(),
                    reservacion.GetTv(),
                    reservacion.PrecioTotalDelAlojamiento()
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime date1 = DateTime.Now;

            //var date2 = new DateTime(2008, 5, 2, 8, 1, 1);
            //DateTime date2 = Convert.ToDateTime("2017-12-24 13:30:15");
            DateTime date2 = DateTime.Now;
            // Utilizamos el método AddDays para sumar 10 días:
            date2 = date2.AddDays(7);

            // Si hacemos click en Button RESERVAR
            if (dgvAlojamiento.Columns[e.ColumnIndex].Name == "RESERVAR")
            {
                if (MessageBox.Show("Estas seguro que quieres reservar este alojamiento?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvAlojamiento.CurrentCell.RowIndex;
                    // Codigo del Alojamiento
                    int codigo = Int32.Parse(dgvAlojamiento.Rows[rowIndex].Cells["Codigo"].Value.ToString());

                    // Guardar Datos
                    //int dni = agencia.GetUsuarioLogeado().GetDni();
                    // FALTA PONER LA FECHA Y EL USUARIO DE MANERA CORRECTA
                    this.agencia.AgregarReserva(date1, date2, codigo, num1);//agencia.GetUsuarioLogeado().GetDni() //40393222
                    this.agencia.GuardarCambiosDeLasReservas();

                    // Actualizar GridView
                    this.dgvAlojamiento.Rows.Clear();
                    getTextAlojamientos();
                }
            }
        }
    }
}
