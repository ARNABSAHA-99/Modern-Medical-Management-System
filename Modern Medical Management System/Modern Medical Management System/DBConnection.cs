using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Modern_Medical_Management_System
{
    class DBConnection
    {
        public static SqlConnection Connect()
        {
            string connString = @"Server=AL-AMIN\SQLEXPRESS;Database=C#_Project;Integrated Security=true;MultipleActiveResultSets=True;";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
