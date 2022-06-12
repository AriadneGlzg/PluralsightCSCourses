using Gradebook;
using System;
using Xunit; // se trae el namespace de la libreria se Xunit

namespace GradebookTestUnit
{
    public class UnitTest1
    {
        [Fact] /*Esto es una decorador propio de xUnit esto indica que un metodo es una prueba unitaria.
        tal modo que xUnit ignorara todo que no tenga ese decorador*/
        public void Test1()
        {
            /* Arrange Section: es donde se ponen todos los datos de prueba y objetos que se van a usar */
            var book = new InMememoryBook("Paola");
            var x = 5;
            var y = 2;
            var expected = 7;

            /* Act Section: en esta parte es donde se pone la invocacion de metodos o las instrucciones,
             * es donde se hace algo para producir un resultado "actual result" */
            var actual = x + y;
            
            /* Assert Section: donde se corrobora que el valor que fue computado dentro de la Act Section sea el esperado*/

            Assert.Equal(expected,actual);
        }
    }
}
