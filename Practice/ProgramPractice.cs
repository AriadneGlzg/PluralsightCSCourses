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
            var x = "alohita"; //las variables con tipo var deben ser inicializadas en el momento que se crean, ya sea con un valor como tal, o una expresion. EL var es de tipo implicito es decir
            //el compilador decide que tipo de variable es en el momento que se inicializa, por lo tanto si se inicializa como un string, siempre sera un string en el codigo, no como en JS
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
}

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
    
    
 
 */
