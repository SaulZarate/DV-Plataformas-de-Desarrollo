
using System;
using System.Linq;
using System.Collections.Generic;

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
        }
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
        public List<List<String>> DatosDeAlojamientosParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();
            foreach(Alojamiento alojamiento in this.alojamientos)
            {
                alojamientos.Add(new List<String>()
                {
                    alojamiento.GetCodigo().ToString(),
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas().ToString(),
                    alojamiento.GetCantidadDePersonas().ToString(),
                    alojamiento.GetTv() ? "si" : "no",
                    alojamiento.PrecioTotalDelAlojamiento().ToString(),

                });
            }
            return alojamientos;
        }
        public List<List<String>> DatosDeHotelesParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();

            foreach (Alojamiento alojamiento in this.GetHoteles().alojamientos)
                alojamientos.Add(Utils.StringToArray(alojamiento.ToString()).ToList());

            return alojamientos;
        }
        public List<List<String>> DatosDeCabaniasParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();

            foreach (Alojamiento alojamiento in this.GetCabanias().alojamientos)
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
            List<string> contenidoDelArchivo = Utils.GetDataFile(Config.PATH_FILE_ALOJAMIENTOS);
            if (contenidoDelArchivo.Count == 0) return;

            foreach (String alojamiento in contenidoDelArchivo)
            {
                int cantidadDeAtributosDelAlojamiento = Utils.StringToArray(alojamiento).Length;
                if (cantidadDeAtributosDelAlojamiento == Hotel.CANTIDAD_DE_ATRIBUTOS)
                {
                    this.AgregarAlojamiento(Hotel.Deserializar(alojamiento));
                }
                else if(cantidadDeAtributosDelAlojamiento == Cabania.CANTIDAD_DE_ATRIBUTOS)
                {
                    this.AgregarAlojamiento(Cabania.Deserializar(alojamiento));
                }
            }
        }
        public bool GuardarCambiosEnElArchivo()
        {
            List<String> alojamientosInLista = new List<string>();
            foreach( Alojamiento al in this.alojamientos)
            {
                alojamientosInLista.Add(al.ToString());
            }
            return Utils.WriteInFile(Config.PATH_FILE_ALOJAMIENTOS, alojamientosInLista);
        }
        #endregion


        /* GETTER */
        public int GetCantidadDeAlojamientos() { return this.cantidadDeAlojamientos; }
        public List<Alojamiento> GetAlojamientos() { return this.alojamientos; }
    }
}
