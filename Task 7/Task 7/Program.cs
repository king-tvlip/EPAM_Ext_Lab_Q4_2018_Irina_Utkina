namespace Task_7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class WorkWithArray
    {
        public static int FindSum(this int[] array, int suma)
        {
            foreach (int number in array)
            {
                suma += number;
            }

            return suma;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[5] { 1, 2, 3, 4, 5 };
            int sum = 0;
            sum = array.FindSum(sum);
            Console.WriteLine(sum);
        }
    }
}
