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
    public partial class VistaCabanias : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaCabanias()
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
            // TODO: Cambiar Ciudad, Barrio, Estrellas, Cant. personas, Habitaciones y Baños por COMBOBOX
            dgvCabanias.Columns.Add("CODIGO", "Codigo");
            dgvCabanias.Columns.Add("CIUDAD", "Ciudad");
            dgvCabanias.Columns.Add("BARRIO", "Barrio");
            dgvCabanias.Columns.Add("ESTRELLAS", "Estrellas");
            dgvCabanias.Columns.Add("CANT_PERSONAS", "Cant. Personas");
            dgvCabanias.Columns.Add(checkTV);
            dgvCabanias.Columns.Add("PRECIO_X_DIA", "Precio x dia");
            dgvCabanias.Columns.Add("HABITACIONES", "habitaciones");
            dgvCabanias.Columns.Add("BAÑOS", "Baños");
            dgvCabanias.Columns.Add("PRECIO", "Precio Total");

            dgvCabanias.Columns.Add(btnModificar);
            dgvCabanias.Columns.Add(btnBorrar);

            dgvCabanias.ReadOnly = true;

            btnTopModificar.Visible = false;

            getCabaniasFromTextFile();
        }

        private void getCabaniasFromTextFile()
        {            
            // Limpiamos el GridView
            dgvCabanias.Rows.Clear();

            List<Alojamiento> cabanias = this.agencia.GetAgencia().GetCabanias();

            foreach (Cabania cabania in cabanias)
            {
                this.dgvCabanias.Rows.Add(
                    cabania.GetCodigo().ToString(),
                    cabania.GetCiudad(),
                    cabania.GetBarrio(),
                    cabania.GetEstrellas(),
                    cabania.GetCantidadDePersonas().ToString(),
                    cabania.GetTv(),
                    cabania.GetPrecioPorDia().ToString(),
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
            comboBoxCiudad.Text = dgvCabanias.CurrentRow.Cells[1].Value.ToString();
            comboBoxBarrio.Text = dgvCabanias.CurrentRow.Cells[2].Value.ToString();
            comboBoxEstrellas.Text = dgvCabanias.CurrentRow.Cells[3].Value.ToString();
            comboBoxCantPersonas.Text = dgvCabanias.CurrentRow.Cells[4].Value.ToString();
            checkBoxTV.Checked = bool.Parse(dgvCabanias.CurrentRow.Cells[5].Value.ToString());
            txtPrecioPorDia.Text = dgvCabanias.CurrentRow.Cells[6].Value.ToString();
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
            int codigo = Int32.Parse(txtCodigo.Text);
            string ciudad = comboBoxCiudad.Text;
            string barrio = comboBoxBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            double precioPorDia = double.Parse(txtPrecioPorDia.Text);
            int habitaciones = Int32.Parse(comboBoxHabitaciones.Text);
            int banios = Int32.Parse(comboBoxBanios.Text);

            this.agencia.GetAgencia().AgregarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPorDia, habitaciones, banios));
            this.agencia.GetAgencia().GuardarCambiosEnElArchivo();
            clearAllControls();
            getCabaniasFromTextFile();
        }

        private void btnTopModificar_Click(object sender, EventArgs e)
        {
            btnTopAgregar.Visible = true;
            btnTopModificar.Visible = false;

            int codigo = Int32.Parse(txtCodigo.Text);
            string ciudad = comboBoxCiudad.Text;
            string barrio = comboBoxBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            double precioPorDia = double.Parse(txtPrecioPorDia.Text);
            int habitaciones = Int32.Parse(comboBoxHabitaciones.Text);
            int banios = Int32.Parse(comboBoxBanios.Text);

            this.agencia.GetAgencia().ModificarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPorDia, habitaciones, banios));
            this.agencia.GetAgencia().GuardarCambiosEnElArchivo();
            clearAllControls();
            getCabaniasFromTextFile();
        }
    }
}
