using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoDeTareas.Models
{
    /// <summary>
    /// modelo de la tabla tarea
    /// </summary>
    internal class tarea
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime FechaLim { get; set; }
        public bool hecha { get; set; }
    }
}
