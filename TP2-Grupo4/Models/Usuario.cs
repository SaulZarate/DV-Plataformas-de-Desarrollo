using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Usuario
    {
        private Context contexto;
        public int dni { get; set; }
        public String nombre { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public bool isAdmin { get; set; }
        public bool bloqueado { get; set; }

        public Usuario(int dni, String nombre, String email,String password, bool isAdmin, bool bloqueado)
        {
            this.setDni(dni);
            this.SetNombre(nombre);
            this.SetEmail(email);
            this.SetPassword(password);
            this.SetIsAdmin(isAdmin);
            this.SetBloqueado(bloqueado);
        }
        public Usuario()
        {
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                //creo un contexto
                contexto = new Context();

                //cargo los usuarios
                contexto.usuarios.Load();
                //misUsuarios = contexto.usuarios;
            }
            catch (Exception)
            {
            }
        }

        /* METODOS ESTATICOS */
        public List<List<string>> Find(int dni)
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in contexto.usuarios)
            {
                if(u.dni == dni)
                    salida.Add(new List<string> { u.dni.ToString(), u.nombre, u.email, u.password, u.isAdmin.ToString(), u.bloqueado.ToString() });
            }

            return salida;
        }
        //public static Usuario Find(int dni)
        //{
            //Falta agregar
        //}
        public List<List<string>> GetAll()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in contexto.usuarios)
                salida.Add(new List<string> { u.dni.ToString(), u.nombre, u.email, u.password, u.isAdmin.ToString(), u.bloqueado.ToString() });

            return salida;
        }
        //public static List<Usuario> GetAll()
        //{
            /*List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in contexto.usuarios)
                salida.Add(new List<string> { u.dni.ToString(), u.nombre, u.email, u.password, u.isAdmin.ToString(), u.bloqueado.ToString() });

            return salida;*/
        //}
        public bool Save()
        {
            try
            {
                Usuario nuevo = new Usuario(this.dni, this.nombre, this.email, this.password, this.isAdmin, this.bloqueado);
                contexto.usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.usuarios)
                    if (u.dni == this.dni)
                    {
                        u.nombre = this.nombre;
                        u.email = this.email;
                        u.password = this.password;
                        u.isAdmin = this.isAdmin;
                        u.bloqueado = this.bloqueado;
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
        public bool Delete()
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.usuarios)
                    if (u.dni == this.dni)
                    {
                        contexto.usuarios.Remove(u);
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


        public List<List<string>> obtenerUsuarios()
        {
            List<List<string>> salida = new List<List<string>>();
            foreach (Usuario u in contexto.usuarios)
                salida.Add(new List<string> { u.dni.ToString(), u.nombre, u.email, u.password, u.isAdmin.ToString(), u.bloqueado.ToString() });

            return salida;
        }



        /*
        //ESTO ES DE LA CLASE DE LINQ
        public List<List<string>> usuariosAdministradores()
        {
            List<List<string>> salida = new List<List<string>>();

            var query = from Usuario in contexto.usuarios
                        where Usuario.isAdmin == true
                        select Usuario;

            foreach (Usuario u in query)
                salida.Add(new List<string> {
            u.dni.ToString(), u.nombre, u.email, u.password,
            u.isAdmin.ToString(), u.bloqueado.ToString() });

            return salida;
        }

        public bool agregarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario(Dni, Nombre, Mail, Password, EsAdmin, Bloqueado);
                contexto.usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.usuarios)
                    if (u.dni == Dni)
                    {
                        contexto.usuarios.Remove(u);
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

        public bool modificarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.usuarios)
                    if (u.dni == Dni)
                    {
                        u.nombre = Nombre;
                        u.email = Mail;
                        u.password = Password;
                        u.isAdmin = EsAdmin;
                        u.bloqueado = Bloqueado;
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
        }*/

        public void cerrar()
        {
            contexto.Dispose();
        }



        /* ToString */
        public override string ToString()
        {
            String objetoSerializado = "";
            objetoSerializado += this.GetDni().ToString() + ",";
            objetoSerializado += this.GetNombre() + ",";
            objetoSerializado += this.GetEmail() + ",";
            objetoSerializado += this.GetPassword() + ",";
            objetoSerializado += this.GetIsAdmin().ToString() + ",";
            objetoSerializado += this.GetBloqueado().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public int GetDni(){ return this.dni; }
        public String GetNombre() { return this.nombre; }
        public String GetEmail() { return this.email; }
        public String GetPassword() { return this.password; }
        public bool GetIsAdmin() { return this.isAdmin; }
        public bool GetBloqueado() { return this.bloqueado; }

        public void setDni(int dni) { this.dni = dni; }
        public void SetNombre(String nombre) { this.nombre = nombre; }
        public void SetEmail(String email) { this.email = email; }
        public void SetPassword(String password) { this.password = password; }
        public void SetIsAdmin(bool isAdmin) { this.isAdmin = isAdmin; }
        public void SetBloqueado(bool bloqueado) { this.bloqueado = bloqueado; }
        #endregion
    
    }
}
