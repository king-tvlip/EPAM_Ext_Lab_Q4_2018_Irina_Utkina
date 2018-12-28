namespace _7._2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CheckClass
    {
        public static void CheckIfInt(this int number)
        {
            Type type = typeof(int);
            Type numberType = number.GetType();
            if ((type == numberType) && (number > 0))
            {
                Console.WriteLine("Number's type is int");
            }
            else
            {
                Console.WriteLine("This is not a positive int");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int number = -25;
            number.CheckIfInt();
            Console.ReadKey();
        }
    }
}