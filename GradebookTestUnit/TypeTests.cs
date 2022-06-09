using System;
using Xunit; // se trae el namespace de la libreria se Xunit
using Gradebook; //se usa todo lo que sea accesible (public) dentro del proyecto Gradebook

//cuando un proyecto tiene un nombre como Gradebook.Test es una forma de decir que esta dentro de Gradebook pero en el apartado test
namespace GradebookTestUnit
{
    public class TypeTests 
    {
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
            var book2 = book1;
            //Act
            book1.Name = "Book3";
            // Assert Section
            Assert.Equal("Book3", book1.Name);
            //Assert.Equal("Book 1", book2.Name);  
       
            Assert.Same(book1, book2); //es para ver si son la misma instancia en la memoria
            Assert.True(Object.ReferenceEquals(book1,book2));

            /* 
            como var lo que guarda es el valor de una referencia book1 y book2 van a estar apuntando a la misma
            referenica incluso cuando tienen diferentes nombres.
            en la linea 34 falla  la prueba unitaria porque book1 cambio de nombre y book 2 sigue apuntando a la misma
            referencia que aunque se modifico a travez de book1 afecta a book2 porque siguen apuntondo a la misma referencia
            por lo tanto cualquier cambio que se haga en book1 o book2 afectara a ambas variables
            */

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
