namespace _7._2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CheckClass
    {
        public static void CheckIfInt(this string number)
        {
            Type type = typeof(int);
            Type numberType = Convert.ToInt32(number).GetType();
            if ((type == numberType) && (Convert.ToInt32(number) > 0))
            {
                Console.WriteLine("This positive number's type is int");
            }
            else
            {
                Console.WriteLine("This is not a positive int");
            }
        }
    }

    public class Program3Part2
    {
        public static void Main(string[] args)
        {
            string number = "25";
            number.CheckIfInt();
            Console.ReadKey();
        }
    }
}
