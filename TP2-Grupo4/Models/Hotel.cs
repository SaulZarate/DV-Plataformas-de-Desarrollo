using System;
using System.Collections.Generic;
using TP2_Grupo4.Helpers;
//using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TP2_Grupo4.Models
{
    public class Hotel : Alojamiento
    {
        public const int CANTIDAD_DE_ATRIBUTOS = 7;

        private double precioPorPersona;

        public Hotel(int codigo, string ciudad, string barrio, int estrellas, int cantidadDePersonas, bool tv, double precioPorPersona) : 
            base(codigo, ciudad, barrio, estrellas, cantidadDePersonas, tv)
        {
            this.SetPrecioPorPersona(precioPorPersona);
        }

        public override double PrecioTotalDelAlojamiento()
        {
            return this.GetPrecioPorPersona() * this.GetCantidadDePersonas();
        }

        /* METODOS ESTATICOS */
        public static Hotel Deserializar(String hotelSerializado)
        {
            String[] hotelArray = Utils.StringToArray(hotelSerializado);

            return new Hotel(
                int.Parse(hotelArray[0]),
                hotelArray[1],
                hotelArray[2],
                int.Parse(hotelArray[3]),
                int.Parse(hotelArray[4]),
                bool.Parse(hotelArray[5]),
                double.Parse(hotelArray[6])
                );
        }
        public static List<Hotel> GetAll()
        {
            List<Hotel> hoteles = new List<Hotel>();
            using (MySqlConnection connection = Database.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM hoteles", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        hoteles.Add(new Hotel(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.GetInt32(4),
                                    reader.GetBoolean(5),
                                    reader.GetDouble(6)
                                ));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return hoteles;
        }


        /* ToString */
        public override string ToString()
        {
            String objetoSerializado = base.ToString() + ",";
            objetoSerializado += this.GetPrecioPorPersona().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public double GetPrecioPorPersona(){ return this.precioPorPersona; }
        public void SetPrecioPorPersona(double precio) { this.precioPorPersona = precio; }
        #endregion
    }
}
