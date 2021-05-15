using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TP2_Grupo4.Models;
using TP2_Grupo4;

namespace TP2_Grupo4.Views
{
    public partial class VistaAlojamientosCliente : Form
    {
        private AgenciaManager agencia = new AgenciaManager();

        private Agencia alojamientosDelDataGridView;
        
        public VistaAlojamientosCliente(AgenciaManager agenciaManager)
        {
            InitializeComponent();
            this.agencia = agenciaManager;
            this.alojamientosDelDataGridView = agenciaManager.GetAgencia();

            this.llenarSelects();
        }


        #region METODOS COMPLEMENTARIOS
        private void indicarSelectPorDefecto()
        {
            this.selectTipoAlojamiento.SelectedIndex = 0;
            this.selectCiudad.SelectedIndex = 0;
            this.selectBarrio.SelectedIndex = 0;
            this.selectEstrellas.SelectedIndex = 0;
            this.selectCantPersonas.SelectedIndex = 0;
            //this.selectOrdenamiento.SelectedIndex = 0;
        }
        private void llenarSelects()
        {
            // Deshabilitar escritura en los select
            this.selectTipoAlojamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectBarrio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectEstrellas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectCantPersonas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;

            //Tipos de alojamientos
            foreach (String item in this.agencia.OpcionesDelSelectDeTiposDeAlojamientos())
                this.selectTipoAlojamiento.Items.Add(item);

            // Ciudades
            foreach (String item in this.agencia.OpcionesDelSelectDeCiudades())
                this.selectCiudad.Items.Add(item);

            // Barrios
            foreach (String item in this.agencia.OpcionesDelSelectDeBarrios())
                this.selectBarrio.Items.Add(item);

            // Estrellas
            foreach (String item in this.agencia.OpcionesDelSelectDeEstrellas())
                this.selectEstrellas.Items.Add(item);

            // Personas
            foreach (String item in this.agencia.OpcionesDelSelectDePersonas())
                this.selectCantPersonas.Items.Add(item);

            // Opciones de ordenamiento
            foreach (String opcion in this.agencia.OpcionesDelSelectParaElOrdenamiento())
                this.selectOrdenamiento.Items.Add(opcion);

            // Item por defectos de los select
            this.indicarSelectPorDefecto();
        }
        private void limpiarDataGridView()
        {
            this.dgvAlojamiento.Rows.Clear();
        }
        private void llenarDataGridView(Agencia datosParaElDGV = null)
        {
            this.alojamientosDelDataGridView = datosParaElDGV ?? this.agencia.GetAgencia();

            foreach (List<String> alojamiento in this.alojamientosDelDataGridView.DatosDeAlojamientosParaLasVistas("user"))
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
        }
        private void bloquearBotonFiltrar(bool flag)
        {
            this.btnFiltrar.Enabled = !flag;
        }
        private void ordenarAlojamientos()
        {
            this.limpiarDataGridView();
            //System.Diagnostics.Debug.WriteLine(this.selectOrdenamiento.Text);

            String tipoDeOrdenamiento = this.selectOrdenamiento.Text;
            switch (tipoDeOrdenamiento)
            {
                case "fecha de creacion":
                    this.llenarDataGridView(this.alojamientosDelDataGridView.GetAlojamientoPorCodigo());
                    break;
                case "estrellas":
                    this.llenarDataGridView(this.alojamientosDelDataGridView.GetAlojamientoPorEstrellas());
                    break;
                case "personas":
                    this.llenarDataGridView(this.alojamientosDelDataGridView.GetAlojamientoPorPersonas());
                    break;
                default:
                    this.llenarDataGridView(this.alojamientosDelDataGridView);
                    break;
            }
        }
        #endregion


        /* DATOS POR DEFECTO DEL DATAGRIDVIEW */
        private void VistaAlojamientosCliente_Load(object sender, EventArgs e)
        {
            // Boton reservar
            var btnReservar = new DataGridViewButtonColumn
            {
                Text = "RESERVAR",
                UseColumnTextForButtonValue = true,
                Name = "RESERVAR",
                DataPropertyName = "RESERVAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnReservar.DefaultCellStyle.BackColor = Color.Green;

            dgvAlojamiento.Columns.Add("Tipo", "Tipo");
            dgvAlojamiento.Columns.Add("Ciudad", "Ciudad");
            dgvAlojamiento.Columns.Add("Barrio", "Barrio");
            dgvAlojamiento.Columns.Add("Estrellas", "Estrellas");
            dgvAlojamiento.Columns.Add("CantidadDePersonas", "Cantidad de Personas");
            dgvAlojamiento.Columns.Add("Tv", "TV");
            dgvAlojamiento.Columns.Add("Precio", "Precio por dia");

            dgvAlojamiento.Columns.Add(btnReservar);
            dgvAlojamiento.ReadOnly = false;

            // Cargar DataGridView
            this.llenarDataGridView();
        }


        /* BOTON FILTRAR */
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            String inputTipoAlojamiento = this.selectTipoAlojamiento.SelectedItem.ToString();
            String inputCiudad = this.selectCiudad.SelectedItem.ToString();
            String inputBarrio = this.selectBarrio.SelectedItem.ToString();
            double inputPrecioMin = double.Parse(this.inputPrecioMin.Text);
            double inputPrecioMax = double.Parse(this.inputPrecioMax.Text);
            String inputEstrellas = this.selectEstrellas.SelectedItem.ToString();
            String inputPersonas = this.selectCantPersonas.SelectedItem.ToString();

            if ( inputPrecioMax < inputPrecioMin )
            {
                MessageBox.Show("El precio maximo no puede ser menor que el precio minimo!");
                return;
            }

            Agencia alojamientosFiltrados = this.agencia.FiltrarAlojamientos(inputTipoAlojamiento, inputCiudad, inputBarrio, inputPrecioMin, inputPrecioMax, inputEstrellas, inputPersonas);
            if (alojamientosFiltrados == null)
            {
                MessageBox.Show("No hay alojamientos disponibles para esa busqueda");
                return;
            }

            this.indicarSelectPorDefecto();
            this.limpiarDataGridView();
            this.llenarDataGridView(alojamientosFiltrados);
            this.ordenarAlojamientos();
        }
        

        /* SELECT DE ORDENAMIENTO */
        private void selectOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ordenarAlojamientos();
        }


        /* BOTON PARA RESERVAR */
        private void dgvAlojamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvAlojamiento.CurrentCell.RowIndex > (this.alojamientosDelDataGridView.GetCantidadDeAlojamientos() - 1))
            {
                return;
            }
            // Validacion de las fechas
            int diasTotalesDeLaReserva;
            try
            {
                diasTotalesDeLaReserva = int.Parse(this.lblTotalDeDias.Text);
            }catch(Exception)
            {
                MessageBox.Show("Sus fechas de reservacion no son correctas. Por favor reviselas");
                return;
            }

            // Si hacemos click en Button RESERVAR
            if (dgvAlojamiento.Columns[e.ColumnIndex].Name == "RESERVAR")
            {
                if (MessageBox.Show("Estas seguro que quieres reservar este alojamiento?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvAlojamiento.CurrentCell.RowIndex;

                    // Codigo del Alojamiento
                    int codigoDelAlojamiento = this.alojamientosDelDataGridView.GetAlojamientos()[rowIndex].GetCodigo();
                    
                    // Precio del alojamiento
                    int precioDelAlojamiento = int.Parse(this.dgvAlojamiento.Rows[rowIndex].Cells["Precio"].Value.ToString());

                    // Agregar reserva
                    this.agencia.AgregarReserva(
                        this.inputDateFechaIda.Value,
                        this.inputDateFechaVuelta.Value,
                        codigoDelAlojamiento,
                        this.agencia.GetUsuarioLogeado().GetDni(),
                        (precioDelAlojamiento * diasTotalesDeLaReserva));

                    //foreach(Reserva reserva in this.agencia.GetReservas())
                    //    System.Diagnostics.Debug.WriteLine(reserva.ToString());

                    // Guardar datos en el txt
                    if (!this.agencia.GuardarCambiosDeLasReservas())
                    {
                        MessageBox.Show("Disculpe. No se pudo guardar la reserva intente de nuevo.");
                        return;
                    }
                    
                    MessageBox.Show("Reserva realizada correctamente");

                    // llenar DataGridView
                    this.limpiarDataGridView();
                    this.llenarDataGridView();
                }
            }
        }


        /* VALIDAR LOS INPUTS DE PRECIOS */
        private void inputPrecioMin_TextChanged(object sender, EventArgs e)
        {
            String inputPrecioMin = this.inputPrecioMin.Text;
            if (inputPrecioMin == "") return;
            try
            {
                double precio = double.Parse(inputPrecioMin);

                if (precio < 0)
                {
                    MessageBox.Show("No puede ingresar valores negativos");
                    this.bloquearBotonFiltrar(true);
                    return;
                }
                this.bloquearBotonFiltrar(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se permiten numeros");
                //System.Diagnostics.Debug.WriteLine("Tipo: " + ex.GetType().ToString());
                //System.Diagnostics.Debug.WriteLine("Mensaje: " + ex.Message);
                this.bloquearBotonFiltrar(true);
            }
        }
        private void inputPrecioMax_TextChanged(object sender, EventArgs e)
        {
            String inputPrecioMax = this.inputPrecioMax.Text;
            if (inputPrecioMax == "") return;
            try
            {
                double precioMax = double.Parse(inputPrecioMax);

                if (precioMax < 0)
                {
                    MessageBox.Show("No puede ingresar valores negativos");
                    this.bloquearBotonFiltrar(true);
                    return;
                }
                this.bloquearBotonFiltrar(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se permiten numeros");
                //System.Diagnostics.Debug.WriteLine("Tipo: " + ex.GetType().ToString());
                //System.Diagnostics.Debug.WriteLine("Mensaje: " + ex.Message);
                this.bloquearBotonFiltrar(false);
            }
        }
        

        /* MOSTRAR EL TOTAL DE DIAS DE LA RESERVA */
        private void inputDateFechaVuelta_ValueChanged(object sender, EventArgs e)
        {
            this.mostrarDiferenciasDeFechas();
        }
        private void inputDateFechaIda_ValueChanged(object sender, EventArgs e)
        {
            this.mostrarDiferenciasDeFechas();
        }
        private void mostrarDiferenciasDeFechas()
        {
            DateTime inputFechaIda = this.inputDateFechaIda.Value;
            DateTime inputFechaVuelta = this.inputDateFechaVuelta.Value;

            int diasDeDiferencia = (inputFechaVuelta - inputFechaIda).Days;

            if (diasDeDiferencia <= 0)
            {
                this.lblTotalDeDias.Text = "-";
                return;
            }
            this.lblTotalDeDias.Text = diasDeDiferencia.ToString();

            System.Diagnostics.Debug.WriteLine("Diferencia de dias: " + diasDeDiferencia);
        }

        
    }
}
