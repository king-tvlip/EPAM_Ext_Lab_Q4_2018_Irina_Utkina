namespace Task_7_part_3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class FirstMethod
    {
        public void DirectSort(int[] intArray)
        {
            Console.WriteLine("Direct sort:");
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] > 0)
                {
                    Console.WriteLine(intArray[i]);
                }
            }
        }
    }

    public class SecondMethod
    {
        public delegate bool Condition(int number);

        public bool DelegateCondition(int number)//todo pn весь метод можно написать одной строкой.
        {
            bool result = true;
            if (number > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public void ThroughDelegate(int[] intArray)
        {
            Console.WriteLine("Sort through delegate:");
            Condition condition = new Condition(this.DelegateCondition);
            for (int i = 0; i < intArray.Length; i++)
            {
                if (condition(intArray[i]) == true)
                {
                    Console.WriteLine(intArray[i]);
                }
            }
        }
    }

    public class ThirdMethod //todo pn не понял смысла создания класса на каждый из методов.
    {
        public delegate void Condition(int number);

        public bool DelegateCondition(int number)//todo pn дублирование кода
        {
            if (number > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ThroughAnonymous(int[] intArray)
        {
            Console.WriteLine("Sort through anonymous method:");
            Condition condition = delegate(int number)
            {
                if (this.DelegateCondition(number) == true)
                {
                    Console.WriteLine(number);
                }
            };
            foreach (var num in intArray)
            {
                condition(num);
            }
        }
    }

    public class FourthMethod
    {
        public delegate bool Condition(int number);

        public void ThroughLambda(int[] intArray)
        {
            Console.WriteLine("Sort through Lambda expression:");
            for (int i = 0; i < intArray.Length; i++)
            {
                Condition condition = result => intArray[i] > 0;
                if (condition(intArray[i]) == true)
                {
                    Console.WriteLine(intArray[i]);
                }
            }
        }
    }

    public class FifthMethod
    {
        public void SearchThroughLinq(int[] intArray)
        {
            Console.WriteLine("Sort through Linq:");
            var selection = from number in intArray
                            where number > 0
                            select number;
            foreach (var num in selection)
            {
                Console.WriteLine(num);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] intArray = { 1, -1, 2, -2, 3, -3, 4, -4 };
            Stopwatch stopwatch = new Stopwatch();
            int iter = 10;
            StreamWriter writer = File.CreateText("Analysis.txt");
            while (iter != 1000000)
            {
                FirstMethod first = new FirstMethod();
                stopwatch.Start();
                first.DirectSort(intArray);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("First method: " + elapsedTime);
                iter *= 10;
            }

            iter = 10;
            while (iter != 1000000)
            {
                SecondMethod second = new SecondMethod();
                stopwatch.Restart();
                second.ThroughDelegate(intArray);//todo pn нужно передавать делегат в метод, а ты передаешь только массив.
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("Second method: " + elapsedTime);
                iter *= 10;
            }

            iter = 10;
            while (iter != 1000000)
            {
                ThirdMethod third = new ThirdMethod();
                stopwatch.Restart();
                third.ThroughAnonymous(intArray);//todo pn аналогично
				stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("Third method: " + elapsedTime);
                iter *= 10;
            }

            iter = 10;
            while (iter != 1000000)
            {
                FourthMethod fourth = new FourthMethod();
                stopwatch.Restart();
                fourth.ThroughLambda(intArray);//todo pn аналогично
				stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("Fourth method: " + elapsedTime);
                iter *= 10;
            }

            iter = 10;
            while (iter != 1000000)
            {
                stopwatch.Restart();
                FifthMethod fifth = new FifthMethod();
                fifth.SearchThroughLinq(intArray);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("Fifth method: " + elapsedTime);
                iter *= 10;
            }

            writer.Close();
            Console.ReadKey();
        }
    }
}
