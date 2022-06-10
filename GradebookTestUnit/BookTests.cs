using System;
using Xunit; // se trae el namespace de la libreria se Xunit
using Gradebook; //se usa todo lo que sea accesible (public) dentro del proyecto Gradebook

//cuando un proyecto tiene un nombre como Gradebook.Test es una forma de decir que esta dentro de Gradebook pero en el apartado test
namespace GradebookTestUnit
{
    public class BookTests 
    {
        [Fact] 
        public void TestStatistics()
        {
            // Arrange Section
            var book = new Book("",0);
            book.AddGrade(58.1);
            book.AddGrade(80.0);
            book.AddGrade(60.5);
            book.AddGrade(100);
          
            // Act Section

            var result = book.GetStatistics();

            // Assert Section
            Assert.Equal(74.6, result.Average,1);
            Assert.Equal(58.1, result.Lowest);
            Assert.Equal(100, result.Highest);
            Assert.Equal('C', result.LetterGrade);

        }
        [Fact]
        public void NoGreaterThat100()
        {
            var book = new Book("",0);
            book.AddGrade(101);
            Assert.Equal(0,book.grades.Count);
            
        }

        [Fact]
        public void NoLowerThanZero()
        {
            var book = new Book("",0);
            book.AddGrade(-0.01);
            Assert.Empty(book.grades);

        }

        [Fact]
        public void AddGrade()
        {
            var book = new Book("",0);
            book.AddGrade(85);
            Assert.NotEmpty(book.grades);

        }

    }
}
