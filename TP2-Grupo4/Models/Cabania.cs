using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Cabania : Alojamiento
    {
        public const int CANTIDAD_DE_ATRIBUTOS = 9;

        private double precioPorDia;
        private int habitaciones;
        private int banios;

        public Cabania(int codigo, string ciudad, string barrio, int estrellas, int cantidadDePersonas, bool tv, double precioPorDia, int habitaciones, int banios) : 
            base(codigo, ciudad, barrio, estrellas, cantidadDePersonas, tv)
        {
            this.SetPrecioPorDia(precioPorDia);
            this.SetHabitaciones(habitaciones);
            this.SetBanios(banios);
        }

        public override double PrecioTotalDelAlojamiento(){ return this.GetPrecioPorDia(); }
        
        /* METODOS ESTATICOS*/
        public static Cabania Deserializar(String cabaniaSerializada)
        {
            String[] CabaniaArray = Utils.StringToArray(cabaniaSerializada);

            return new Cabania(
                int.Parse(CabaniaArray[0]),
                CabaniaArray[1],
                CabaniaArray[2],
                int.Parse(CabaniaArray[3]),
                int.Parse(CabaniaArray[4]),
                bool.Parse(CabaniaArray[5]),
                double.Parse(CabaniaArray[6]),
                int.Parse(CabaniaArray[7]),
                int.Parse(CabaniaArray[8])
                );
        }
        public static List<Cabania> GetAll()
        {
            List<Cabania> cabanias = new List<Cabania>();
            using (MySqlConnection connection = Database.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM cabanias", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cabanias.Add(new Cabania(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.GetInt32(4),
                                    reader.GetBoolean(5),
                                    reader.GetDouble(6),
                                    reader.GetInt32(7),
                                    reader.GetInt32(8)
                                ));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return cabanias;
        }



        /* ToString*/
        public override string ToString()
        {
            String objetoSerializado = base.ToString() + ",";
            objetoSerializado += this.GetPrecioPorDia().ToString() + ",";
            objetoSerializado += this.GetHabitaciones().ToString() + ",";
            objetoSerializado += this.GetBanios().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public double GetPrecioPorDia()
        {
            return this.precioPorDia;
        }
        public int GetHabitaciones()
        {
            return this.habitaciones;
        }
        public int GetBanios()
        {
            return this.banios;
        }
        
        public void SetPrecioPorDia(double precioPorDia) { this.precioPorDia = precioPorDia; }
        public void SetHabitaciones(int habitaciones) { this.habitaciones = habitaciones; }
        public void SetBanios(int banios) { this.banios = banios; }
        #endregion
    }
}
