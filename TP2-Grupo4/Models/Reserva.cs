﻿using System;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Reserva
    {
        public String id { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public Alojamiento alojamiento { get; set; }
        public Usuario usuario { get; set; }
        public double precio { get; set; }

        public Reserva(String id, DateTime fechaDesde, DateTime fechaHasta, Alojamiento alojamiento, Usuario usuario, double precio)
        {
            this.SetId(id);
            this.SetFechaDesde(fechaDesde);
            this.SetFechaHasta(fechaHasta);
            this.SetAlojamiento(alojamiento);
            this.SetUsuario(usuario);
            this.SetPrecio(precio);
        }


        /* METODOS ESTATICOS */
        public static int UltimoIdInsertado()
        {
            //Falta agregar
        }
        public static List<Reserva> GetAll(Agencia agencia)
        {
            //Falta agregar
        }

        /* ToString */
        public override string ToString()
        {
            String objetoSerializado = "";
            objetoSerializado += this.GetId().ToString() + ",";
            objetoSerializado += this.GetFechaDesde().ToString() + ",";
            objetoSerializado += this.GetFechaHasta().ToString() + ",";
            objetoSerializado += this.GetAlojamiento().GetCodigo().ToString() + ",";
            objetoSerializado += this.GetUsuario().GetDni().ToString() + ",";
            objetoSerializado += this.GetPrecio().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public String GetId() { return this.id; }
        public DateTime GetFechaDesde() { return this.fechaDesde; }
        public DateTime GetFechaHasta() { return this.fechaHasta; }
        public Alojamiento GetAlojamiento() { return this.alojamiento; }
        public Usuario GetUsuario() { return this.usuario; }
        public double GetPrecio() { return this.precio; }
        public void SetId(String id) { this.id = id; }
        public void SetFechaDesde(DateTime fechaDesde) { this.fechaDesde = fechaDesde; }
        public void SetFechaHasta(DateTime fechaHasta) { this.fechaHasta = fechaHasta; }
        public void SetAlojamiento(Alojamiento alojamiento) { this.alojamiento = alojamiento; }
        public void SetUsuario(Usuario usuario) { this.usuario = usuario; }
        public void SetPrecio(double precio) { this.precio = precio; }
        #endregion

    }
}
