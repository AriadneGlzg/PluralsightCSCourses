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
        //Fields (campos o propiedades)
        List<double> grades; // como estamos en una clase, todos los campos o propiedades no pueden ser declarados como var
        private string name; // como es private toda forma de acceder a este campo sera por medio de metodos definidos dentro de la clase
        public static string Description="Grade Books"; // esa es una propiedad a la que no se puede acceder con la instancia si no directo de a clase
        
        //Methods (Metodos)
        public void AddGrade(double grade) //tipo tipoRetorno nombreMetodo(){} 
        {
            grades.Add(grade);
            //todas las variables que se creen dentro de las {} existiran unicamente en ese bloque, si quisieramos que vivieran en mas partes del codigo
            // tendriamos que ponerlas tan afuera de las {} como sea necesario
        }

        public void ShowStatistics()
        {
            var statistics = new double[3];
            foreach (var grade in grades)
            { 
                statistics[0]=Math.Min(grades[0], grade);
                statistics[1]=Math.Max(grades[1], grade);
                statistics[2] += grade;
            }
            Console.WriteLine($"{name}'s {Book.Description} Stats \n •Lowest Grade: {statistics[0]:N2} \n •Highest Grade: {statistics[1]:N2} \n •Average Grade: {(statistics[2]/statistics.Length):N2}");
        }

        // Constructor 
        /*el constructor es lo que construye al objeto, uno puede hacer su propio "constructor de clase" de tal modo que se puede tener total control de 
         la inicializacion de un objeto de esa clase, en escencia el constructor es un metodo, por tanto este "metodo" tendra el mismo nombre que la clase 
         este metodo se ejecutara en cuanto se instancie el objeto con la keyword new */

        public Book(string name) // en este caso el constructor es Book() porque la clase es Book
        {
            grades = new List<double>();
            this.name = name; // this hace referencia a "name" este name de la clase no del costructor "this" sirve para acceder a un miembro de this class de esta clase
        }

    }
}
