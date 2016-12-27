using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp7
{
    /// <summary>
    /// Class used to demonstrate the functionality
    /// </summary>
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
            DigitSeparatorDemo();
            BinaryLiteralDemo();
            ReturnRef();
            LocalFunctions();
            ThrowExpression();
            Console.ReadLine();
        }
      
        /// <summary>
        /// Method demonstrating Tuples
        /// </summary>
        static void TuplesDemo()
        {
            Console.WriteLine("****TUPLES DEMO*****");
            var m = TupleTesting();
            Console.WriteLine($"First Name : {m.firstName} Middle :{ m.middle}, Last:{m.lastName}");
        }
        static (string firstName, string middle, string lastName) TupleTesting()
        {
            return (firstName: "John", middle: "C", lastName: "Doe");
        }

        /// <summary>
        /// Method demonstrating Out variables
        /// </summary>
        static void OutVariables()
        {
            var inputValue = "12121";
            Console.WriteLine("****OUT VARIABLES*****");
            // Below line will not compile
           // Console.WriteLine($"{value} is a valid integer");
            if (int.TryParse(inputValue, out int value))
            {
                Console.WriteLine($"{value} is a valid integer");
            }
            // value available here - scope is now beyond the if
            Console.WriteLine($"{value} is a valid integer");
            var circ = new Circle { Radius = 100 };
        
            GetArea(circ, out double area);
            Console.WriteLine($"Circle area using out variables is { area}");
            circ.AreaPick(out double area2);
            Console.WriteLine($"Circle Area #2 using out variables {area2}");
        }

        private static void GetArea(Circle circ, out double area)
        {
            area = circ.CalculateArea();
        }

        /// <summary>
        /// Method demonstrating pattern matching with is
        /// </summary>
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
            Console.WriteLine($"{i:#,###}");
        }

        /// <summary>
        /// Method demonstrating pattern matching in switch statement
        /// </summary>
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
            Console.WriteLine("****SWITCH STATEMENT PATTERN MATCHING*****");
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
        /// <summary>
        /// Method demonstrating the deconstruct functionality
        /// </summary>
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

              
        static  void DigitSeparatorDemo()
        {
            Console.WriteLine("****DIGIT SEPARATORS*****");
            // We can use _ as a digit separator
            int myval = 123_3_4_343;
            Console.WriteLine(myval);
        }
        static void BinaryLiteralDemo()
        {
            Console.WriteLine("****BINARY LITERAL*****");
            // Binary literal with digit separator
            var b = 0b10_01_1100_010_00;
            //should write out 5000;
            Console.WriteLine(b);
        }

        static void ReturnRef()
        {
            Console.WriteLine("****RETURN REFERENCE*****");
            int[] array = { 1, 15, -39, 0, 7, 14, -12 };
             ref int place = ref FindasRef(7, array); // aliases 7's place in the array
            place = 9; // replaces 7 with 9 in the array
            Console.WriteLine(array[4]); // prints 9
            int p1 = Find(9, array);
            p1 = 100;
            Console.WriteLine(array[4]); // still prints 9
        }

        static void ThrowExpression()
        {
            Console.WriteLine("****THROW EXPRESSION*****");
            try
            {
                Bogus boguscls = new Bogus();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            try
            {
                Bogus boguscls = new Bogus(25);
                boguscls.CalculateArea();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        static void LocalFunctions()
        {
            Console.WriteLine("****LOCAL FUNCTIONS*****");
            int[] num = new int[] { 1, 2, 3, 4, 6, 7, 7, 8, 8 };
            // can be called before declaration
            var (s1, c1) = Calculate(num);
            Console.WriteLine($"sum :{s1} count :{c1}");
            (int sum, int count) Calculate(int[] numbers)
            {
                int s = 0;
                numbers.ToList().ForEach(c => s += c);
                return (sum: s, count: numbers.Length);
            }
            // can be called after declaration
            var (s2, c2) = Calculate(num);
            Console.WriteLine($"sum :{s2} count :{c2}");

        }
        public static  int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return  numbers[i]; // return the storage location, not the value
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }
        public static ref int FindasRef(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // return the storage location, not the value
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }
    }

 
}
