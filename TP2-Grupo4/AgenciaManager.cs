using System;
using System.Collections.Generic;

using TP2_Grupo4.Models;
using TP2_Grupo4.Helpers;
using System.Linq;
//using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TP2_Grupo4
{
    public class AgenciaManager
    {
        private Agencia agencia;
        private List<Usuario> usuarios;
        private List<Reserva> reservas;

        private Usuario usuarioLogeado;
        private Context contexto;

        public AgenciaManager()
        {
            this.setAgencia(new Agencia());
            this.usuarios = new List<Usuario>();
            this.reservas = new List<Reserva>();
            this.usuarioLogeado = null;

            this.cargarDatosDeLaBaseDeDatos();

            //creo un contexto
            contexto = new Context();

            //cargo los reservas
            contexto.reservas.Load();
        }

        public void cargarDatosDeLaBaseDeDatos()
        {
            this.cargarDatosDeLosUsuarios();
            this.agencia.CargarDatosDeLosAlojamientos();
            this.cargarDatosDeLasReservas();
        }

        #region METODOS PARA LOS ALOJAMIENTOS
        public bool AgregarHotel(int codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double precioPersonas)
        {
            return this.agencia.AgregarAlojamiento(new Hotel(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas));
        }
        public bool ModificarHotel(int codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double precioPersonas)
        {
            return this.agencia.ModificarAlojamiento(new Hotel(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas));
        }
        public bool AgregarCabania(int codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double precioPorDia, int habitaciones, int banios)
        {
            return this.agencia.AgregarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPorDia, habitaciones, banios));
        }
        public bool ModificarCabania(int codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double precioPorDia, int habitaciones, int banios)
        {
            return this.agencia.ModificarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPorDia, habitaciones, banios));
        }
        public bool EliminarAlojamiento(int codigo)
        {
            return this.agencia.EliminarAlojamiento(codigo);

            // Falta eliminar las reservas relacionadas con el alojamiento
        }
        public bool ExisteAlojamiento(int codigo)
        {
            return this.agencia.FindAlojamientoForCodigo(codigo) != null ? true : false; 
        }
        #endregion

        #region METODOS PARA LAS RESERVAS
        public bool AgregarReserva(DateTime fechaDesde, DateTime fechaHasta, Alojamiento codigoAlojamiento, Usuario dniUsuario, double precio)
        {
            try
            {
                //Reservas pide un id pero nosotros nunca lo asignamos, se pone solo, hay que ver como hacer eso
                //codigoAlojamiento y dniUsuario dice que vienen de otras clases, hay que ver como arreglar eso
                Reserva reservas = new Reserva(id, fechaDesde, fechaHasta, codigoAlojamiento, dniUsuario, precio);
                contexto.reservas.Add(reservas);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ModificarReserva(String id, DateTime fechaDesde, DateTime fechaHasta, int precio, Alojamiento alojamiento_id, Usuario usuario_id)
        {
            try
            {
                bool salida = false;
                foreach (Reserva r in contexto.reservas)
                    if (r.id == id)
                    {
                        r.fechaDesde = fechaDesde;
                        r.fechaHasta = fechaHasta;
                        r.precio = precio;
                        //estos errores son iguales al de arriba
                        r.alojamiento = alojamiento_id;
                        r.usuario = usuario_id;
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarReserva(String id)
        {
            try
            {
                bool salida = false;
                foreach (Reserva r in contexto.reservas)
                    if (r.id == id)
                    {
                        contexto.reservas.Remove(r);
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Reserva FindReservaForId(String id)
        {
            return this.GetReservas().Find(reserva => reserva.GetId() == id);
        }
        private List<Reserva> getAllReservasForAlojamiento(int codigo)
        {
            return this.reservas.FindAll(reserva => reserva.GetAlojamiento().GetCodigo() == codigo );
        }
        public List<Reserva> GetAllReservasForUsuario(int dni)
        {
            return this.reservas.FindAll(reserva => reserva.GetUsuario().GetDni() == dni);
        }
        private int findIndexReservaPorId(String id)
        {
            return this.reservas.FindIndex(reserva => reserva.GetId() == id);
        }
        private void cargarDatosDeLasReservas()
        {
            this.reservas = Reserva.GetAll(this.agencia);
        }
        public bool ElAlojamientoEstaDisponible(int codigoDeAlojamiento, DateTime fechaDesde, DateTime fechaHasta)
        {
            bool alojamientoDisponible = true;
            foreach (Reserva reserva in this.getAllReservasForAlojamiento(codigoDeAlojamiento))
            {
                bool validarFechaDesde = DateTime.Compare(reserva.GetFechaDesde(), fechaDesde) == 1 && DateTime.Compare(reserva.GetFechaDesde(), fechaHasta) == 1;
                bool validarFechaHasta = DateTime.Compare(reserva.GetFechaHasta(), fechaDesde) == -1 && DateTime.Compare(reserva.GetFechaHasta(), fechaDesde) == -1;
                if (!validarFechaDesde && !validarFechaHasta)
                    alojamientoDisponible = false;
            }
            return alojamientoDisponible;
        }
        #endregion

        #region METODOS PARA LOS USUARIOS
        public bool AgregarUsuario(int dni, String nombre, String email, String password, bool isAdmin, bool bloqueado)
        {
            Usuario usuarioNuevo = new Usuario(dni, nombre, email, Utils.Encriptar(password), isAdmin, bloqueado);
            this.usuarios.Add(usuarioNuevo);
            return usuarioNuevo.Save();
        }
        public bool ModificarUsuario(int dni, String nombre, String email, String password, String isAdmin, String isBloqueado)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            if (indexUser == -1) return false; // Usuario no encontrado

            this.usuarios[indexUser].SetNombre(nombre == "" ? this.usuarios[indexUser].GetNombre() : nombre );
            this.usuarios[indexUser].SetEmail(email == "" ? this.usuarios[indexUser].GetEmail() : email);
            this.usuarios[indexUser].SetPassword( password == "" ? this.usuarios[indexUser].GetPassword() : Utils.Encriptar(password));
            this.usuarios[indexUser].SetIsAdmin( isAdmin == "" ? this.usuarios[indexUser].GetIsAdmin() : bool.Parse(isAdmin));
            this.usuarios[indexUser].SetBloqueado( isBloqueado == "" ? this.usuarios[indexUser].GetBloqueado() : bool.Parse(isBloqueado));
            return this.usuarios[indexUser].Update();
        }
        public bool EliminarUsuario(int dni)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            if (indexUser == -1) return false;

            // Reservas del usuario a eliminar
            List<Reserva> reservasDelUsuario = this.GetAllReservasForUsuario(dni);

            foreach (Reserva reserva in reservasDelUsuario)
                this.EliminarReserva(reserva.GetId());

            this.usuarios[indexUser].Delete();
            this.usuarios.RemoveAt(indexUser);
            return true;
        }
        
        public bool autenticarUsuario(int dni, String password)
        {
            Usuario usuarioEncontrado = this.FindUserForDNI(dni);
            if (usuarioEncontrado == null) return false; // DNI no encontrado
            if (usuarioEncontrado.GetPassword() != Utils.Encriptar(password)) return false; // Contraseña incorrecta            
            this.usuarioLogeado = usuarioEncontrado;
            return true;
        }
        public void CerrarSession()
        {
            this.usuarioLogeado = null;
        }
        public bool BloquearUsuario(int dni)
        {
            int indexUser = this.usuarios.FindIndex(user => user.GetDni() == dni);
            this.usuarios[indexUser].SetBloqueado(true);
            return this.usuarios[indexUser].Update();
        }
        public bool DesbloquearUsuario(int dni)
        {
            int indexUser = this.usuarios.FindIndex(user => user.GetDni() == dni);
            this.usuarios[indexUser].SetBloqueado(false);
            return this.usuarios[indexUser].Update();
        }
        public Usuario FindUserForDNI(int dni)
        {
            return Usuario.Find(dni);
        }
        public bool ExisteEmail(string email)
        {
            return this.usuarios.Exists(user => user.GetEmail() == email);
        }
        public bool ExisteUsuario(int dni)
        {
            return this.usuarios.Exists(user => user.GetDni() == dni);
        }
        private int findIndexUsuarioForDNIO(int dni)
        {
            return this.usuarios.FindIndex(user => user.GetDni() == dni);
        }
        private void cargarDatosDeLosUsuarios()
        {
            foreach (Usuario usuario in Usuario.GetAll())
                this.usuarios.Add(usuario);
        }

        #endregion


        #region METODOS PARA LAS VISTAS
        public bool IsUsuarioBloqueado(int dni)
        {
            Usuario user = this.usuarios.Find(user => user.GetDni() == dni && user.GetBloqueado() == true);
            return user == null ? false : true;
        }
        public Agencia FiltrarAlojamientos(String tipoAlojamiento, String ciudad, String barrio, double precioMin, double precioMax, String estrellas, String personas)
        {
            Agencia alojamientosFiltrados = null;
            switch (tipoAlojamiento)
            {
                case "todos":
                    alojamientosFiltrados = this.agencia.GetAllAlojamientos();
                    break;
                case "hotel":
                    alojamientosFiltrados = this.agencia.GetHoteles();
                    break;
                case "cabaña":
                    alojamientosFiltrados = this.agencia.GetCabanias();
                    break;
            }
            if (alojamientosFiltrados == null) return null;

            if(ciudad != "todas")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorCiudad(ciudad);
                if (alojamientosFiltrados == null) return null;
            }

            if (barrio != "todos")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorBarrio(barrio);
                if (alojamientosFiltrados == null) return null;
            }

            if (precioMin - precioMax != 0)
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAllAlojamientos(precioMin, precioMax);
                if (alojamientosFiltrados == null) return null;
            }

            if(estrellas != "todas")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAllAlojamientos(int.Parse(estrellas));
                if (alojamientosFiltrados == null) return null;
            }

            if(personas != "todas")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorCantidadDePersonas(int.Parse(personas));
                if (alojamientosFiltrados == null) return null;
            }

            return alojamientosFiltrados;
        }
        public List<List<String>> DatosDeReservasParaLasVistas(String tipoDeUsuario = "admin")
        {
            List<List<String>> reservas = new List<List<string>>();
            cargarDatosDeLasReservas();
            if (tipoDeUsuario == "admin")
            {
                foreach (Reserva reserva in this.reservas)
                {
                    reservas.Add(new List<String>(){
                        reserva.GetId().ToString(),
                        reserva.GetFechaDesde().ToString(),
                        reserva.GetFechaHasta().ToString(),
                        reserva.GetAlojamiento().GetCodigo().ToString(),
                        reserva.GetUsuario().GetDni().ToString(),
                        reserva.GetPrecio().ToString(),
                    });
                }
            }
            else if (tipoDeUsuario == "user")
            {
                // Reservas del usuario
                List<Reserva> reservasDelUsuario = this.GetAllReservasForUsuario(this.usuarioLogeado.GetDni());

                foreach (Reserva reserva in reservasDelUsuario)
                {
                    reservas.Add(new List<String>(){
                        reserva.GetAlojamiento() is Hotel ? "hotel" : "cabaña",
                        reserva.GetFechaDesde().ToString(),
                        reserva.GetFechaHasta().ToString(),
                        reserva.GetPrecio().ToString(),
                    });
                }
            }
            return reservas;
        }
        public List<List<String>> BuscarDeAlojamientosPorCiudadYFechas(String ciudad, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Alojamiento> alojamientosFiltrados = new List<Alojamiento>();

            foreach(var alojamiento in this.GetAgencia().GetAlojamientos().FindAll(al => al.GetCiudad().Contains(ciudad)))
            {
                if (this.ElAlojamientoEstaDisponible(alojamiento.GetCodigo(), fechaDesde, fechaHasta))
                    alojamientosFiltrados.Add(alojamiento);
            }

            foreach (Alojamiento alojamiento in alojamientosFiltrados)
            {
                alojamientos.Add(new List<string>()
                {
                    alojamiento.GetCodigo().ToString(),
                    alojamiento is Hotel ? "hotel" : "cabaña",
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas().ToString(),
                    alojamiento.GetCantidadDePersonas().ToString(),
                    alojamiento.GetTv().ToString(),
                    alojamiento is Hotel ? ((Hotel)alojamiento).GetPrecioPorPersona().ToString() : ((Cabania)alojamiento).GetPrecioPorDia().ToString()
                });
            }

            return alojamientos;
        }
        #endregion

        #region Selects de las vistas
        public List<String> OpcionesDelSelectDeTiposDeAlojamientos()
        {
            return new List<String>() { "todos", "hotel", "cabaña" };
        }
        public List<String> OpcionesDelSelectDePersonas()
        {
            List<String> opciones = new List<String>() {"todas" };
            for (int i = 1; i <= Agencia.MAXIMA_CANTIDAD_DE_PERSONAS_POR_ALOJAMIENTO; i++)
                opciones.Add(i.ToString());
            return opciones;
        }
        public List<String> OpcionesDelSelectDeEstrellas()
        {
            List<String> opciones = new List<String>() { "todas" };
            for (int i = Agencia.MINIMA_CANTIDAD_DE_ESTRELLAS; i <= Agencia.MAXIMA_CANTIDAD_DE_ESTRELLAS; i++)
                opciones.Add(i.ToString());
            return opciones;
        }
        public List<String> OpcionesDelSelectDeBarrios()
        {
            List<String> tipos = new List<string>() { "todos"};
            foreach (Alojamiento al in this.agencia.GetAlojamientos())
                tipos.Add(al.GetBarrio());
            return tipos.Distinct().ToList();
        }
        public List<String> OpcionesDelSelectDeCiudades()
        {
            List<String> tipos = new List<string>() { "todas" };
            foreach (Alojamiento al in this.agencia.GetAlojamientos())
                tipos.Add(al.GetCiudad());
            return tipos.Distinct().ToList();
        }
        public List<String> OpcionesDelSelectParaElOrdenamiento()
        {
            return new List<String>() { "fecha de creacion","personas","estrellas" };
        }
        #endregion


        /* GETTERS Y SETTERS */
        public List<Usuario> GetUsuarios() { return this.usuarios; }
        public List<Reserva> GetReservas() { return this.reservas; }
        public Agencia GetAgencia() { return this.agencia; }
        public Usuario GetUsuarioLogeado() { return this.usuarioLogeado; }
        private void setAgencia(Agencia agencia) { this.agencia = agencia; }
    }
}
