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

    /*
        si por ejemplo queremos saber cada que se añade una grade podemos estar monitoreando el evento 
    "grade added"

   usamos object como el sender porque la clase objecto soporta todos los tipos y todas las clases ya creadas o que creemos nosotros
    el sender es quien esta enviando o generando el evento
    args es cualquier info adicional que quieras EventArgs es una clase generica puedes pasar informacion
    */
    public delegate void GradeAddedDelegate(object sender, EventArgs args); // esto en buenas practicas se haria en otro archivito por separado

    public class Book /* si no se le pone el modificador de acceso "public" por default sera de tipo internal aunque no lo tenga explicitamente es decir
        si esta solo como " class Book " se infiere que es internal por lo tanto no se podra usar en otros proyectos*/
    {
        //Fields (campos o propiedades)
        public List<double> grades; // como estamos en una clase, todos los campos o propiedades no pueden ser declarados como var
        private string name; // como es private toda forma de acceder a este campo sera por medio de metodos definidos dentro de la clase
        public string Name;
        public static string Description="Grade Books"; // esa es una propiedad a la que no se puede acceder con la instancia si no directo de a clase
        /*
         Los eventos tambien pueden ser miembros de clase, es decir estamos diciendo que en algun metodo la clase tiene un evento el evento es 
         GradeAdded
         */
        public event GradeAddedDelegate GradeAdded;

        //Methods (Metodos)
        //los metodos deben ser lo mas pequeños posibles.
        public string GetName() { 
        return name;
        }
        public void AddGrade(double grade) //tipo tipoRetorno nombreMetodo(){} 
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

                book.GradeAdded=algo; esto seria la subscripsion al evento
                */
                if (GradeAdded != null) 
                { 
                    GradeAdded(this, EventArgs.Empty);
                }
                
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} :( "); //nameof regresa literalmente el nombre de una variable 

            }
            //todas las variables que se creen dentro de las {} existiran unicamente en ese bloque, si quisieramos que vivieran en mas partes del codigo
            // tendriamos que ponerlas tan afuera de las {} como sea necesario
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



            Console.WriteLine($"{name}'s {Book.Description} Stats \n •Lowest Grade: {statistics[0]:N2} \n •Highest Grade: {statistics[1]:N2} \n •Average Grade: {(statistics[2] / statistics.Length):N2}");
        }
        

        // Constructor 
        /*el constructor es lo que construye al objeto, uno puede hacer su propio "constructor de clase" de tal modo que se puede tener total control de 
         la inicializacion de un objeto de esa clase, en escencia el constructor es un metodo, por tanto este "metodo" tendra el mismo nombre que la clase 
         este metodo se ejecutara en cuanto se instancie el objeto con la keyword new */

        public Book(string name) // en este caso el constructor es Book() porque la clase es Book
        {
            grades = new List<double>();
            this.name = name; // this hace referencia a "name" este name de la clase no del costructor "this" sirve para acceder a un miembro de this class de esta clase
            this.Name = name;    
        }

    }
}
