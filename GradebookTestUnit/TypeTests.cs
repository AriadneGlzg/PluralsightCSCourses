using System;
using Xunit; // se trae el namespace de la libreria se Xunit
using Gradebook; //se usa todo lo que sea accesible (public) dentro del proyecto Gradebook

//cuando un proyecto tiene un nombre como Gradebook.Test es una forma de decir que esta dentro de Gradebook pero en el apartado test
namespace GradebookTestUnit
{
    public class TypeTests 
    {        
        [Fact]
        public void StringBehavesAsValueType2()
        {
            string name = "Paola";
            name = OverwriteUpperCasse(name); /*aqui ahora si se hace el overwrite, 
            parece ser que el overwrite debe hacerse fuera de los metodos en el mismo lugar {} donde
            existe la variable*/            
            Assert.Equal("PAOLA", name);
        }
        private string OverwriteUpperCasse(string parameter)
        {
            return parameter.ToUpper();
            /*El metodo no va a sobreescribir como tal lo que le mandes solo va a retronar una
             nueva string*/
        }
        [Fact]
        public void StringBehavesAsValueType()
        {
            string name = "Paola";
            MakeUpperCasse(name);
            Assert.NotEqual("PAOLA", name);
        }  

        private void MakeUpperCasse(string parameter) 
        {
            parameter.ToUpper();
            /* como las strings son una clase deberian pasar una referencia, que si lo hacen
            pasan una referencia pero son inmutables justo como los value types, por eso este
            metodo no va a cambiar el valor de name de "paola" a "PAOLA" de hecho como son 
            inmutables las strings, muchos de los metodos no modifican la variabe en si, mas 
            bien retornan una copia modificada de la string a la que se le aplica el metodo*/
        }

        [Fact]
        public void CSPassRef()
        {
            //Arrange
            var x = GetInt(); 

            //Act
            SetIntWithRef(ref x); /* A diferencia del metodo SetInt() aqui le decimos al metodo, te voy a pasar una
            reference a una variable, no su value, por eso este nuevo metodo es capaz de cambiar el valor de x*/
            //Asserts
            Assert.Equal(88, x); /*en x esta el value 11 no la referencia al numero 11*/
            /*
             En las variables que guardan ints o value types son inmutables lo que se hace constantemete es hacer un overwrite 
             de lo que hay en esas variables
             */
        }
        private void SetIntWithRef(ref int x)
        {
            /*La variable local x se le pasa el value de quien lo invoque en este caso de x del test que es 3,
             por lo tanto al cambiar el value de x estamos cambiando el value de this.x la variable local, esto 
             implica que no generara un cambio en la variable x que se paso como parametro en el test
             */
            x = 88; // la x de este metodo
        }

        [Fact]
        public void CSPassValue() //por default en un metodo siempre pasamos el value
        {
            //Arrange
            var x = GetInt(); //esto retorna un value 11 que se guarda en x, x guarda un value no una ref
            //Act
            SetInt(x); /* aqui solo pasamos el valor 11 al metodo, no la ref a x para que x guardara el 88
                        tendriamos que pasar la ref y no el value */
            //Asserts
            Assert.Equal(11, x); /*en x esta el value 11 no la referencia al numero 11*/


        }
        private void SetInt(int x) 
        {
            /*La variable local x se le pasa el value de quien lo invoque en este caso de x del test que es 3,
             por lo tanto al cambiar el value de x estamos cambiando el value de this.x la variable local, esto 
             implica que no generara un cambio en la variable x que se paso como parametro en el test
             */
            x = 88; // la x de este metodo
        }

        private int GetInt()
        {
            return 11;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            //Act
            GetBookSetNameR( ref book1, "New Name♥"); /*mandamos una referencia que no se puede cambiar a metodo
            se puede cambiar el valor del objeto a quien hace referencia pero no la referencia en si
            se hace el invike by reference*/
            /*tambien se puede usar out en lugar de ref*/
            //Assert
            Assert.Equal("New Name♥", book1.Name);
           
        }

        private void GetBookSetNameR(ref InMememoryBook book, string name)
        {
            /*Aqui le decimos al metodo que pase a book la referencia como tal y no el value de referencia
             por lo tanto aunque abajo se haga un nuevo objeto, la ref va a seguir siendo la de book1*/
            book = new InMememoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            //Act
            var book2 = GetBookSetName(book1, "New Name♥"); /* aqui estamos pasando book1 que es una referencia a un objeto de tipo Book
            que de hecho creo un nuevo objeto por tanto tendra habra una nueva referencia*/
            
            //Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.NotSame(book2, book1);
            /*En los metodos tu pasas un value, por ejemplo en book1 al pasarlo a GetBookSetName() ahi estamos pasando el valor de la
             referencia, no la referencia en si, es decir book tendra el valor de la referencia a book1 y mientras no cambiemos esa
            referencia podemos seguir haciendo cambios a book1 por medio de la ref en book, pero al cambiar el valor de la referencia
            en book como se hizo con el book =  new Book (name) ahi se hizo el cambio de ref y por eso al final book y book1 terminan
            siendo objetos distintos*/
  
        }

        private InMememoryBook GetBookSetName(InMememoryBook book, string name)
        {
            book = new InMememoryBook(name); /* aqui se crea el nuevo objeto, lo que se modifica es la referencia nueva, antes book tenia la 
            * referencia a book1 y ahora tiene una referencia a un objeto de tipo Book distinto, book deja de guardar la referencia a 
            * book1 y ahora guarda la referencia del new Book. Por lo tanto despues de esa linea book y book1 son dos referencias
            * a objetos diferentes, esto es un invoke by value . Aqui se le hace overwrite a la referencia                       
            */
           
            return book;

            /*
             Cuendo se pasa una variable a un metodo no se quiere que el metodo cambie de manera inesperada la variable original o la 
            referencia de la variable, esto es posible solo porque aunque en book se hizo una copia de book1, al momento de instanciar
            el nuevo objeto en book, es como si la copia de la referencia se reemplazara por la del nuevo objeto, y eso sin afectar a book
             */
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            //Act
            SetName(book1, "New Name♥");
            //Assert
            Assert.Equal("New Name♥", book1.Name);

           /* 
            Si se puede modificar un objeto desde su referencia, porque estas pasando el value del la ref
            */
        }

        private void SetName(InMememoryBook book, string name)
        {
            book.Name = name;
            /*
             book tiene la referencia de book1 y todo el tiempo se modifica book1 con la variable local
             book porque este guarda la ref, en ningun momento se cambia la referencia que guarda book
             */
        }

        [Fact] 
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange/Act
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // Assert Section
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1,book2);
            // esta prueba unitaria demuestro como dos var pueden ser dos objetos o referencias diferentes
            // en este caso se guarda la referencia del objeto que se creo en GetBook()

        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange
            var book1 = GetBook("Book 1"); //var guarda valores esos valores pueden ser referencias o punteros
            var book2 = book1; //se guarda la referencia a book1 en book2
            //Act
            book1.Name = "Book3";
            // Assert Section
            Assert.Equal("Book3", book1.Name);
            //Assert.Equal("Book 1", book2.Name);  
       
            Assert.Same(book1, book2); //es para ver si son la misma instancia en la memoria
            Assert.True(Object.ReferenceEquals(book1,book2));//ambos apuntan a la misma referencia

            /* 
            como var lo que guarda es el valor de una referencia book1 y book2 van a estar apuntando a la misma
            referenica incluso cuando tienen diferentes nombres.
            en la linea 34 falla  la prueba unitaria porque book1 cambio de nombre y book 2 sigue apuntando a la misma
            referencia que aunque se modifico a travez de book1 afecta a book2 porque siguen apuntondo a la misma referencia
            por lo tanto cualquier cambio que se haga en book1 o book2 afectara a ambas variables
            */

        }
        InMememoryBook GetBook(string name)
        {
            return new InMememoryBook(name);
        }
    }
}
