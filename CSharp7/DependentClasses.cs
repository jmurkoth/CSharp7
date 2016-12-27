using System;

namespace Csharp7
{
    public abstract class Shape
    {
        public abstract double CalculateArea();

    }
    public class Square : Shape
    {
        public double Length { get; set; }
        public override double CalculateArea() =>  Length * Length;

        public override string ToString() => string.Format($" I am a square with  Length : {Length:#,###.##} ");
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double CalculateArea() => Math.PI * Radius * Radius;
      
        public override string ToString() => string.Format($" I am a circle with Radius : {Radius:#,###.##} ");
    
        public void Deconstruct(out double radius, out double area)
        {
            radius = Radius;
            area = CalculateArea();
        }
        public void AreaPick(out double area) => area = CalculateArea();
     
    }
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Height { get; set; }
        public override double CalculateArea() => Length * Height;
      
        public override string ToString()=> string.Format($" I am a Rectangle with Length: {Length:#,###.##} and height  {Height:#,###.##} ");
 
        public void Deconstruct(out double length, out double height, out double area)
        {
            length = Length;
            area = CalculateArea();
            height = Height;
        }
    }

    public class Bogus : Shape
    {
        public int Length { get; set; }
 
        public Bogus(int? length=null)=> Length= length ?? throw new ArgumentNullException(nameof(length));
       

        public override double CalculateArea() => throw new NotImplementedException();
      
    }
}
