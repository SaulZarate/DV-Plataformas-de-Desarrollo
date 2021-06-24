using System;
using System.Collections.Generic;
using TP2_Grupo4.Helpers;
//using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TP2_Grupo4.Models
{
    public class Cabania : Alojamiento
    {
        public const int CANTIDAD_DE_ATRIBUTOS = 9;

        public double precioPorDia { get; set; }
        public int habitaciones { get; set; }
        public int banios { get; set; }
        private Context contexto;

        public Cabania(int codigo, string ciudad, string barrio, int estrellas, int cantidadDePersonas, bool tv, double precioPorDia, int habitaciones, int banios) : 
            base(codigo, ciudad, barrio, estrellas, cantidadDePersonas, tv)
        {
            this.SetPrecioPorDia(precioPorDia);
            this.SetHabitaciones(habitaciones);
            this.SetBanios(banios);
            try
            {
                //creo un contexto
                contexto = new Context();

                //cargo los usuarios
                contexto.alojamientos.Load();
                //misUsuarios = contexto.usuarios;
            }
            catch (Exception)
            {
            }
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
        public List<List<string>> GetAll()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Alojamiento a in contexto.alojamientos)
                salida.Add(new List<string> { a.codigo.ToString(), a.ciudad, a.barrio, a.estrellas.ToString(), a.cantidadDePersonas.ToString(), a.tv.ToString(), a.precioPorDia.ToString(), a.habitaciones.ToString(), a.banios.ToString() });
            
            return salida;
        }
        /*public static List<Cabania> GetAll()
        {
            //Falta agregar
        }*/



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
