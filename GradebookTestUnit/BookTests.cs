using System;
using Xunit; // se trae el namespace de la libreria se Xunit
using Gradebook; //se usa todo lo que sea accesible (public) dentro del proyecto Gradebook

//cuando un proyecto tiene un nombre como Gradebook.Test es una forma de decir que esta dentro de Gradebook pero en el apartado test
namespace GradebookTestUnit
{
    public class BookTests 
    {
        [Fact] 
        public void Test1()
        {
            // Arrange Section
            var book = new Book("");
            book.AddGrade(58.1);
            book.AddGrade(80.0);
            book.AddGrade(60.5);
            book.AddGrade(100);


            // Act Section


            // Assert Section


        }
    }
}
