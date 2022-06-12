using System;


namespace Gradebook
{
    //El proyecto va a ser un electronic gradebook que lea las calificaciones de cada estudiante y haga algunas estadisticas con esas calificaciones
    //Las calificaciones seran floats del 0 al 100, las estadisticas seran:  1. calificacion mas alta 2. calificacion mas baja 3.el promedio de las calificaciones
    internal class Program
    { 
        static void Main(string[] args)
        {
            DiskBook book = new DiskBook("Scott");
            book.GradeAdded += OnGradeAdded; // aqui nos suscribimos al evento y le decimos que cuando ocurra el evento el metodo OnGradeAdded sera quien responda a dicho evento
            bool stayinprogram = true;
            Console.WriteLine("Grades Register");
            while (stayinprogram) 
            {
                Console.WriteLine("What tipe of Grade do you wanna register?\n 1. Number Grade (100 to 0)\n 2. Letter Grade (A to F) \n X. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        addNumberGrade(book);
                        break;
                    case "2":
                        addLetterGrade(book);
                        break;
                    default:
                        stayinprogram = false;
                        break;
                }

            }
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine("Good Bye ♥");
            Console.WriteLine(book.ToString());
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            
            

            
            //book.AddGrade(29.5);
            //book.AddGrade(65.0);
            //book.AddGrade(78.5);
            //book.AddGrade(80.1);
            //book.AddGrade(99.5);
            //book.AddLetterGrade('a');
            //book.AddLetterGrade('B');
            //book.ShowStatistics(); 
            var statistics = book.GetStatistics();// sustituimos la linea de arriba por esta
            //agregamos la linea de abajo para seguir mostrando en consola las estadisticas
            Console.WriteLine($"{InMememoryBook.Description} Stats \n ♥ Lowest Grade: {statistics.Lowest:N1} \n ♥ Highest Grade: {statistics.Highest:N1} \n ♥ Average Grade: {statistics.Average:N2}");
            Console.WriteLine($"a = {book.grades[book.grades.Count - 2]}  B= {book.grades[book.grades.Count - 1]}");
            /* a todos los cambios anteriores se les llama refactoring, esto sucede cuando tus pruebas unitarias te obligan
               a cambiar el codigo, de tal modo que mejore el diseño, eso es a lo que se le llama refactorizar       
            */  

            //Console.WriteLine($"{book.Description}"); hay un error en el statement porque Description es un campo estatico por lo tanto no se debe acceder a el por medio de la instancia si no de la clase Book.Description

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine($"A grade was added to {nameof(sender)}!");
            Console.ResetColor();
        }

        private static void addLetterGrade(DiskBook book)
        {
            bool stayhere = true;
            while (stayhere)
            {
                Console.Write("Enter a letter grade: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                book.AddGrade(Console.ReadLine());
                Console.ResetColor();
                Console.Write("Do you wanna enter another letter grade? (y/n) ");
                
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    stayhere = false;
                    Console.Clear();
                }
            }
        }

        private static void addNumberGrade(Book book)
        {
            while (true)
            {
                Console.Write("Enter number grade or 'x' to quit ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                var response = Console.ReadLine();
                if (response == "x" || response == "X")
                {
                    Console.ResetColor();
                    Console.Clear();
                    break;
                }

                try
                {
                    var grade = double.Parse(response);/*Si por ejemplo la excepsion la tira el parseo inmediatamente se saldra del codigo para o detener
                    el programa (si nohubiera el catch) o para entrar al catch por lo tanto se saltaria lo que haya debajo, si forzozamente debemos hacer
                    alguna accion como cerrar un socket un acceso a base de datos aun si hubo error, podemos usar el bloque finally*/
                    book.AddGrade(grade);
                }
                catch (Exception oshezna) // Exception es para una excepsion en general, por lo tanto cacharia todo tipo de excepsiones si por ejemplo 
                { //sabes que tipo de excepsion puede tirar entonces lo mas correcto seria poner un catch para cada tipo de excepsion. 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(oshezna.Message);
                }
                finally 
                {
                    /* lo que haya en el finally se va a ejecutar si o si, si el try no tira errores se ejecuta el finally
                       si el try tira errores se ejecuta el finally despues de que se cache el error
                     */
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("Siempre entro aqui al finally! ☺");
                }

                /*
                 NOTA!!! : Si ahi pusiera catch(ArgumentException oshezna){}
                 no seria capaza de cachar ningun otro tipo de excepsion, es decir las execpsiones del parseo, no serian handleadas y el programa explotaria
                 tendria entonces que poner un catch para cada tipo de excepsion
                 */
                Console.ResetColor();
            }
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
