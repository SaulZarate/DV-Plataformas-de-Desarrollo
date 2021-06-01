using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Usuario
    {
        private int dni;
        private String nombre;
        private String email;
        private String password;
        private bool isAdmin;
        private bool bloqueado;

        public Usuario(int dni, String nombre, String email,String password, bool isAdmin, bool bloqueado)
        {
            this.setDni(dni);
            this.SetNombre(nombre);
            this.SetEmail(email);
            this.SetPassword(password);
            this.SetIsAdmin(isAdmin);
            this.SetBloqueado(bloqueado);
        }
        
        /* METODOS ESTATICOS */
        public static Usuario Find(int dni)
        {
            Usuario usuario = null;
            using (MySqlConnection connection = Database.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM usuarios where dni = "+ dni , connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        return new Usuario(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetBoolean(4),
                                    reader.GetBoolean(5)
                                );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return usuario;
        }
        public static List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (MySqlConnection connection = Database.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM usuarios", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetBoolean(4),
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
            return usuarios;
        }
        public static bool Save(Usuario usuario)
        {
            using(MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO usuarios VALUES(@dni,@nombre,@email,@password,@isAdmin,@isBloqueado)";
                    command.Parameters.AddWithValue("@dni", usuario.GetDni());
                    command.Parameters.AddWithValue("@nombre", usuario.GetNombre());
                    command.Parameters.AddWithValue("@email", usuario.GetEmail());
                    command.Parameters.AddWithValue("@password", usuario.GetPassword());
                    command.Parameters.AddWithValue("@isAdmin", usuario.GetIsAdmin());
                    command.Parameters.AddWithValue("@isBloqueado", usuario.GetBloqueado());
                    command.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception)
                {
                    // No se pudo guardar
                }
                connection.Close();
                return result;
            }
            //List<String> usuariosEnListaDeString = new List<string>();
            //foreach (Usuario usuario in usuarios)
            //{
            //    usuariosEnListaDeString.Add(usuario.ToString());
            //}
            //return Utils.WriteInFile(Config.PATH_FILE_USUARIOS, usuariosEnListaDeString);
        }
        public static bool Update(Usuario usuario)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                bool result = false;
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE usuarios SET nombre = @nombre, email = @email, password = @password, isAdmin = @admin, isBloqueado = @bloqueado  WHERE dni = @dni; ";
                    command.Parameters.AddWithValue("@dni", usuario.GetDni());
                    command.Parameters.AddWithValue("@nombre", usuario.GetNombre());
                    command.Parameters.AddWithValue("@email", usuario.GetEmail());
                    command.Parameters.AddWithValue("@password", usuario.GetPassword());
                    command.Parameters.AddWithValue("@admin", usuario.GetIsAdmin());
                    command.Parameters.AddWithValue("@bloqueado", usuario.GetBloqueado());
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
        public static bool Delete(int dni)
        {
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
