APLICACION DE CONSOLA - LISTA DE TAREAS

La aplicacion tiene dos elementos:
1. Bases de datos en SQL server,  en el repositorio remoto se encuentra el archivo sriptBD, se ejecuta antes de ejecutar el programa de consola, tambientener encuenta que tiene con procedimientos almacenados. NOTA: Recuerde que debe de crear la base de datos ListaTarea antes de ejecutar el script que se encuentra en el repositorio.

2. Progrma en C# con framewor .net 4.8 que consta de las siguientes carpetas:
   
     2.1 Data: contiene la conexion a la base de datos del punto 1. Conexion.cs

     2.2 El model tiene la informacion de la tabla cliente con su informacion encapsulada. tarea.cs

     2.3 En el Repository podemos encontrar la ligica para poder guardar, modificar, listar (aca se hace uso de listas) y eliminar tareas en todas se usa manejo de errores. TareaRepository.sc

     2.4 en el controlador encontramos el menu que interactua con el usuario tambien con el try-catch. MenuCont.cs

     2.5 por ultimo el program.cs ejecuta todo llamando al controlador.
   

   
