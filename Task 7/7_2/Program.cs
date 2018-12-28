using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_2
{
    public static class CheckClass
    {
        public static bool CheckIfInt(this int number)
        {
            Type type = typeof(int);
            Type NumberType = number.GetType();
            if(type == NumberType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 15;
            bool check = number.CheckIfInt();
            Console.ReadKey();
        }
    }
}
