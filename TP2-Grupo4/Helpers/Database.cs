using System;
using MySql.Data.MySqlClient;

namespace TP2_Grupo4.Helpers
{
    class Database
    {
        private const String SERVER = "localhost";
        private const String DATABASE = "dv-tp-plataformasdedesarrollo";
        private const String PORT = "3306";
        private const String USER = "root";
        private const String PASSWORD = "";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection($"server={Database.SERVER};user={Database.USER};database={Database.DATABASE};port={Database.PORT};password={Database.PASSWORD}");
        }

    }
}
