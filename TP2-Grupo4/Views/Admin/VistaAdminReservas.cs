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
    public partial class VistaAdminReservas : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaAdminReservas()
        {
            InitializeComponent();
        }

        private void VistaAdminReservas_Load(object sender, EventArgs e)
        {
            var btnBorrar = new DataGridViewButtonColumn
            {
                HeaderText = "Borrar",
                Text = "BORRAR",
                UseColumnTextForButtonValue = true,
                Name = "BORRAR",
                DataPropertyName = "BORRAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnBorrar.DefaultCellStyle.BackColor = Color.IndianRed;

            // Boton modificar
            var btnModificar = new DataGridViewButtonColumn
            {
                HeaderText = "Modificar",
                Text = "MODIFICAR",
                UseColumnTextForButtonValue = true,
                Name = "MODIFICAR",
                FlatStyle = FlatStyle.Flat,

            };
            btnModificar.DefaultCellStyle.BackColor = Color.LightYellow;

            dgvReservas.Columns.Add("ID", "idReserva");
            dgvReservas.Columns.Add("DESDE", "Desde");
            dgvReservas.Columns.Add("HASTA", "Hasta");
            dgvReservas.Columns.Add("IDALOJAMIENTO", "Id Alojamiento");
            dgvReservas.Columns.Add("USUARIO", "Usuario");
            dgvReservas.Columns.Add("PRECIO", "Precio Total");
            dgvReservas.Columns.Add(btnModificar);
            dgvReservas.Columns.Add(btnBorrar);
            dgvReservas.ReadOnly = true;
            getReservasFromTextFile();
        }
        private void getReservasFromTextFile()
        {
            // Limpiamos el GridView
            dgvReservas.Rows.Clear();

            List<Reserva> reservas = this.agencia.GetReservas();


            foreach (Reserva reserva in reservas)
            {

                this.dgvReservas.Rows.Add(
                    reserva.GetId(),
                    reserva.GetFechaDesde(),
                    reserva.GetFechaHasta(),
                    reserva.GetAlojamiento().GetCodigo(),
                    reserva.GetUsuario().GetDni(),
                    reserva.GetPrecio()
                );
            }

            // Update y Regresheo de Grid
            dgvReservas.Update();
            dgvReservas.Refresh();
        }

        #region Buttons Click
        private void Modificar_Click(object sender, EventArgs e)
        {
            Modificar.Enabled = false;
            String id = textBoxID.Text;
            DateTime desde = DateTime.Parse(textBoxDesde.Text);
            DateTime hasta = DateTime.Parse(textBoxHasta.Text);
            int idAloja = Int32.Parse(textBoxAloja.Text);
            int dni = Int32.Parse(textBoxUsuario.Text);
            this.agencia.ModificarReserva(id, desde, hasta, idAloja, dni);
            this.agencia.GuardarCambiosDeLasReservas();

            clearAllControls();
            getReservasFromTextFile();
        }
        private void ButtonBorrar_Click(object sender, EventArgs e)
        {
            String id = textBoxID.Text;

            this.agencia.EliminarReserva(id);
            clearAllControls();
        }
        #endregion

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacemos click en Button BORRAR
            if (dgvReservas.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar esta reserva?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvReservas.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    String codigo = dgvReservas.Rows[rowIndex].Cells["ID"].Value.ToString();

                    // Borrado
                    dgvReservas.Rows.RemoveAt(rowIndex);

                    this.agencia.EliminarReserva(codigo);
                    this.agencia.GuardarCambiosDeLasReservas();

                    // Actualizar GridView
                    getReservasFromTextFile();
                }
            }

            if (dgvReservas.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar esta reserva?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Modificar.Enabled = true;
                    rellenarDatos();
                }
            }

        }

        #region Helpers
        private void rellenarDatos()
        {
            textBoxID.Text = dgvReservas.CurrentRow.Cells[0].Value.ToString();
            textBoxDesde.Text = dgvReservas.CurrentRow.Cells[1].Value.ToString();
            textBoxHasta.Text = dgvReservas.CurrentRow.Cells[2].Value.ToString();
            textBoxAloja.Text = dgvReservas.CurrentRow.Cells[3].Value.ToString();
            textBoxUsuario.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();
            textBoxPrecio.Text = dgvReservas.CurrentRow.Cells[5].Value.ToString();

        }
        private void clearAllControls()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;

                }
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;

                    comboBox.Text = "";
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
            }
        }
        #endregion

    }

}
