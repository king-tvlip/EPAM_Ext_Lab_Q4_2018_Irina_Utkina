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

    public class Methods
    {
        public delegate bool Condition(int number);

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

        public bool DelegateCondition(int number)
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

        public void ThroughDelegate(Condition condition, int[] intArray)
        {
            Console.WriteLine("Sort through delegate:");
            condition = this.DelegateCondition;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (condition(intArray[i]) == true)
                {
                    Console.WriteLine(intArray[i]);
                }
            }
        }

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

    public class Program3Part3
    {
        public static void Main(string[] args)
        {
            int[] intArray = { 1, -1, 2, -2, 3, -3, 4, -4 };
            Stopwatch stopwatch = new Stopwatch();
            int iter = 10;
            StreamWriter writer = File.CreateText("Analysis.txt");
            Methods first = new Methods();
            while (iter != 1000000)
            {
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
                Methods.Condition condition = new Methods.Condition(first.DelegateCondition);
                stopwatch.Restart();
                first.ThroughDelegate(condition, intArray);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("Second method: " + elapsedTime);
                iter *= 10;
            }

            iter = 10;
            while (iter != 1000000)
            {
                bool DELegateCondition(int number)
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

                Methods.Condition conDITION = delegate(int number)
                {
                    if (DELegateCondition(number) == true)
                    {
                        Console.WriteLine(number);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };

                void ThroughAnonymous(Methods.Condition COndition, int[] IntArray)
                {
                    Console.WriteLine("Sort through anonymous method:");
                    foreach (var num in intArray)
                    {
                        conDITION(num);
                    }
                }

                stopwatch.Restart();
                ThroughAnonymous(conDITION, intArray);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                string elapsedTime = ts.ToString();
                writer.WriteLine("Third method: " + elapsedTime);
                iter *= 10;
            }

            iter = 10;
            while (iter != 1000000)
            {
                Methods.Condition condition = number => number > 0;
                void ThroughLambda(Methods.Condition Condition, int[] IntArray)
                {
                    Console.WriteLine("Sort through Lambda expression:");
                    for (int i = 0; i < IntArray.Length; i++)
                    {
                        if (Condition(IntArray[i]) == true)
                        {
                            Console.WriteLine(IntArray[i]);
                        }
                    }
                }

                stopwatch.Restart();
                ThroughLambda(condition, intArray);
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
                first.SearchThroughLinq(intArray);
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
