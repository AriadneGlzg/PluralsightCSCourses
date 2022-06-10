using System;
using System.Collections.Generic;
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
    public class Book /* si no se le pone el modificador de acceso "public" por default sera de tipo internal aunque no lo tenga explicitamente es decir
        si esta solo como " class Book " se infiere que es internal por lo tanto no se podra usar en otros proyectos*/
    {
        //Fields (campos) idealmente todos los campos deben ser privatos, de otro modo se hablaria de una propiedad
        public List<double> grades; // como estamos en una clase, los campos no pueden ser declarados como var
        private string name; // como es private toda forma de acceder a este campo sera por medio de metodos definidos dentro de la clase
        public string Name;
        public static string Description="Grade Books"; // esa es una propiedad a la que no se puede acceder con la instancia si no directo de a clase
        public const string EDITORIAL = "Mi editorial ♥"; /* puede haber campos constantes, por buenas practicas los campos de tipo const (pueden ser privados
        o publicos) se escriben en mayusculas. Logicamente al ser valores constantes son read-only pero aparte son tratados como valores estaticos, es decir no
        hace falta hacer la instancia de clase para accesar a ellos, podriamos a accesar a ellos asi Book.EDITORIAL*/
        private string author; // este es un campo
        public int Pages { get; private set; } /*esto es una propiedad, que solo se puede modificar su valor cuando se instancia el objeto
        /lo anterior la convertiria en una propiedad read-only*/
        readonly string Category="Science"; /* esta es una propiedad de tipo readonly que aunque seria similar a la de arriba no tendrian exactamete las
        mismas propiedades.
        
         poner algo que tenga el modificador de acceso readonly implica que el valor de dicho campo solo se puede settear en la misma definicion del campo
         o propiedad como arriba, o en el constructor. En ningun otro lugar de la clase ni del codigo donde se use la clase se podra settear. 
         */

        /*Property (propiedades)  
         * las propiedades al igual que los campos pueden encapsular estados, y pueden guardar datos del objeto, pero tiene una syntaxis diferente
         * y otros features.
         Basicamente una propiedad de permite exponer un campo, de modo que los campos sean accesibles desde afuera sin que este acceso sea 
         agresivo o intrusivo a la clase
         */
        //con esto voy a exponer al exterior mi campo Author 
        public string Author // esto ya seria una PROPIEDAD que expone al campo "author"
        {//get y set tienen sentido desde afuera de la clase.
            get { return author; }

            set { author = value; } /*value es una variable implicita lo que nos dice es que se le asignara al compo author lo que sea que se le ponga
            si hacemos por ejemplo booktest.Autor = "El Autor" dentro de la propiedad  Autor lo que esta como value vendria siendo "El Autor"
            
            otra singularidad importante es que se le puede agregar el modificador de acceso private al metodo get o set, es decir podemos poner
            private set{author =value; } y esto implicaria que solo se puede poner el valor al campo author cuando se haga la instancia, y despues ya NO
            se podria modificar a menos que esa mpodificacion se hiciera dentro de la clase, es decir en algun metodo.
            */

        }

        // Constructor 
        /*el constructor es lo que construye al objeto, uno puede hacer su propio "constructor de clase" de tal modo que se puede tener total control de 
         la inicializacion de un objeto de esa clase, en escencia el constructor es un metodo, por tanto este "metodo" tendra el mismo nombre que la clase 
         este metodo se ejecutara en cuanto se instancie el objeto con la keyword new 
         El cosntructor determina cuales son los parametros necesarios u obligatorios para inicializar la instancia (el objeto), si por ejemplo hago un
         constructor public book (strig name) forzosamente para instanciar un objeto tendre que pasar un argumento ahi o no se hara la instancia, generando 
         error.

         el constructor vacio ya esta implicito pero si ponemos otro constructor a veces conviene poner el constructor vacio tambien, por si por alguna razon
         necesitamos crear la instancia sin pasarle parametros de inicializacion.

         Esto de hecho es un ejemplo de que al constructor como a cualquier otro metodo se le puede hacer una sobrecarga
         */
        public Book() { } //empty constructor
        public Book(string name, int pages) // en este caso el constructor es Book() porque la clase es Book
        {
            Category = "Cambio";
            grades = new List<double>();
            this.name = name; // this hace referencia a "name" este name de la clase no del costructor "this" sirve para acceder a un miembro de this class de esta clase
            this.Name = name;
            Pages = pages;
        }


        /*Methods (Metodos)
        los metodos deben ser lo mas pequeños posibles.*/
        public string GetName() {
            //author = name; aqui podria modificar esa propiedad que es read-only vista fuera de la clase
            //Category = "Categorias"; esto tira un error porque solo se puede settear en la definicion o el constructir
            return name;
        }
        /* Overloading Methods
             el compilador de c# usa algo llamado method signature para poder reconocer y diferenciar metodos dentro de un tipo
        o clase. La signature consiste de el nombre del metodo y el tipo de los parametros de entrada, es decir si es un char,
        int, class, si lo que se pasa es un value reference o output. 
        
        Esto nos permite hacer un Method overlading, es decir que un metodo dentro del mismo tipo, pueda tener el mismo nombre
        para este ejemplo podriamos hacer overload en el metodo AddGrade para que haga la funcion de AddLetterGrade
        */

        public void AddGrade(double grade) //tipo tipoRetorno nombreMetodo(){} 
        {
            if (grade <= 100 && grade >= 0) // en los || si la condicion de la izquierda se cumple ya no checa la de la derecha
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} :( "); //nameof regresa literalmente el nombre de una variable 

            }
            //todas las variables que se creen dentro de las {} existiran unicamente en ese bloque, si quisieramos que vivieran en mas partes del codigo
            // tendriamos que ponerlas tan afuera de las {} como sea necesario
        }
        public void AddGrade(string letter)
        { /*esto es una sobrecarga al metodo AddGrade, la sobre carga es posible siempre que los parametros de entrada sean diferentes o se añadan
           parametros al metodo por ejemplo aqui la sobre carga se logra cambiando el parametro de entrada a un string.
           */
            
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
        public Statistics GetStatistics()
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



            Console.WriteLine($"{name}'s {Book.Description} Stats \n •Lowest Grade: {statistics[0]:N2} \n •Highest Grade: {statistics[1]:N2} \n •Average Grade: {(statistics[2] / statistics.Length):N2}");
        }
        
    }
}
