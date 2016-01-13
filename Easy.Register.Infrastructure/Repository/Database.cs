using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Easy.Register.Infrastructure.Repository
{
    public static class Database
    {
        private static readonly string ConnectString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public static IDbConnection Open()
        {
            var db = new MySqlConnection(ConnectString);
            db.Open();
            return db;
        }
    }
}
