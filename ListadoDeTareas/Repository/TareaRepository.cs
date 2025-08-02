using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListadoDeTareas.Models;
using ListadoDeTareas.Data;
using System.Data.SqlClient;

namespace ListadoDeTareas.Repository
{
    internal class TareaRepository
    {
        /// <summary>
        /// instancia de la clase conexion
        /// </summary>
        private Conexion _conexion = new Conexion();

        /// <summary> Metodo para agregar</summary>
        public void AgregarTarea(tarea tarea)
        {
            try
            {
                /// <summary>Comprobaciones iniciales</summary>
                if (tarea.nombre == null) 
                {
                    throw new Exception("no dejes la tarea vacia");
                }
                if (tarea.FechaLim == null)
                {
                    throw new Exception("Digita la fecha de tarea");
                }
                if (tarea.FechaLim < DateTime.Now)
                {
                    throw new Exception("La fecha limite no puede ser antes de hoy");
                }

            
                /// <summary>crar la tarea</summary>
                using (var conn = _conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("PAgregarTarea", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nomTarea", tarea.nombre);
                    cmd.Parameters.AddWithValue("@FechaLim", tarea.FechaLim);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            
        }

        /// <summary> Metodo para eliminar</summary>
        public void Eliminar(string nombre)
        {
            try 
            {
                using (var conn = _conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("PEliminar", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nomTarea", nombre);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            
        }

        /// <summary> Metodo para lista de las tareas   </summary>
        public List<tarea> ListarTareas()
        {
            var lista = new List<tarea>();

            try
            {
                using (var conn = _conexion.ObtenerConexion())
                {
                    var cmd = new SqlCommand("Plista", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new tarea
                        {
                            id = (int)reader["id"],
                            nombre = reader["NomTarea"].ToString(),
                            FechaLim = (DateTime)reader["fechaLim"],
                            hecha = (bool)reader["hecha"]
                        });
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            
        }

        /// <summary> meetodo para actualizar</summary>
        public void ActualizarHecha(string nombre)
        {
            try
            {
                using (var conn = _conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("PCompletada", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nomTarea", nombre);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Error: " + ex.Message);
            }
            
        }
    }
}
