using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public abstract class Figure
    {
        public double basee { get; set; }
        public double height { get; set; }

        public Figure(double height, double basee) 
        {
            this.basee = basee;
            this.height = height;
        }
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        public virtual void ShowData() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Area:{CalculateArea()}\nPerimeter: {CalculatePerimeter()}");
            Console.ResetColor();
        }
    }

    public class Square : Figure
    {
        public Square(double basee) : base(basee, basee) { }
        
        public override double CalculateArea()
        {
            return (height * height);
        }

        public override double CalculatePerimeter()
        {
            return (height * 4);
        }
    }

    public class Rectangle : Figure
    {
        public Rectangle(double b, double h) : base(b, h) { }

        public override double CalculateArea()
        {
            return (height * basee);
        }

        public override double CalculatePerimeter()
        {
            return ((height + basee) * 2);
        }
    }

    public class Triangle : Figure
    {
        public Triangle(double b, double h) : base(b, h) { }

        public override double CalculateArea()
        {
            return ((height * basee)/2);
        }

        public override double CalculatePerimeter()
        {
            var c = Math.Sqrt(height * height + basee * basee);
            return (2*c + basee);
        }
    }

    public class Circle : Figure
    {
        public Circle(double radio) : base(radio, 0) { }

        public override double CalculateArea()
        {
            return (Math.PI*height);
        }

        public override double CalculatePerimeter()
        {
            return (2*Math.PI*height);
        }
        public override void ShowData()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Area:{CalculateArea()}\nPerimeter: {CalculatePerimeter()}");
            Console.ResetColor();
        }
    }
}
