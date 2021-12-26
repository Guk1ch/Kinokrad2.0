using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Core
{
    class Data
    {
        private static string coonstr = ConfigurationManager.ConnectionStrings["KinoCollection"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(coonstr);
        public static List<Film> GetFilms()
        {
            return connection.Query<Film>("select * from Film").AsList();
        }
    }
}
