using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Views
{
    public partial class VistaHoteles : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaHoteles()
        {
            InitializeComponent();
        }

        private void FormHoteles_Load(object sender, EventArgs e)
        {
            // Boton borrar
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

            // Checkbox
            var checkTV = new DataGridViewCheckBoxColumn
            {
                HeaderText = "TV",
                Name = "TV"
            };


            // Tabla
            // TODO: Cambiar Ciudad, Barrio, Estrellas y Cant. personas por ComboBox
            dgvHoteles.Columns.Add("CODIGO", "Codigo");
            dgvHoteles.Columns.Add("CIUDAD", "Ciudad");
            dgvHoteles.Columns.Add("BARRIO", "Barrio");
            dgvHoteles.Columns.Add("ESTRELLAS", "Estrellas");
            dgvHoteles.Columns.Add("CANT_PERSONAS", "Personas");
            dgvHoteles.Columns.Add(checkTV);
            dgvHoteles.Columns.Add("PRECIO_X_PERSONA", "Precio x Persona");
            dgvHoteles.Columns.Add(btnModificar);
            dgvHoteles.Columns.Add(btnBorrar);

            dgvHoteles.ReadOnly = true;

            btnTopModificar.Visible = false;

            // Get hoteles de alojamientos.txt
            getHotelesFromTextFile();
        }

        private void getHotelesFromTextFile()
        {
            // Limpiamos el GridView
            dgvHoteles.Rows.Clear();

            List<Alojamiento> hoteles = this.agencia.GetAgencia().GetHoteles();

            foreach (Hotel hotel in hoteles)
            {
                this.dgvHoteles.Rows.Add(
                    hotel.GetCodigo().ToString(),
                    hotel.GetCiudad(),
                    hotel.GetBarrio(),
                    hotel.GetEstrellas(),
                    hotel.GetCantidadDePersonas().ToString(),
                    hotel.GetTv(),
                    "$" + hotel.PrecioTotalDelAlojamiento().ToString(),
                    hotel.GetPrecioPorPersona()
                );
            }

            // Update y Regresheo de Grid
            dgvHoteles.Update();
            dgvHoteles.Refresh();
        }

        #region Helper
        private void rellenarDatos()
        {
            txtCodigo.Text = dgvHoteles.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Enabled = false;
            comboBoxCiudad.Text = dgvHoteles.CurrentRow.Cells[1].Value.ToString();
            comboBoxBarrio.Text = dgvHoteles.CurrentRow.Cells[2].Value.ToString();
            comboBoxEstrellas.Text = dgvHoteles.CurrentRow.Cells[3].Value.ToString();
            comboBoxCantPersonas.Text = dgvHoteles.CurrentRow.Cells[4].Value.ToString();
            checkBoxTV.Checked = bool.Parse(dgvHoteles.CurrentRow.Cells[5].Value.ToString());
            txtPrecioPorPersona.Text = dgvHoteles.CurrentRow.Cells[6].Value.ToString();
        }

        // Resetear campos
        private void clearAllControls()
        {
            foreach (Control control in groupBoxHoteles.Controls)
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

        // Click en Contenido de la Celda
        private void dgvHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacemos click en Button BORRAR
            if (dgvHoteles.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvHoteles.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    int codigo = Int32.Parse(dgvHoteles.Rows[rowIndex].Cells["CODIGO"].Value.ToString());

                    // Borrado
                    dgvHoteles.Rows.RemoveAt(rowIndex);
                    this.agencia.GetAgencia().EliminarAlojamiento(codigo);
                    this.agencia.GetAgencia().GuardarCambiosEnElArchivo();

                    // Actualizar GridView
                    getHotelesFromTextFile();
                }
            }

            if (dgvHoteles.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnAgregar.Visible = false;
                    btnTopModificar.Visible = true;

                    rellenarDatos();
                }
            }

        }

        #region Button Click Events

        // onClick Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnAgregar.Visible = true;
            btnTopModificar.Visible = false;

            int codigo = Int32.Parse(txtCodigo.Text);
            string ciudad = comboBoxCiudad.Text;
            string barrio = comboBoxBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            double precioPersonas = double.Parse(txtPrecioPorPersona.Text);

            this.agencia.GetAgencia().ModificarAlojamiento(new Hotel(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas));
            this.agencia.GetAgencia().GuardarCambiosEnElArchivo();

            clearAllControls();
            getHotelesFromTextFile();
        }

        // onClick Boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = Int32.Parse(txtCodigo.Text);
            string ciudad = comboBoxCiudad.Text;
            string barrio = comboBoxBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            double precioPersonas = double.Parse(txtPrecioPorPersona.Text);

            this.agencia.GetAgencia().AgregarAlojamiento(new Hotel(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas));
            this.agencia.GetAgencia().GuardarCambiosEnElArchivo();
            clearAllControls();
            getHotelesFromTextFile();
        }

        #endregion
    }
}
