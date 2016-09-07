using System;
using System.Collections.Generic;

namespace Csharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            TuplesDemo();
            // demo showing out variables
            OutVariables();
            IsDemo();
            CaseStatementDemo();
            DeconstructDemo();
            Console.ReadLine();
        }
      
        static void TuplesDemo()
        {
            var m = TupleTesting();
            Console.WriteLine($"First Name : {m.firstName} Middle :{ m.middle}, Last:{m.lastName}");
        }
        static (string firstName, string middle, string lastName) TupleTesting()
        {
            return (firstName: "John", middle: "C", lastName: "Doe");
        }
        static void OutVariables()
        {
            var inputValue = "12121";
            Console.WriteLine("****OUT VARIABLES*****");
            //Currently this works because value is within the scope of the if statement
            if (int.TryParse(inputValue, out int value))
            {
                Console.WriteLine($"{value} is a valid integer");
            }
            var circ = new Circle { Radius = 100 };
            // Below  does not work in Preview 4 but will work in future per the C# team
            //GetArea(circ, out double area);
            //Console.WriteLine($"Circle area is { area}");
        }

        static void IsDemo()
        {
            Console.WriteLine("****PATTERN MATCHING IS STATEMENT*****");
            var num = 12343;
            // note how i is pattern matched  to an integer
            // scope is limited to the if statement
            if(num is int i)
            {
                Console.WriteLine($"{i:#,###}");
            }
        }

        static void CaseStatementDemo()
        {

            List<Shape> shapes = new List<Shape>
            {
                new Circle { Radius=10 },
                new Rectangle {Length=10, Height=12 },
                new Square {Length=10 },
                new Rectangle {Length=10,Height=10 },
                null
            };
            Console.WriteLine("****CASE STATEMENT*****");
            // case statement on type
            foreach (Shape item in shapes)
            {
                switch (item)
                {
                    case Circle c:
                        Console.WriteLine($"Radius:{c.Radius}");
                        Console.WriteLine(c.ToString());
                        break;
                    case Square sq:
                        Console.WriteLine($"Length:{sq.Length}");
                        Console.WriteLine(sq.ToString());
                        break;
                    // pattern match on type and additional when condition 
                    case Rectangle sqrect when (sqrect.Length == sqrect.Height):
                        Console.WriteLine("I am still a square");
                        Console.WriteLine(sqrect.ToString());
                        break;
                    case Rectangle rect:
                        Console.WriteLine($"Length:{rect.Length} Height :{rect.Height}");
                        Console.WriteLine(rect.ToString());
                        break;
                    default:
                        Console.WriteLine("Unknown shape");
                        break;
                    case null:
                        Console.WriteLine("You Passed me a null");
                        break;
                }
            }
        }

        static void DeconstructDemo()
        {
            Console.WriteLine("****DECONSTRUCTION*****");
            var rect = new Rectangle { Length = 100, Height = 20 };
            // Invokes the Deconstruct method on the object 
            var (len, hght, area) = rect;
            Console.WriteLine($"Rectangle with Length:{len},Height {hght},area {area}");
            var circ = new Circle { Radius = 100 };
            // Invokes the Deconstruct method on the object 
            var (radius, carea) = circ;
            Console.WriteLine($"Radius:{radius},area {carea}");
            //another example of deconstruction
            var (first, middle, last) = TupleTesting();
            Console.WriteLine($"First Name : {first} Middle :{ middle}, Last:{last}");

        }

      
    }

 
}
