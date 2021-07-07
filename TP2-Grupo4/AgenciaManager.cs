using System;
using System.Collections.Generic;

using TP2_Grupo4.Models;
using TP2_Grupo4.Helpers;
using System.Linq;
using MySql.Data.MySqlClient;

namespace TP2_Grupo4
{
    public class AgenciaManager
    {
        private Agencia agencia;
        private List<Usuario> usuarios;
        private List<Reserva> reservas;

        private Usuario usuarioLogeado;

        public AgenciaManager()
        {
            this.setAgencia(new Agencia());
            this.usuarios = new List<Usuario>();
            this.reservas = new List<Reserva>();
            this.usuarioLogeado = null;

            this.cargarDatosDeLaBaseDeDatos();
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
        public bool AgregarReserva(DateTime fechaDesde, DateTime fechaHasta, int codigoAlojamiento, int dniUsuario, double precio)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    // Agrego la reserva a la base de datos
                    command.CommandText = "INSERT INTO reservas (id, fechaDesde, fechaHasta, alojamiento_codigo, usuario_dni, precio) VALUES(null, @fechaDesde, @fechaHasta, @alojamiento_codigo, @usuario_dni, @precio)";
                    command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    command.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    command.Parameters.AddWithValue("@alojamiento_codigo", codigoAlojamiento);
                    command.Parameters.AddWithValue("@usuario_dni", dniUsuario);
                    command.Parameters.AddWithValue("@precio", precio);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        // Agrego la reserva a la lista de reservas
                        Alojamiento alojamiento = this.agencia.FindAlojamientoForCodigo(codigoAlojamiento);
                        Usuario usuario = this.FindUserForDNI(dniUsuario);
                        this.reservas.Add(new Reserva(Reserva.UltimoIdInsertado().ToString(), fechaDesde, fechaHasta, alojamiento, usuario, precio));
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                connection.Close();
                return result;
            }
        }
        public bool ModificarReserva(String id, DateTime fechaDesde, DateTime fechaHasta, int precio, int alojamiento_id, int usuario_id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE reservas SET fechaDesde = @fechaDesde, fechaHasta = @fechaHasta, precio = @precio, alojamiento_codigo = @alojamiento_id, usuario_dni = @usuario_id WHERE id = @id; ";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    command.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@alojamiento_id", alojamiento_id);
                    command.Parameters.AddWithValue("@usuario_id", usuario_id);
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
            /*int indexReserva = this.findIndexReservaPorId(id);
            if (indexReserva == -1) return false;

            Alojamiento alojamiento = this.agencia.FindAlojamientoForCodigo(codigoAlojamiento);
            Usuario usuario = this.FindUserForDNI(dniUsuario);
            if (alojamiento == null || usuario == null) return false;

            this.reservas[indexReserva].SetFechaDesde(fechaDesde);
            this.reservas[indexReserva].SetFechaHasta(fechaHasta);
            this.reservas[indexReserva].SetAlojamiento(alojamiento);
            this.reservas[indexReserva].SetUsuario(usuario);
            this.reservas[indexReserva].SetPrecio(alojamiento.PrecioTotalDelAlojamiento());
            return true;*/
        }
        public bool EliminarReserva(String id)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM reservas WHERE id = @id;";
                    command.Parameters.AddWithValue("@id", id);

                    if(command.ExecuteNonQuery() == 1)
                    {
                        int indexReserva = this.findIndexReservaPorId(id);
                        this.reservas.RemoveAt(indexReserva);
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    // No se pudo actualizar
                    System.Diagnostics.Debug.WriteLine(e.GetType().ToString());
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                return result;
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
            //this.usuarios.Add(usuarioNuevo);
            //return usuarioNuevo.Save();

            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO usuarios VALUES(@dni,@nombre,@email,@password,@isAdmin,@isBloqueado,@inentos)";
                    command.Parameters.AddWithValue("@dni", usuarioNuevo.GetDni());
                    command.Parameters.AddWithValue("@nombre", usuarioNuevo.GetNombre());
                    command.Parameters.AddWithValue("@email", usuarioNuevo.GetEmail());
                    command.Parameters.AddWithValue("@password", usuarioNuevo.GetPassword());
                    command.Parameters.AddWithValue("@isAdmin", usuarioNuevo.GetIsAdmin());
                    command.Parameters.AddWithValue("@isBloqueado", usuarioNuevo.GetBloqueado());
                    command.Parameters.AddWithValue("@inentos", usuarioNuevo.GetIntentos());

                    if (command.ExecuteNonQuery() == 1) return true;
                }
                catch (Exception)
                {
                    // No se pudo guardar
                }
                connection.Close();
                return result;
            }
        }
        public void ReiniciarIntentos(int dni)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            this.usuarios[indexUser].SetIntentos(0);
            this.usuarios[indexUser].SetBloqueado(false);
            using (MySqlConnection connection = Database.GetConnection())
                {
                    bool result = false;
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado , intentos = @intentos WHERE dni = @dni; ";
                        command.Parameters.AddWithValue("@dni", this.usuarios[indexUser].GetDni());
                        command.Parameters.AddWithValue("@nombre", this.usuarios[indexUser].GetNombre());
                        command.Parameters.AddWithValue("@email", this.usuarios[indexUser].GetEmail());
                        command.Parameters.AddWithValue("@password", this.usuarios[indexUser].GetPassword());
                        command.Parameters.AddWithValue("@admin", this.usuarios[indexUser].GetIsAdmin());
                        command.Parameters.AddWithValue("@bloqueado", this.usuarios[indexUser].GetBloqueado());
                        command.Parameters.AddWithValue("@intentos", this.usuarios[indexUser].GetIntentos());
                        command.ExecuteNonQuery();
                        result = true;
                    }
                    catch (Exception e)
                    {
                        // No se pudo actualizar
                        System.Diagnostics.Debug.WriteLine(e.GetType().ToString());
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }                 
                }
            
        }
        public bool BloquearUsuarioBD(int dni)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            int intentosTotales = this.usuarios[indexUser].GetIntentos();           

            if (intentosTotales >= 3)
            {
                this.usuarios[indexUser].SetBloqueado(true);
                using (MySqlConnection connection = Database.GetConnection())
                {
                    bool result = false;
                    try
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado , intentos = @intentos WHERE dni = @dni; ";
                        command.Parameters.AddWithValue("@dni", this.usuarios[indexUser].GetDni());
                        command.Parameters.AddWithValue("@nombre", this.usuarios[indexUser].GetNombre());
                        command.Parameters.AddWithValue("@email", this.usuarios[indexUser].GetEmail());
                        command.Parameters.AddWithValue("@password", this.usuarios[indexUser].GetPassword());
                        command.Parameters.AddWithValue("@admin", this.usuarios[indexUser].GetIsAdmin());
                        command.Parameters.AddWithValue("@bloqueado", this.usuarios[indexUser].GetBloqueado());
                        command.Parameters.AddWithValue("@intentos", this.usuarios[indexUser].GetIntentos());
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
            }
            return false;
        }
        public void IntentosLogueo(int dni)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            int intentosNuevos = this.usuarios[indexUser].GetIntentos() + 1;
            this.usuarios[indexUser].SetIntentos(intentosNuevos);


            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado , intentos = @intentos WHERE dni = @dni; ";
                    command.Parameters.AddWithValue("@dni", this.usuarios[indexUser].GetDni());
                    command.Parameters.AddWithValue("@nombre", this.usuarios[indexUser].GetNombre());
                    command.Parameters.AddWithValue("@email", this.usuarios[indexUser].GetEmail());
                    command.Parameters.AddWithValue("@password", this.usuarios[indexUser].GetPassword());
                    command.Parameters.AddWithValue("@admin", this.usuarios[indexUser].GetIsAdmin());
                    command.Parameters.AddWithValue("@bloqueado", this.usuarios[indexUser].GetBloqueado());
                    command.Parameters.AddWithValue("@intentos", this.usuarios[indexUser].GetIntentos());
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception e)
                {
                    // No se pudo actualizar
                    System.Diagnostics.Debug.WriteLine(e.GetType().ToString());
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
               // return result;
            }
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
            //return this.usuarios[indexUser].Update();

            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado  WHERE dni = @dni; ";
                    command.Parameters.AddWithValue("@dni", this.usuarios[indexUser].GetDni());
                    command.Parameters.AddWithValue("@nombre", this.usuarios[indexUser].GetNombre());
                    command.Parameters.AddWithValue("@email", this.usuarios[indexUser].GetEmail());
                    command.Parameters.AddWithValue("@password", this.usuarios[indexUser].GetPassword());
                    command.Parameters.AddWithValue("@admin", this.usuarios[indexUser].GetIsAdmin());
                    command.Parameters.AddWithValue("@bloqueado", this.usuarios[indexUser].GetBloqueado());
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
        }
        public bool EliminarUsuario(int dni)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            if (indexUser == -1) return false;

            // Reservas del usuario a eliminar
            List<Reserva> reservasDelUsuario = this.GetAllReservasForUsuario(dni);

            foreach (Reserva reserva in reservasDelUsuario)
                this.EliminarReserva(reserva.GetId());

            //this.usuarios[indexUser].Delete();
            this.usuarios.RemoveAt(indexUser);
            //return true;

            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM usuarios WHERE dni = @dni;";
                    command.Parameters.AddWithValue("@dni", dni);
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
            //return this.usuarios[indexUser].Update();
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado  WHERE dni = @dni; ";
                    command.Parameters.AddWithValue("@dni", this.usuarios[indexUser].GetDni());
                    command.Parameters.AddWithValue("@nombre", this.usuarios[indexUser].GetNombre());
                    command.Parameters.AddWithValue("@email", this.usuarios[indexUser].GetEmail());
                    command.Parameters.AddWithValue("@password", this.usuarios[indexUser].GetPassword());
                    command.Parameters.AddWithValue("@admin", this.usuarios[indexUser].GetIsAdmin());
                    command.Parameters.AddWithValue("@bloqueado", this.usuarios[indexUser].GetBloqueado());
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
        }
        public bool DesbloquearUsuario(int dni)
        {
            int indexUser = this.usuarios.FindIndex(user => user.GetDni() == dni);
            this.usuarios[indexUser].SetBloqueado(false);
            //return this.usuarios[indexUser].Update();
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado  WHERE dni = @dni; ";
                    command.Parameters.AddWithValue("@dni", this.usuarios[indexUser].GetDni());
                    command.Parameters.AddWithValue("@nombre", this.usuarios[indexUser].GetNombre());
                    command.Parameters.AddWithValue("@email", this.usuarios[indexUser].GetEmail());
                    command.Parameters.AddWithValue("@password", this.usuarios[indexUser].GetPassword());
                    command.Parameters.AddWithValue("@admin", this.usuarios[indexUser].GetIsAdmin());
                    command.Parameters.AddWithValue("@bloqueado", this.usuarios[indexUser].GetBloqueado());
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
