using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoDeTareas.Data
{
    /// <summary>
    /// clase para conectar con los datos
    /// </summary>
    internal class Conexion
    {
        /// <summary>
        /// cadena para la conexion
        /// </summary>
        private string _string = "Server = localhost\\SQLEXPRESS;Database=ListaTarea;Trusted_Connection=True";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_string);
        }
    }
}
