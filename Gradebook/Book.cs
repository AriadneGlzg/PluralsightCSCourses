using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* -Creamos clases con el proposito de tener abstraccion y encapsilamiento, de tal modo que la complejidad que escondida dentro de la clase
   -Una clase es un blueprint un molde de un objeto, instanciar una clase es crear un objeto*/
namespace Gradebook // el namespace es el mismo que el del proyecto
{
    //lo que tiene la llavesita en el intellicense es un atributo o propiedad, lo que tiene el cubito son metodos.
    //lo que hacemos con las clases es darles un comportamiento en base a los metodos que establecemos en ellos y sus propiedades.
    //Para este gradebook lo que queremos es porder pasarle una calificacion y que la guarde.

    /*
        si por ejemplo queremos saber cada que se añade una grade podemos estar monitoreando el evento 
    "grade added"

   usamos object como el sender porque la clase objecto soporta todos los tipos y todas las clases ya creadas o que creemos nosotros
    el sender es quien esta enviando o generando el evento
    args es cualquier info adicional que quieras EventArgs es una clase generica puedes pasar informacion
    */
    public delegate void GradeAddedDelegate(object sender, EventArgs args); // esto en buenas practicas se haria en otro archivito por separado
    //Interfaz
    public interface IBook
    { /*la interfaz define todo lo que por fuerza debe existir en las clases que hereden de ella, la interfaz no se preocupa
       sobre como sera la implementacion (de hecho no debe haber ningun cuerpo de metodo, en las clases abstractas si) la implementacion
        ya sera problema de quien herede de ella
       */
        void AddGrade(double grade);
        Statistics GetStatistics();
        event GradeAddedDelegate GradeAdded;
    }
    public class NameObject
    { 
        public string Name { get; set; }

        public NameObject(string name) 
        {
        Name = name;
        }

        public string NamePretty()
        {
            return $"{Name} ♥";
        }
    }
    /*Con el fin de demostrar la herencia de clases haremos que book herede de NameObject y de la interfaz IBook*/
    public abstract class Book : NameObject, IBook
    {
        /*forzosamente todos los miembros que tengan las clases hijas deberan tener todos los
         miembros de clase del padre, si usamos la palabra "abstract" estamos obligando a las clases
         hijas a sobreescribir el metodo (override)*/
        public Book(string name) : base(name) 
        {
        }
        // implementaciones de la IBook
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract Statistics GetStatistics(); //cuando un metodo es abstract puede no tener cuerpo de implementacion, cuando es override si
        // fin de IBook
        public abstract void AddGrade(double grade); //es como si lo dejaramos declarado para que alguien
        //mas lo implemente
    }
    public class DiskBook : Book
    {

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
        public List<double> grades;
        public DiskBook(string name) : base(name) { }
        
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade) //tipo tipoRetorno nombreMetodo(){} 
        {
            string path= @"C:\Users\1105a\Desktop\Gradebook_practice\";
            if (!File.Exists($"{path}{Name}2.txt")) 
            {
              var file = File.CreateText($"{path}{Name}2.txt");
                file.Close();
                
            }
            
            if (grade <= 100 && grade >= 0) 
            {
                /*
                var write=File.AppendText($"{path}{Name}2.txt"); //abrimos el archivo
                write.WriteLine(grade); // escribimos en el
                write.Close(); //cerramos el archivo
                */
                using (var write = File.AppendText($"{path}{Name}2.txt"))
                {
                    write.WriteLine(grade);
                    /*El codigo de arriba es equivalente a este, la keyword tiene un overload
                     que nos permite tener un espacio de codigo donde podemos escribir codigo y al
                     final usa el metodo dispose para el parametro que se le manda.
                     Crea un try catch finally statement para cerrar archivos bases de datos etc. Cuando 
                     sales de las llaves del using el compilador te garantiza que va a llamar el metodo 
                     dispose para el objeto que quieras disposear que se pasa como parametro en el using
                    
                     Este es util y se usa mucho cuando estamos usando archivos o cosas que necesiten ser cerradas.
                     */

                }

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, EventArgs.Empty); //this de que es este objeto
                    }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} :( "); 

            }
        }

        public void AddGrade(string letter)
        {

            switch (letter.ToUpper())
            {
                case "A":
                    AddGrade(90);
                    break;
                case "B":
                    AddGrade(80);
                    break;
                case "C":
                    AddGrade(70);
                    break;
                case "D":
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
    }
    
    public class InMememoryBook : Book /* si no se le pone el modificador de acceso "public" por default sera de tipo internal aunque no lo tenga explicitamente es decir
        si esta solo como " class Book " se infiere que es internal por lo tanto no se podra usar en otros proyectos*/
    {
        //Fields (campos o propiedades)
        public List<double> grades; // como estamos en una clase, todos los campos o propiedades no pueden ser declarados como var
        private string name; // como es private toda forma de acceder a este campo sera por medio de metodos definidos dentro de la clase
        //public string Name; Ahora se puede no poner el nombre porque el nombre ya se provee por la clase padre NameObject
        public static string Description="Grade Books"; // esa es una propiedad a la que no se puede acceder con la instancia si no directo de a clase
        /*
         Los eventos tambien pueden ser miembros de clase, es decir estamos diciendo que en algun metodo la clase tiene un evento el evento es 
         GradeAdded
         */
        public override event GradeAddedDelegate GradeAdded; /* sin el virtual en el evento de la clase padree (que hereda de una interfaz) y el override aqui marcaria un warning porque seria como
        declarar dos veces el evento, para solucionar eso hay dos opciones, o borramos la declaracion aqui o les ponemos el public y override*/

        //Methods (Metodos)
        //los metodos deben ser lo mas pequeños posibles.
        public string GetName() { 
        return name;
        }

        //al agregar la palabra override hacemos la implementacion del metodo AddGrade definido en BookBase
        public override void AddGrade(double grade) //tipo tipoRetorno nombreMetodo(){} 
        {
            if (grade <= 100 && grade >= 0) // en los || si la condicion de la izquierda se cumple ya no checa la de la derecha
            {
                grades.Add(grade);

                /*.. aqui podria haber un algo que alertara que se ejecuto el metodo
                pero no tiene porque ser responsabilidad del libro monitorear quien 
                quere saber a quien le importa el evento.

                esto se puede hacer con un delegado ya que el delegado va a estar apuntando
                al metodo.
                
                Ese algo sera el delegado al evento, revisamos que el delegado no sea nulo, es decir en algun punto
                alguien que cree un objeto de tipo book tendra que asignarle un metodo a GradeAdded

                book.GradeAdded += MetodoManejadorDelEvento; esto seria la subscripsion al evento en la parte del codigo
                a quien le interese el event sobre el objeto book de tipo Book

                con que no sea nulo hace referencia a que se le haya asignado un evento como en la parte arriba, es decir
                que se haya hecho la subscripsion
                */
                if (GradeAdded != null)
                { 
                    GradeAdded(this, EventArgs.Empty); //this de que es este objeto
                }
                
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} :( "); //nameof regresa literalmente el nombre de una variable 

            }
            //todas las variables que se creen dentro de las {} existiran unicamente en ese bloque, si quisieramos que vivieran en mas partes del codigo
            // tendriamos que ponerlas tan afuera de las {} como sea necesario
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();statistics.Lowest = double.MaxValue;statistics.Highest = double.MinValue;
            foreach (var grade in grades)
            {
                statistics.Highest = Math.Max(statistics.Highest, grade);
                statistics.Lowest = Math.Min(statistics.Lowest, grade);
                statistics.Average += grade;
            }
            statistics.Average /= grades.Count;

            switch (statistics.Average) 
            {
                case var average when (average >= 90.0): // la variable var average recibira lo que haya en statics.Average
                    statistics.LetterGrade = 'A';
                    break;
                case var average when (average >= 80.0):
                    statistics.LetterGrade = 'B';
                    break;
                case var average when (average >= 70.0):
                    statistics.LetterGrade = 'C';
                    break;
                case var average when (average >= 60.0):
                    statistics.LetterGrade = 'D';
                    break;
                default:
                    statistics.LetterGrade = 'F';
                    break;
            }

            return statistics;
        }
        public void AddLetterGrade(string letter)
        {
            
            switch (letter.ToUpper())
            {
                case "A":
                    AddGrade(90);
                    break;
                case "B":
                    AddGrade(80);
                    break;
                case "C":
                    AddGrade(70);
                    break;
                case "D":
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        // con la funcion anterior podriamos reducir y reusar codigo de la siguiente forma:
        public void ShowStatistics()
        {
            var statistics = new double[] {double.MaxValue,double.MinValue,0};
            var index = 0;
            do
            {
                statistics[0] = Math.Min(statistics[0], grades[index]);
                statistics[1] = Math.Max(statistics[1], grades[index]);
                statistics[2] += grades[index];

                index++;
            } while (index < grades.Count); 



            Console.WriteLine($"{name}'s {InMememoryBook.Description} Stats \n •Lowest Grade: {statistics[0]:N2} \n •Highest Grade: {statistics[1]:N2} \n •Average Grade: {(statistics[2] / statistics.Length):N2}");
        }
        

        // Constructor 
        /*el constructor es lo que construye al objeto, uno puede hacer su propio "constructor de clase" de tal modo que se puede tener total control de 
         la inicializacion de un objeto de esa clase, en escencia el constructor es un metodo, por tanto este "metodo" tendra el mismo nombre que la clase 
         este metodo se ejecutara en cuanto se instancie el objeto con la keyword new 
        
         Cuando se hereda, el constructor que manda es el de la clase padre, por lo tanto cuando hagamos nuenstro constructor
         es necesario poner : base() y en base vamos a pasar todos los parametros que requiera el costructor padre*/


        public InMememoryBook(string name) : base(name)// en este caso el constructor es Book() porque la clase es Book
        {// pedimos el string name en Book y se lo pasamos al padre con base
            grades = new List<double>();
            this.name = name; // this hace referencia a "name" este name de la clase no del costructor "this" sirve para acceder a un miembro de this class de esta clase
            //this.Name = name;    
        }

    }
}
