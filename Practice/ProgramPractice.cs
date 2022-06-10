using System; //Systems es un namespace
using System.Collections.Generic;

namespace Practice // el namespace es una keyword que se usa para declarar un scope que contiene varios objetos relacionados, el namespace se puede definir como un contenedor
    //es por eso que cuando haces una carpeta por default el visual pone como namespace el nombre de la carpeta, por tanto dentro de un namespace, habran cosas relacionadas,
    //estas pueden ser clases, interfaces, estructuras, enums, delegados etc. para usar elementos de un namespace en otro se usa la keyword "using" y el nombre del namespace
{
    //por ejemplo en todos los preoyectos en el archivo program hay un namespace con el nombre del proyecto y dentro viene la clase "PROGRAM", esto es porque dentro del namespace
    //pueden haber todas las clases y cosas que yo quiera, incluso en el mismo archivo. Si vamos a crear una clase la syntaxis es la siguiente

    class Book // keyword class nombre {} dentro de las llaves  iran todos los atributos o metodos necesarios, tu puedes poner dentro del mismo
    { //archivo todas las clases que se quieran, pero por buenas practicas se ponen en otro archivo por una cuestion de organizacion
        public string name; //campo
        public int pages { get; private set; }//propiedad

        public const string CATEGORY = "Dark Knowladge ♥"; //campo

        public Book(string name, int pages) {
            this.name = name;
            this.pages = pages;
        }
    }

    internal class ProgramPractice
    {   //main es un metodo de punto de entrada de una aplicacion en c# cuando la aplicacion se inicializa el metodo main es el primer en ser invocado
        // el main puede o no tener el parametri de "args", ese string array es para argumentos de linea de comandos
        // estos argumentos se pueden pasar desde el cmd con el donet o en el menu principal en debbug/depuracion -->properties/propiedades--> argumentos de linea de comando, ahi se ponen

        //en C# Las clases definen nuevos tipos, estos "types" nos permiten hacer ciertas cosas, por ejemplo un list<double> es un tipo, Console es un tipo que tiene direntes metodos para interactuar con la consola
        // las clases tambien nos ayudan a encapsular el codigo 

        static void Main(string[] args) // dentro del metodo puede haber parametros en el metodo main se pasa un array de tipo string de nombre "args"
        {
            //variables y como usarlas ♥
            int a = 12;
            var x = "alohita"; /*las variables con tipo var deben ser inicializadas en el momento que se crean, ya sea con un valor como tal, o una expresion. EL var es de tipo implicito es decir
            el compilador decide que tipo de variable es en el momento que se inicializa, por lo tanto si se inicializa como un string, siempre sera un string en el codigo, no como en JS
            esto debido a que las variables realmente son punteros, es decir guardan una referencia en memoria del objeto o tipo que se esta guardando
            */
            var y = $"{x} existe en x";
            var z = a * 13.81;

            //♥ Arrays
            float[] floatNums; // la numeracion empiezan en cero 
            var numArray = new float[5]; // de esta forma hay un array con 5 espacios vacios, el valor que habra en cada espacio hasta que se indique lo contrario, sera el nullo de cada tipo
            int[] intNum = { 1, 2, 3, 4 }; //podemos hacer un array poniendo explicitamente el tipo
            var numbers = new double[] { 1, 1.1, -87.5 };
            var varNum = new[] { "paola", "aloha" };

            //♥ Listas
            var grades = new List<double> { 15.1, 87.5, 90, 57.2, 65.0, 33, 12.1, 28.1, 37 }; //la capacidad por default va en saltos de 2^n comienza en 4, cuando hay 5 elementos entonces la capacidad brinca a 16, si hay 17 brinca a 32 y asi            var g2 = grades[0];
            var g2 = grades[2]; 
            grades[2] = 28.5;
            grades.Capacity = 9; // fijamos una capacidad de 9
            grades.Add(29);
            Console.WriteLine($"{g2} {grades[2]} capacity: {grades.Capacity} count: {grades.Count}");
            grades.Add(29); // si se excede la capacidad puesta la capacidad automaticamente se dublicara, en este caso a 18

        // ♥ Ciclos 

        /* la diferencia entre el while y el do while es que el do while se ejecuta al menos una vez
        extrañamente necesita que se cierre el statemente con un ;
        el for es basicamente lo mismo jiji se inicializa el index; se da una condicion ; los aumentos o decrementos del index
        for (var index = 0; index < grades.Count; index++) { }
        for (var index = grades.Count; index < 0; index--) { }
        */
        done:
            Console.WriteLine("Goto linea 58 ♥"); // ejemoplo del goto

            var resultado=0.0;
            for (int indice = 0; indice < grades.Count; indice++)
            {
                if (grades[indice] == 33) 
                {
                    break; //al ejecutarse el break en ese momento salimos del for y todos los estatementes debajo del break seran ignorados sale de golpe
                }
                resultado += grades[indice]; // si ocurre el break esta linea ya no se ejecutara porque saldreemos del ciclo
            }
            resultado/=grades.Count;
            Console.WriteLine($"Grade Average is: {resultado:N2}");
            
            resultado=0;
            for (int indice = 0; indice < grades.Count; indice++)
            {
                if (grades[indice] == 33)
                {
                    continue; //al ejecutarse el continue sale de esa iteracion, pero no del ciclo
                    // es decir se va a saltar hacer el statemente de abajo pero volvera a la siguiente iteracion del for
                }
                resultado += grades[indice];
            }
            resultado /= grades.Count;
            Console.WriteLine($"Grade Average is: {resultado:N2}");
            resultado = 0;
            Console.WriteLine($"En la siguiente instruccion entramos al for del goto");
            for (int indice = 0; indice < grades.Count; indice++)
            {
                if (grades[indice] == 33)
                {
                    goto done2;
                    goto done; //al ejecutarse el continue sale de esa iteracion, pero no del ciclo
                    // es decir se va a saltar hacer el statemente de abajo pero volvera a la siguiente iteracion del for
                    //el puntero se regresa a la linea donde le digas y se sigue ejecutando desde ahi por lo tanto harias un
                    //un ciclo infinito, solo si la etiqueta esta lineas arriba si esta abajo solo se saltara partes del codigo
                }
                resultado += grades[indice];
            }
            resultado /= grades.Count;
            Console.WriteLine($"Grade Average is: {resultado:N2}");
            
            done2:  Console.WriteLine("Se salto el calculo del average");

            /*
             El break statement te bota del ciclo que contiene a ese break, si hay ciclos anidados solo se saldra del ciclo que lo contenga
             Esto implica que si abajo de lo que habia en el break habia mas statmentes, no se ejecutaran y saldra por completo del ciclo brincandose los
             statements que pudieran faltar en la iteracion-
             
            
                ejemplo:
                for (i=10; i>=0 ; i--){
                    for (j=1; j<15 ; j++){
                        if (j==5){
                            break;    <-- ahi solo saldra del for (j=1; j<15 ; j++) pero no del otro for
                        }
                    }   
                }

             */
            // ♥ Instanciar objetos


            /*List<double> gError; // al hacer algo asi reciviriamos una NullReferenceException es un error que indica un gran fallo e logica
            gError.Add(25.1); // aqui hay un error porque nunca se instancio o inicializo realmente la variable gError
            el error de arriba se soluciona haciendo la instancia vacia */

            /* el operador "new" crea una instancia de un tipo, es decir crea el objeto como tal, hace un objeto de tipo book como en ese caso
            como los objetos de clases son complejos para crear la instancia debes porner cuales son sus propiedades etc,
            si solo quieres como reservar el espacio se pone el ()
            
            No es casualidad que hacer "new Book ()" o "new ()" paresca un metodo eso es porque por detras .NET runtime invoca un metodo llamado
            "constructor method", el constructor es lo que valga la redundancia consruye al objeto, uno puede hacer su propio constructor de 
            clase de tal modo que se puede tener total control de la inicializacion de la clase
             */
            List<double> list = new();//new List<double> (); tambien se soluciona de esa forma 
            list.Add(88.2);
            Book booktest = new("Into Osezna's Mind",11);
            Console.Write(Book.CATEGORY);
            // en la memoria cuando hacemos (suponiendo que existe una clase "Book") Book gradebook = new () la memoria dice la variable "gradebook" hace referencia a un objeto del tipo "Book"
            // si hacemos Book gradebook = null; null es una forma de decir que una varible no hace referencia a un objeto, en general se trata de evotar trabajar con nullos

            if (args.Length > 0) //esto es un if statement
            {   //Console es un tipo
                Console.WriteLine($"Hello, {args[1]} {numArray.Length} \"{numArray[0]}\" "); // esto seria un statement que invoca al metodo WriteLine el ; sirve para darle fin al statement.
            }

            else
            {
                Console.WriteLine("Hello there are no args in main method ♥"); // por cierto el motodo WriteLine es un static public
            }

        }
    }
}/*
        Delegados y Eventos 
  
  */

/* Switch with pattern matching
 
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
 
 */

/*  ♥ Acess Modifiers
    controlan el acceso que se tiene de un miembro en particular de una clase. Acceso a metodos, campos o incluso a la misma clase.
    -Public: el miembro puede ser accesado por cuaquier codigo en el mismo conjunto de codigo, o incluso en otro poyecto
    -Private: da acceso solo al codigo que este dentro de esa definicion de clase (o estructura), por lo tanto toda manipulacion de quien tenga el
     modificador "private" tendra que ser manejado dentro de la clase.
    -Interna: Solo se puede usar dentro de ese assambley o proyecto
    -Protected: da acceso al codigo que este dentro de esa definicion de clase o dentro de clases derivadas de esa misma clase.
*/

/*
    Static Modifier ♥ 
    decir que un miembro es estatico o si se usa static en su declaracion indica que dicho miembro no esta asociado a un objeto a a una instancia
    si no al tipo entro del que estan definidos (es decir a la clase). Es decir como por ejemplo la clase Console dentor de Console esta definido
    el metodo WriteLine, para usar esa funcion no es necesario hacer c1 = new Console (); y despues c1.WriteLine(); es decir para hacer uso del 
    miembro no es necesario (y de hecho no se puede) hacer un objeto de clase (una instancia) para acceder al miembro, si no que se accede al 
    metodo desde la misma clase, esto hasta cierto puento va en contra de la programacion orientada a objetos, pero puede ser util si por ejemplo 
    se quiere hacer una clase que encapsule puros metodos o constantes como la clase "Math", o si se requiere de algunos metodos dentro de la clase que sean static
 */


/*exceptions
 -NullReferenceException: indica que hay algo dañado en tu codigo, algun error de logica
 
 */

/* Reference Type vs Values Type 
Esto de los reference y values tiene que ver con como se almacenan estos en memoria.
  
Reference Type
    siempre que se usa una clase (ya sea que tu la hagas o que sea parte de .NET) hacemos una referencia a un objeto de cierta clase
    var b = new book("Grades"); esto es un reference type
    
    lo que se guarda en la memoria es la direccion de memoria donde esta el objeto de tipo book de modo que b sera algo asi como 1070
    entonces se guarda tanto la direccion de memoria como los valores valores que tenga el objeto

Values Type
    var x = 3; 
    el runtime en el espacio de memoria no guarda la direccion como con la referencia, si no que guarda el valor en si mismo
    los value types son por ejemplo todos los tipos de numeros int, float y double, toda variable que sea de ese tipo sera un 
    value type
    En un metodo, los parametros siempre se pasan by value, es decir aunque el parametro sea un objeto que por su naturaleza es un
    reference type lo que se pasa es el value de la referencia, no la referencia en si. A menos de que le especifiquemos lo contrario
    al metodo


Rules

Siempre que trabajemos con algo que sea definido con una clase, estamos trabajando con un reference type, esto sera un puntero a un 
espacio de memoria.

    public class Person // toda variable que venga de una clase, va a estar guardando una referencia al objeto.
    {
        
    }

Una struct se comporta como un value type, le puedes dar fields y metodos a una estructura como a una clase, pero a la vez es mas
debe ser mas simple que una class, las estructuras siempre son value types de hecho la definicion de Float, Int, Double 
DateTime, Boolean son estructuras

    public struct Point
    {
    
    }
Un caso especial son las string es un reference type, pero a menudo se comporta como un value type    
    
 
 */

/* Runtime Garbage Collector
 el runtime tracks todos los objetos que hemos creado, y sabe sobre todos los campos de un objeto que pueden apuntar a otras variables
cuando nadie esta usando el objeto o alguno de sus campos entonces lo elimina. Si sale del scope tambien lo elimina

*/


/* Branch Flow
    
    
*/

/*   Try-Catch | throw Exception
  
        throw new ArgumentException($"Invalid {nameof(grade)} :( "); //nameof regresa literalmente el nombre de una variable 

     cuando un error sucede por la razon que sea el programa crashea y se detiene 
     dejando un mensaje de porque se detuvo. El termino tecnico para esto en c# 
     es que el codigo tiro/arrojo (throw) una excepsion (exception) es decir que 
     arrojo un error.

     Si quiero que no se detenga el programa que no crashee necesito manejar esa
     Exception. Esto se hace con un bloque try catch
*/