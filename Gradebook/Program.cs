using System;


namespace Gradebook
{
    //El proyecto va a ser un electronic gradebook que lea las calificaciones de cada estudiante y haga algunas estadisticas con esas calificaciones
    //Las calificaciones seran floats del 0 al 100, las estadisticas seran:  1. calificacion mas alta 2. calificacion mas baja 3.el promedio de las calificaciones
    internal class Program
    { 
        static void Main(string[] args)
        {
            Book book = new Book("Scott"); 
            //Por otra parte 
            book.AddGrade(29.5);
            book.AddGrade(65.0);
            book.AddGrade(78.5);
            book.AddGrade(80.1);
            book.AddGrade(99.5);
            //book.ShowStatistics(); 
            var statistics = book.GetStatistics();// sustituimos la linea de arriba por esta
            //agregamos la linea de abajo para seguir mostrando en consola las estadisticas
            Console.WriteLine($"{book.GetName()}'s {Book.Description} Stats \n ♥ Lowest Grade: {statistics.Lowest:N1} \n ♥ Highest Grade: {statistics.Highest:N1} \n ♥ Average Grade: {statistics.Average:N2}");

            /* a todos los cambios anteriores se les llama refactoring, esto sucede cuando tus pruebas unitarias te obligan
               a cambiar el codigo, de tal modo que mejore el diseño, eso es a lo que se le llama refactorizar       
            */  

            //Console.WriteLine($"{book.Description}"); hay un error en el statement porque Description es un campo estatico por lo tanto no se debe acceder a el por medio de la instancia si no de la clase Book.Description

        }
    }
}
/*Testeo (Testing)
    Implica no solo probar la funcionalidad del codigo en el mejor de los casos (happy scenario), en el cual el usuarios se comporta como esperamos
    si no, testear oara explorar y ver como se comporta el codigo en casos extraños, por ejemplo que pasa si el usuario mete una calificacion negativa
    o si todas las average con zero.

    Las prubas unitarias deben ser automatizadas, esto se hace con un test runner. Unit Testing es formalizar un codificar un proceso automatico para hacer 
    el testeo facil.
    xUnixt.net

*/
