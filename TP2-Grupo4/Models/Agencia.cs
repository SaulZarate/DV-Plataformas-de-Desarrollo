using System;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Agencia
    {
        public const int MAXIMA_CANTIDAD_DE_PERSONAS_POR_ALOJAMIENTO = 10;
        public const int MINIMA_CANTIDAD_DE_ESTRELLAS = 1;
        public const int MAXIMA_CANTIDAD_DE_ESTRELLAS = 5;

        private List<Alojamiento> alojamientos;
        private int cantidadDeAlojamientos;

        public Agencia()
        {
            this.alojamientos = new List<Alojamiento>();
            this.cantidadDeAlojamientos = 0;
        }

        #region ABM de Alojamientos
        public bool AgregarAlojamiento(Alojamiento alojamiento)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO alojamientos VALUES(@codigo, @ciudad, @barrio, @estrellas, @cantidadDePersonas, @tv, @precioPorPersona, @precioPorDia, @habitaciones, @banios)";
                    command.Parameters.AddWithValue("@codigo", alojamiento.GetCodigo());
                    command.Parameters.AddWithValue("@ciudad", alojamiento.GetCiudad());
                    command.Parameters.AddWithValue("@barrio", alojamiento.GetBarrio());
                    command.Parameters.AddWithValue("@estrellas", alojamiento.GetEstrellas());
                    command.Parameters.AddWithValue("@cantidadDePersonas", alojamiento.GetCantidadDePersonas());
                    command.Parameters.AddWithValue("@tv", alojamiento.GetTv());
                    //command.Parameters.AddWithValue("@precioPorPersona", alojamientos.());
                    //command.Parameters.AddWithValue("@precioPorDia", this.GetBloqueado());
                    //command.Parameters.AddWithValue("@habitaciones", this.GetBloqueado());
                    //command.Parameters.AddWithValue("@banios", this.GetBloqueado());

                    if (command.ExecuteNonQuery() == 1) return true;
                }
                catch (Exception)
                {
                    // No se pudo guardar
                }
                connection.Close();
                return result;
            }

            //this.alojamientos.Add(alojamiento);
            //this.cantidadDeAlojamientos++;
            //return true;
        }
        public bool ModificarAlojamiento(Alojamiento alojamiento)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE alojamientos SET ciudad = @ciudad, estrellas = @estrellas, cantidadDePersonas = @cantidadDePersonas, tv = @tv, precioPorPersona = @precioPorPersona, precioPorDia = @precioPorDia, habitaciones = @habitaciones, banios = @banios  WHERE codigo = @codigo; ";
                    command.Parameters.AddWithValue("@codigo", alojamiento.GetCodigo());
                    command.Parameters.AddWithValue("@ciudad", alojamiento.GetCiudad());
                    command.Parameters.AddWithValue("@barrio", alojamiento.GetBarrio());
                    command.Parameters.AddWithValue("@estrellas", alojamiento.GetEstrellas());
                    command.Parameters.AddWithValue("@cantidadDePersonas", alojamiento.GetCantidadDePersonas());
                    command.Parameters.AddWithValue("@tv", alojamiento.GetTv());
                    //command.Parameters.AddWithValue("@precioPorPersona", alojamientos.());
                    //command.Parameters.AddWithValue("@precioPorDia", this.GetBloqueado());
                    //command.Parameters.AddWithValue("@habitaciones", this.GetBloqueado());
                    //command.Parameters.AddWithValue("@banios", this.GetBloqueado());
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception e)
                {
                    // No se pudo actualizar
                    System.Diagnostics.Debug.WriteLine(e.GetType().ToString());
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                return result;
            }
            //int indexAlojamiento = this.alojamientos.FindIndex(al => al.IgualCodigo(alojamiento));
            //if (indexAlojamiento == -1) return false;

            //this.alojamientos[indexAlojamiento] = alojamiento;
            //return true;
        }
        public bool EliminarAlojamiento(int codigoDelAlojamiento)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM alojamientos WHERE codigo = @codigo;";
                    command.Parameters.AddWithValue("@codigo", codigoDelAlojamiento);
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception e)
                {
                    // No se pudo actualizar
                    System.Diagnostics.Debug.WriteLine(e.GetType().ToString());
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                return result;
            }

            //int indexAlojamiento = this.alojamientos.FindIndex(al => al.GetCodigo() == codigoDelAlojamiento);
            //if (indexAlojamiento == -1) return false;

            //this.alojamientos.RemoveAt(indexAlojamiento);
            //this.cantidadDeAlojamientos--;
            //return true;
        }

        /*public bool AgregarAlojamiento(Alojamiento alojamiento)
        {
            this.alojamientos.Add(alojamiento);
            this.cantidadDeAlojamientos++;
            return true;
        }
        public bool ModificarAlojamiento(Alojamiento alojamiento)
        {
            int indexAlojamiento = this.alojamientos.FindIndex(al => al.IgualCodigo(alojamiento));
            if (indexAlojamiento == -1) return false;

            this.alojamientos[indexAlojamiento] = alojamiento;
            return true;
        }
        public bool EliminarAlojamiento(int codigoDelAlojamiento)
        {
            int indexAlojamiento = this.alojamientos.FindIndex(al => al.GetCodigo() == codigoDelAlojamiento);
            if (indexAlojamiento == -1) return false;

            // Elimino el alojamiento de la lista
            this.alojamientos.RemoveAt(indexAlojamiento);
            this.cantidadDeAlojamientos--;
            return true;
        }*/
        #endregion

        #region METODOS PARA FILTRAR ALOJAMIENTOS
        public Agencia GetHoteles()
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(alojamiento => alojamiento is Hotel);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetCabanias()
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll( alojamiento => alojamiento is Cabania);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientosPorCantidadDePersonas(int cantidadDePersonas)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll( al => al.GetCantidadDePersonas() == cantidadDePersonas);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientosPorCiudad(String ciudad)
        {
            return this.alojamientosToAgencia(this.alojamientos.FindAll(al => al.GetCiudad() == ciudad));
        }
        public Agencia GetAlojamientosPorBarrio(String barrio)
        {
            return this.alojamientosToAgencia(this.alojamientos.FindAll(al => al.GetBarrio() == barrio));
        }
        public Agencia GetAllAlojamientos()
        {
            return this.alojamientosToAgencia(this.GetAlojamientos());
        }
        public Agencia GetAllAlojamientos(int minimoEstrellas)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(alojamiento => alojamiento.GetEstrellas() >= minimoEstrellas);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAllAlojamientos(double precioMinimo, double precioMaximo)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(al => al.PrecioTotalDelAlojamiento() >= precioMinimo && al.PrecioTotalDelAlojamiento() <= precioMaximo);
            return this.alojamientosToAgencia(alojamientos);
        }
        #endregion

        #region METODOS DE ORDENAMIENTO
        public Agencia GetAlojamientoPorEstrellas()
        {
            List<Alojamiento> alojamientos = this.alojamientos.OrderBy(alojamiento => alojamiento.GetEstrellas()).ToList();
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientoPorPersonas()
        {
            List<Alojamiento> alojamientos = this.alojamientos.OrderBy(alojamiento => alojamiento.GetCantidadDePersonas()).ToList();
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientoPorCodigo()
        {
            List<Alojamiento> alojamientos = this.alojamientos.OrderBy(alojamiento => alojamiento.GetCodigo()).ToList();
            return this.alojamientosToAgencia(alojamientos);
        }
        #endregion


        #region METODOS COMPLEMENTARIOS
        public List<List<String>> DatosDeAlojamientosParaLasVistas(String tipoDeUsuario = "admin")
        {
            List<List<String>> alojamientos = new List<List<string>>();
            
            if (tipoDeUsuario == "admin")
            {
                foreach (Alojamiento alojamiento in this.alojamientos)
                    alojamientos.Add(new List<String>(){
                        alojamiento.GetCodigo().ToString(),
                        alojamiento.GetCiudad(),
                        alojamiento.GetBarrio(),
                        alojamiento.GetEstrellas().ToString(),
                        alojamiento.GetCantidadDePersonas().ToString(),
                        alojamiento.GetTv() ? "si" : "no",
                        alojamiento.PrecioTotalDelAlojamiento().ToString(),
                    });

            }
            else if(tipoDeUsuario == "user")
            {
                foreach (Alojamiento alojamiento in this.alojamientos)
                {
                    alojamientos.Add(new List<String>(){
                        alojamiento is Hotel ? "hotel" : "cabaña", // Tipo de alojamiento
                        alojamiento.GetCiudad(),
                        alojamiento.GetBarrio(),
                        alojamiento.GetEstrellas().ToString(),
                        alojamiento.GetCantidadDePersonas().ToString(),
                        alojamiento.GetTv() ? "si" : "no",
                        alojamiento.PrecioTotalDelAlojamiento().ToString(),
                    });
                }
            }

            
            return alojamientos;
        }
        public List<List<String>> DatosDeHotelesParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Alojamiento> hoteles = this.GetHoteles().GetAlojamientos();
            if (hoteles.Count == 0) return alojamientos;

            foreach (Alojamiento alojamiento in hoteles)
                alojamientos.Add(Utils.StringToArray(alojamiento.ToString()).ToList());

            return alojamientos;
        }
        public List<List<String>> DatosDeCabaniasParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Alojamiento> cabanias = this.GetCabanias().GetAlojamientos();
            if (cabanias.Count == 0) return alojamientos;

            foreach (Alojamiento alojamiento in cabanias)
                alojamientos.Add(Utils.StringToArray(alojamiento.ToString()).ToList());

            return alojamientos;
        }
        private Agencia alojamientosToAgencia(List<Alojamiento> alojamientos)
        {
            if (alojamientos.Count == 0) return null;

            Agencia alojamientosFiltrados = new Agencia();
            foreach (Alojamiento al in alojamientos)
            {
                alojamientosFiltrados.AgregarAlojamiento(al);
            }
            return alojamientosFiltrados;
        }
        public Alojamiento FindAlojamientoForCodigo(int codigoAlojamiento)
        {
            return this.alojamientos.Find( al => al.GetCodigo() == codigoAlojamiento );
        }
        public bool ExisteAlojamiento(Alojamiento alojamiento)
        {
            return this.alojamientos.Exists(al => al.IgualCodigo(alojamiento));
        }
        public void CargarDatosDeLosAlojamientos()
        {
            List<Alojamiento> alojamientos = new List<Alojamiento>();
            using (MySqlConnection connection = Database.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM alojamientos", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        alojamientos.Add(new Agencia(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.GetInt32(4),
                                    reader.GetBoolean(5)
                                ));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //return alojamientos;

            /*List<string> contenidoDelArchivo = Utils.GetDataFile(Config.PATH_FILE_ALOJAMIENTOS);
            if (contenidoDelArchivo.Count == 0) return;

            foreach (String alojamiento in contenidoDelArchivo)
            {
                int cantidadDeAtributosDelAlojamiento = Utils.StringToArray(alojamiento).Length;
                if (cantidadDeAtributosDelAlojamiento == Hotel.CANTIDAD_DE_ATRIBUTOS)
                {
                    this.AgregarAlojamiento(Hotel.Deserializar(alojamiento));
                }
                else if (cantidadDeAtributosDelAlojamiento == Cabania.CANTIDAD_DE_ATRIBUTOS)
                {
                    this.AgregarAlojamiento(Cabania.Deserializar(alojamiento));
                }
            }*/
        }
        public bool GuardarCambiosEnElArchivo()
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO alojamientos VALUES(@codigo, @ciudad, @barrio, @estrellas, @cantidadDePersonas, @tv, @precioPorPersona, @precioPorDia, @habitaciones, @banios)";
                    command.Parameters.AddWithValue("@codigo", this.GetCodigo());
                    command.Parameters.AddWithValue("@ciudad", alojamiento.GetCiudad());
                    command.Parameters.AddWithValue("@barrio", alojamiento.GetBarrio());
                    command.Parameters.AddWithValue("@estrellas", alojamiento.GetEstrellas());
                    command.Parameters.AddWithValue("@cantidadDePersonas", alojamiento.GetCantidadDePersonas());
                    command.Parameters.AddWithValue("@tv", alojamiento.GetTv());
                    //command.Parameters.AddWithValue("@precioPorPersona", alojamientos.());
                    //command.Parameters.AddWithValue("@precioPorDia", this.GetBloqueado());
                    //command.Parameters.AddWithValue("@habitaciones", this.GetBloqueado());
                    //command.Parameters.AddWithValue("@banios", this.GetBloqueado());

                    if (command.ExecuteNonQuery() == 1) return true;
                }
                catch (Exception)
                {
                    // No se pudo guardar
                }
                connection.Close();
                return result;
            }

            /*List<String> alojamientosInLista = new List<string>();
            foreach( Alojamiento al in this.alojamientos)
            {
                alojamientosInLista.Add(al.ToString());
            }
            return Utils.WriteInFile(Config.PATH_FILE_ALOJAMIENTOS, alojamientosInLista);*/
        }
        #endregion


        /* GETTER */
        public int GetCantidadDeAlojamientos() { return this.cantidadDeAlojamientos; }
        public List<Alojamiento> GetAlojamientos() { return this.alojamientos; }
    }
}
