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
    public partial class VistaAdminCabanias : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaAdminCabanias()
        {
            InitializeComponent();
        }

        private void FormCabanias_Load(object sender, EventArgs e)
        {
            // Boton borrar
            var btnBorrar = new DataGridViewButtonColumn
            {
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
                Text = "MODIFICAR",
                UseColumnTextForButtonValue = true,
                Name = "MODIFICAR",
                DataPropertyName = "MODIFICAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnModificar.DefaultCellStyle.BackColor = Color.LightYellow;

            var checkTV = new DataGridViewCheckBoxColumn
            {
                HeaderText = "TV",
                Name = "TV"
            };

            // Tabla
            dgvCabanias.Columns.Add("CODIGO", "Codigo");
            dgvCabanias.Columns.Add("CIUDAD", "Ciudad");
            dgvCabanias.Columns.Add("BARRIO", "Barrio");
            dgvCabanias.Columns.Add("ESTRELLAS", "Estrellas");
            dgvCabanias.Columns.Add("CANT_PERSONAS", "Cant. Personas");
            dgvCabanias.Columns.Add(checkTV);
            dgvCabanias.Columns.Add("PRECIO_X_DIA", "Precio X Dia");
            dgvCabanias.Columns.Add("HABITACIONES", "Habitaciones");
            dgvCabanias.Columns.Add("BANIOS", "Baños");
            dgvCabanias.Columns.Add("PRECIO_TOTAL", "Total");

            dgvCabanias.Columns.Add(btnModificar);
            dgvCabanias.Columns.Add(btnBorrar);

            dgvCabanias.ReadOnly = true;
            btnTopModificar.Visible = false;

            clearAllControls();
            getCabaniasFromTextFile();
        }

        private void getCabaniasFromTextFile()
        {
            // Limpiamos el GridView
            dgvCabanias.Rows.Clear();

            List<Alojamiento> cabanias = this.agencia.GetAgencia().GetCabanias().GetAlojamientos();

            foreach (Cabania cabania in cabanias)
            {
                this.dgvCabanias.Rows.Add(
                    cabania.GetCodigo().ToString(),
                    cabania.GetCiudad(),
                    cabania.GetBarrio(),
                    cabania.GetEstrellas(),
                    cabania.GetCantidadDePersonas().ToString(),
                    cabania.GetTv(),
                    cabania.GetPrecioPorDia(),
                    cabania.GetHabitaciones().ToString(),
                    cabania.GetBanios().ToString(),
                    cabania.PrecioTotalDelAlojamiento().ToString()
                ); ;
            }

            // Update y Regresheo de Grid
            dgvCabanias.Update();
            dgvCabanias.Refresh();
        }

        #region Helpers
        private void rellenarDatos()
        {
            txtCodigo.Text = dgvCabanias.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Enabled = false;
            txtCiudad.Text = dgvCabanias.CurrentRow.Cells[1].Value.ToString();
            txtBarrio.Text = dgvCabanias.CurrentRow.Cells[2].Value.ToString();
            comboBoxEstrellas.Text = dgvCabanias.CurrentRow.Cells[3].Value.ToString();
            comboBoxCantPersonas.Text = dgvCabanias.CurrentRow.Cells[4].Value.ToString();
            checkBoxTV.Checked = bool.Parse(dgvCabanias.CurrentRow.Cells[5].Value.ToString());
            txtPrecioDia.Text = dgvCabanias.CurrentRow.Cells[6].Value.ToString();
            comboBoxHabitaciones.Text = dgvCabanias.CurrentRow.Cells[7].Value.ToString();
            comboBoxBanios.Text = dgvCabanias.CurrentRow.Cells[8].Value.ToString();
        }

        private void clearAllControls()
        {
            foreach (Control control in groupBoxCabanias.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;

                }
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;

                    comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
            }
        }
        #endregion

        private void dgvCabanias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Si hacemos click en Button BORRAR
            if (dgvCabanias.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvCabanias.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    int codigo = Int32.Parse(dgvCabanias.Rows[rowIndex].Cells["CODIGO"].Value.ToString());

                    // Borrado
                    dgvCabanias.Rows.RemoveAt(rowIndex);
                    this.agencia.GetAgencia().EliminarAlojamiento(codigo);
                    this.agencia.GetAgencia().GuardarCambiosEnElArchivo();

                    // Actualizar GridView
                    getCabaniasFromTextFile();
                }
            }

            if (dgvCabanias.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnTopAgregar.Visible = false;
                    btnTopModificar.Visible = true;

                    rellenarDatos();
                }
            }
        }

        private void btnTopAgregar_Click(object sender, EventArgs e)
        {
            double precioPorDia = 0;
            int codigo = 0;
            bool huboError = false;
            try
            {
                codigo = Int32.Parse(txtCodigo.Text);
            }
            catch (FormatException)
            {
               
                MessageBox.Show("ingresaste un valor alfabetico en el codigo de alojamiento, ingresa un valor numérico");
                huboError = true;
            }
            string ciudad = txtCiudad.Text;
            string barrio = txtBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            try
            {
                precioPorDia = double.Parse(txtPrecioDia.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresaste un valor alfabetico en el precio, ingresa un valor numérico");
                huboError = true;

            }

            int habitaciones = Int32.Parse(comboBoxHabitaciones.Text);
            int banios = Int32.Parse(comboBoxBanios.Text);
            if (this.agencia.GetAgencia().FindAlojamientoForCodigo(codigo) == null)
            {
                    this.agencia.GetAgencia().AgregarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPorDia, habitaciones, banios));
                    this.agencia.GetAgencia().GuardarCambiosEnElArchivo();
            }
            else if (!huboError)
            {
                MessageBox.Show("Ya existe el código de alojamiento, ingresa un código inexistente");
            }
        
            clearAllControls();
            getCabaniasFromTextFile();
        }

        private void btnTopModificar_Click(object sender, EventArgs e)
        {
            btnTopAgregar.Visible = true;
            btnTopModificar.Visible = false;

            double precioDia = 0;
            int codigo = 0;
            try
            {
                codigo = Int32.Parse(txtCodigo.Text);
            }
            catch (FormatException)
            {
                lblErrorCabañas.Text = "ingresaste un valor alfabetico en el codigo de alojamiento, ingresa un valor numérico \n";
            }
            string ciudad = txtCiudad.Text;
            string barrio = txtBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            try
            {
                precioDia = double.Parse(txtPrecioDia.Text);
            }
            catch (FormatException)
            {
                lblErrorCabañas.Text += "Ingresaste un valor alfabetico en el precio, ingresa un valor numérico \n";
            }
            int habitaciones = Int32.Parse(comboBoxHabitaciones.Text);
            int banios = Int32.Parse(comboBoxBanios.Text);

            this.agencia.GetAgencia().ModificarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioDia, habitaciones, banios));
            this.agencia.GetAgencia().GuardarCambiosEnElArchivo();

            clearAllControls();
            getCabaniasFromTextFile();
            txtCodigo.Enabled = true;
        }
    }
}
