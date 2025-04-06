using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    class Conexion
    {
        //generar las diferentes partes de las conexiones
        public static MySqlConnection conexion() 
        {
            string servidor = "localhost";
            string bd = "dbusuarios";
            string usuario = "root";
            string contrasena = "root";

            //generar cadena de conexion a la base de datos
            string cadenaConexion = "Database="+ bd + "; Data source="+ servidor+"; User Id="+usuario+"; Password="+ contrasena+"";

            try
            {
                MySqlConnection conexionDB = new MySqlConnection(cadenaConexion);
                return conexionDB;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
