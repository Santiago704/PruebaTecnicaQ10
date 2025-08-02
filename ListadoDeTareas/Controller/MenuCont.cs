using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListadoDeTareas.Repository;
using ListadoDeTareas.Models;

namespace ListadoDeTareas.Controller
{
    internal class MenuCont
    {
        public MenuCont() { }

        public void Ejecutar()
        {
            var tareaRepository = new TareaRepository();
            int opcion;


            ///ciclo para menu
            do
            {
                Console.WriteLine(" menu listado de tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Eliminar Tarea");
                Console.WriteLine("3. Listar Tareas");
                Console.WriteLine("4. Dar tarea como hecha");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione el numero entero de la opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Tarea: ");
                            var nomTarea = Console.ReadLine();
                            Console.Write("Fecha Limite bd-mm-aaaa: ");
                            var fechaLim = Convert.ToDateTime(Console.ReadLine());
                            tareaRepository.AgregarTarea(new tarea { nombre = nomTarea, FechaLim = fechaLim });
                            Console.WriteLine("Tarea agregada");
                            break;
                        case 2:
                            Console.Write("Nombre de la tarea: ");
                            var tarea = Console.ReadLine();
                            tareaRepository.Eliminar(tarea);
                            Console.WriteLine("Tarea eliminada");
                            break;
                        case 3:
                            var lista = tareaRepository.ListarTareas();
                            foreach (var i in lista)
                            {
                                Console.WriteLine($"Id: {i.id}, Tarea: {i.nombre}, Fecha Limite: {i.FechaLim}, Hecha: {(i.hecha ? "Tarea hecha" : "Tarea por hacer")}");
                            }
                            break;
                        case 4:
                            Console.Write("Nombre de la tarea: ");
                            var tareaResuelta = Console.ReadLine();
                            tareaRepository.ActualizarHecha(tareaResuelta);
                            Console.WriteLine("Tarea marcada como hecha");
                            break;
                        case 5:
                            Console.WriteLine("Salio del menu");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida intenta de nuevo");
                            Ejecutar();
                            break;
                    }

                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Ejecutar();
                }
                

            } while (opcion != 5);

        }
    }
}
