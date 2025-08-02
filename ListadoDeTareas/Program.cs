using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoDeTareas
{
    internal class Program
    {        static void Main(string[] args)
        {
            /// <summary>
            /// instanci controlador
            /// </summary>
            var menu = new Controller.MenuCont();
            
            /// <summary>
            /// ejecutar el menu
            /// </summary>
            menu.Ejecutar();
            
        }
    }
}
