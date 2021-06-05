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

                    if (alojamiento is Hotel)
                    {
                        Hotel hotel = (Hotel)alojamiento;
                        command.CommandText = "INSERT INTO alojamientos (codigo,ciudad,barrio,estrellas,cantidadDePersonas,tv,precioPorPersona) VALUES(@codigo, @ciudad, @barrio, @estrellas, @cantidadDePersonas, @tv, @precioPorPersona)";
                        command.Parameters.AddWithValue("@codigo", alojamiento.GetCodigo());
                        command.Parameters.AddWithValue("@ciudad", alojamiento.GetCiudad());
                        command.Parameters.AddWithValue("@barrio", alojamiento.GetBarrio());
                        command.Parameters.AddWithValue("@estrellas", alojamiento.GetEstrellas());
                        command.Parameters.AddWithValue("@cantidadDePersonas", alojamiento.GetCantidadDePersonas());
                        command.Parameters.AddWithValue("@tv", alojamiento.GetTv());
                        command.Parameters.AddWithValue("@precioPorPersona", hotel.GetPrecioPorPersona());
                    }
                    else
                    {
                        Cabania cabania = (Cabania)alojamiento;
                        command.CommandText = "INSERT INTO alojamientos (codigo,ciudad,barrio,estrellas,cantidadDePersonas,tv,precioPorDia,habitaciones,banios) VALUES(@codigo, @ciudad, @barrio, @estrellas, @cantidadDePersonas, @tv, @precioPorDia, @habitaciones, @banios)";
                        command.Parameters.AddWithValue("@codigo", alojamiento.GetCodigo());
                        command.Parameters.AddWithValue("@ciudad", alojamiento.GetCiudad());
                        command.Parameters.AddWithValue("@barrio", alojamiento.GetBarrio());
                        command.Parameters.AddWithValue("@estrellas", alojamiento.GetEstrellas());
                        command.Parameters.AddWithValue("@cantidadDePersonas", alojamiento.GetCantidadDePersonas());
                        command.Parameters.AddWithValue("@tv", alojamiento.GetTv());
                        command.Parameters.AddWithValue("@precioPorDia", cabania.GetPrecioPorDia());
                        command.Parameters.AddWithValue("@habitaciones", cabania.GetHabitaciones());
                        command.Parameters.AddWithValue("@banios", cabania.GetBanios());
                    }

                    if (command.ExecuteNonQuery() == 1)
                    {
                        this.alojamientos.Add(alojamiento);
                        this.cantidadDeAlojamientos++;
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine("Error en el Insert");
                }
                
                connection.Close();
                return result;
            }
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
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(alojamiento => alojamiento is Cabania);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientosPorCantidadDePersonas(int cantidadDePersonas)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(al => al.GetCantidadDePersonas() == cantidadDePersonas);
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
        public List<List<String>> DatosDeAlojamientosParaLasVistas(String tipoDeUsuario)
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
            else if (tipoDeUsuario == "user")
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
        public List<List<String>> DatosDeHotelesParaLasVistas(String tipoDeUsuario)
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Hotel> hoteles = Hotel.GetAll();

            if (tipoDeUsuario == "admin")
            {
                foreach (Hotel hotel in hoteles)
                    alojamientos.Add(new List<String>(){
                        hotel.GetCodigo().ToString(),
                        hotel.GetCiudad(),
                        hotel.GetBarrio(),
                        hotel.GetEstrellas().ToString(),
                        hotel.GetCantidadDePersonas().ToString(),
                        hotel.GetTv().ToString(),
                        hotel.GetPrecioPorPersona().ToString(),
                        hotel.PrecioTotalDelAlojamiento().ToString()
                    });

                System.Diagnostics.Debug.WriteLine(alojamientos);
            }
            else
            {
                foreach (Hotel alojamiento in hoteles)
                {
                    alojamientos.Add(new List<String>(){
                        alojamiento is Hotel ? "hotel" : "cabaña", // Tipo de alojamiento
                        alojamiento.GetCiudad(),
                        alojamiento.GetBarrio(),
                        alojamiento.GetEstrellas().ToString(),
                        alojamiento.GetCantidadDePersonas().ToString(),
                        alojamiento.GetTv().ToString(),
                        alojamiento.GetPrecioPorPersona().ToString(),
                        alojamiento.PrecioTotalDelAlojamiento().ToString(),
                    });
                }
            }

            return alojamientos;
        }
        public List<List<String>> DatosDeCabaniasParaLasVistas(String tipoDeUsuario)
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Cabania> cabanias = Cabania.GetAll();

            if (tipoDeUsuario == "admin")
            {
                foreach (Cabania cabania in cabanias)
                    alojamientos.Add(new List<String>(){
                        cabania.GetCodigo().ToString(),
                        cabania.GetCiudad(),
                        cabania.GetBarrio(),
                        cabania.GetEstrellas().ToString(),
                        cabania.GetCantidadDePersonas().ToString(),
                        cabania.GetTv().ToString(),
                        cabania.GetPrecioPorDia().ToString(),
                        cabania.GetHabitaciones().ToString(),
                        cabania.GetBanios().ToString(),
                        cabania.PrecioTotalDelAlojamiento().ToString(),
                    });

                System.Diagnostics.Debug.WriteLine(alojamientos);
            }
            else
            {
                foreach (Cabania cabania in cabanias)
                {
                    alojamientos.Add(new List<String>(){
                        cabania is Cabania ? "hotel" : "cabaña", // Tipo de alojamiento
                        cabania.GetCiudad(),
                        cabania.GetBarrio(),
                        cabania.GetEstrellas().ToString(),
                        cabania.GetCantidadDePersonas().ToString(),
                        cabania.GetTv().ToString(),
                        cabania.GetPrecioPorDia().ToString(),
                        cabania.GetHabitaciones().ToString(),
                        cabania.GetBanios().ToString(),
                        cabania.PrecioTotalDelAlojamiento().ToString(),
                    });
                }
            }

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
            return this.alojamientos.Find(al => al.GetCodigo() == codigoAlojamiento);
        }
        public bool ExisteAlojamiento(Alojamiento alojamiento)
        {
            return this.alojamientos.Exists(al => al.IgualCodigo(alojamiento));
        }
        public void CargarDatosDeLosAlojamientos()
        {
            List<Hotel> hoteles = Hotel.GetAll();
            List<Cabania> cabanias = Cabania.GetAll();
            this.alojamientos.AddRange(hoteles);
            this.alojamientos.AddRange(cabanias);
        }
        public bool GuardarCambiosEnElArchivo()
        {
            return false;
            //using (MySqlConnection connection = Database.GetConnection())
            //{
            //    bool result = false;
            //    try
            //    {
            //        connection.Open();
            //        MySqlCommand command = connection.CreateCommand();

            //        command.CommandText = "INSERT INTO alojamientos VALUES(@codigo, @ciudad, @barrio, @estrellas, @cantidadDePersonas, @tv, @precioPorPersona, @precioPorDia, @habitaciones, @banios)";
            //        command.Parameters.AddWithValue("@codigo", this.GetCodigo());
            //        command.Parameters.AddWithValue("@ciudad", alojamiento.GetCiudad());
            //        command.Parameters.AddWithValue("@barrio", alojamiento.GetBarrio());
            //        command.Parameters.AddWithValue("@estrellas", alojamiento.GetEstrellas());
            //        command.Parameters.AddWithValue("@cantidadDePersonas", alojamiento.GetCantidadDePersonas());
            //        command.Parameters.AddWithValue("@tv", alojamiento.GetTv());
            //        //command.Parameters.AddWithValue("@precioPorPersona", alojamientos.());
            //        //command.Parameters.AddWithValue("@precioPorDia", this.GetBloqueado());
            //        //command.Parameters.AddWithValue("@habitaciones", this.GetBloqueado());
            //        //command.Parameters.AddWithValue("@banios", this.GetBloqueado());

            //        if (command.ExecuteNonQuery() == 1) return true;
            //    }
            //    catch (Exception)
            //    {
            //        // No se pudo guardar
            //    }
            //    connection.Close();
            //    return result;
            //}

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
