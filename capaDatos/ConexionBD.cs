using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConexionBD
    {

        public static SqlConnection ConexionSql()
        {
          SqlConnection sqlConexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Taller;Integrated Security=true;");
            sqlConexion.Open();
            return sqlConexion;
         }
    } 
}

