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
