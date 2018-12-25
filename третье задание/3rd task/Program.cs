namespace _3rd_task
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="Program" />
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        public static void Main(string[] args)
        {
            string get_num = string.Empty;
            int new_num = -1;
            Tasks task = new Tasks();
            while (new_num != 0)
            {
                Console.WriteLine("If you'd like to start/ to continue performing tasks, " +
                    "Enter the last number(s) of the task(except for 2, 3, 4) - the ones after the dot. " +
                    "If you'd like to exit the program, press 0.");
                get_num = Console.ReadLine();
                int.TryParse(get_num, out new_num);
                if (new_num == 1)
                {
                    task.First();
                }
                else if (new_num == 2)
                {
                    task.Second();
                }
                else if (new_num == 3)
                {
                    task.Third();
                }
                else if (new_num == 4)
                {
                    task.Fourth();
                }
                else if (new_num == 5)
                {
                    task.Fifth();
                }
                else if (new_num == 6)
                {
                    task.Sixth();
                }
                else if (new_num == 7)
                {
                    task.Seventh();
                }
                else if (new_num == 8)
                {
                    task.Eight();
                }
                else if (new_num == 9)
                {
                    task.Nineth();
                }
                else if (new_num == 10)
                {
                    task.Tenth();
                }
                else if (new_num == 11)
                {
                    task.Eleventh();
                }
                else if (new_num == 12)
                {
                    task.Twelveth();
                }
                else if (new_num == 13)
                {
                    task.Thirteen();
                }
                else if (new_num == 0)
                {
                    Console.WriteLine("Thank you for participating!");
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Defines the <see cref="Tasks" />
        /// </summary>
        public class Tasks
        {
            /// <summary>
            /// The First
            /// </summary>
            public void First()
            {
                string height = string.Empty, width = string.Empty;
                int h = 0, w = 0;
                Console.WriteLine("Enter the height and width in following order ( each must be a positive number over 0) : ");
                height = Console.ReadLine();
                width = Console.ReadLine();
                int.TryParse(height, out h);
                int.TryParse(width, out w);
                while ((h <= 0) || (w <= 0))
                {
                    Console.WriteLine("Error! Enter two positive numbers over 0");
                    height = Console.ReadLine();
                    width = Console.ReadLine();
                    int.TryParse(height, out h);
                    int.TryParse(width, out w);
                }

                Console.Write("the area of rectangle with width = " + " " + w + "and height = " + " " + h + "is" + " " + h * w);
            }

            /// <summary>
            /// The Second
            /// </summary>
            public void Second()
            {
                Console.WriteLine("Enter the number less than 20:");
                string n = string.Empty;
                int k = 0;
                n = Console.ReadLine();
                int.TryParse(n, out k);
                while ((k > 20) || (k < 0))
                {
                    Console.WriteLine("Error! the number is greater than 20. try again!");
                    n = Console.ReadLine();
                    int.TryParse(n, out k);
                }

                n = string.Empty;
                for (int i = 0; i < k; i++)
                {
                    n += "*";
                    Console.WriteLine(n);
                }
            }

            /// <summary>
            /// The Third
            /// </summary>
            public void Third()
            {
                Console.WriteLine("Enter the positive integer number less than 20:");
                string n = string.Empty;
                n = Console.ReadLine();
                int m = 0;
                int.TryParse(n, out m);
                while (m > 20)
                {
                    Console.WriteLine("Error! the number is greater than 20! try again.");
                    n = Console.ReadLine();
                    int.TryParse(n, out m);
                }

                n = string.Empty;
                ////заполнение строки
                int count = m, cycle = 1, an_count = 0;
                while (an_count != m)
                {
                    for (int i = count; i > -1; i--)
                    {
                        Console.Write(" ");
                    }

                    count -= 1;
                    for (int j = 0; j < cycle; j++)
                    {
                        Console.Write("*");
                    }

                    cycle += 2;
                    an_count += 1;
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// The Fourth
            /// </summary>
            public void Fourth()
            {
                string m = string.Empty;
                int n = 0;
                Console.WriteLine("Enter the positive integer number less than 10:");
                m = Console.ReadLine();
                int.TryParse(m, out n);
                while ((n >= 10) || (n < 0))
                {
                    Console.WriteLine("error! the number is greater than 10! try again.");
                    m = Console.ReadLine();
                    int.TryParse(m, out n);
                }

                int count = n, cycle = 1, an_count = 0, counter = 2;
                ////первая строка с одной *
                for (int i = n; i > -1; i--)
                {
                    Console.Write(" ");
                }

                Console.Write("*");
                Console.WriteLine();
                ////количество елочек
                for (int k = 0; k < n; k++)
                {
                    ////отсчет строчек
                    while (an_count != counter)
                    {
                        for (int i = count; i > -1; i--)
                        {
                            Console.Write(" ");
                        }

                        count -= 1;
                        for (int j = 0; j < cycle; j++)
                        {
                            Console.Write("*");
                        }

                        cycle += 2;
                        an_count += 1;
                        Console.WriteLine();
                    }

                    counter += 1;
                    an_count = 0;
                    cycle = 1;
                    count = n;
                }
            }

            /// <summary>
            /// The Fifth
            /// </summary>
            public void Fifth()
            {
                int sum = 0, counter = 0;
                while (counter < 1000)
                {
                    if ((counter % 3 == 0) || (counter % 5 == 0))
                    {
                        sum = sum + counter;
                    }

                    counter = counter + 1;
                }

                Console.Write("The sum is:" + " " + sum);
            }

            /// <summary>
            /// The Sixth
            /// </summary>
            public void Sixth()
            {
                {
                    int[] mas = new int[3];
                    string param1 = "Bold", param2 = "Italic", param3 = "Underline";
                    ////string num = string.Empty;
                    int get_num = -1;

                    while (get_num != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter the parameter: ");
                        Console.WriteLine("Bold ------- 1");
                        Console.WriteLine("Italic ----- 2");
                        Console.WriteLine("Underline -- 3");
                        Console.WriteLine("For exit --- 0");
                        Console.WriteLine();

                        int.TryParse(Console.ReadLine(), out get_num);

                        if (get_num == 1)
                        {
                            if (mas[0] == 0)
                            {
                                mas[0] = 1;
                            }
                            else
                            {
                                mas[0] = 0;
                            }
                        }

                        if (get_num == 2)
                        {
                            if (mas[1] == 0)
                            {
                                mas[1] = 1;
                            }
                            else
                            {
                                mas[1] = 0;
                            }
                        }

                        if (get_num == 3)
                        {
                            if (mas[2] == 0)
                            {
                                mas[2] = 1;
                            }
                            else
                            {
                                mas[2] = 0;
                            }
                        }

                        ////вывод на консоль
                        Console.WriteLine();

                        if (mas[0] == 1)
                        {
                            Console.WriteLine(param1);
                        }

                        if (mas[1] == 1)
                        {
                            Console.WriteLine(param2);
                        }

                        if (mas[2] == 1)
                        {
                            Console.WriteLine(param3);
                        }
                    }
                }
            }

            /// <summary>
            /// The Seventh
            /// </summary>
            public void Seventh()
            {
                int compare_numb = 0;
                int bubble = 0;
                int[] numbers = new int[12];
                Random rand = new Random();
                ////filling-in the array numbers[12]
                for (int counter = 0; counter < 12; counter++)
                {
                    numbers[counter] = rand.Next(30, 100);
                }

                ////searching the maximum
                for (int counter = 0; counter < 12; counter++)
                {
                    if (compare_numb < numbers[counter])
                    {
                        compare_numb = numbers[counter];
                    }
                }

                Console.WriteLine("The maximum number is:" + compare_numb);

                ////searching the minimum
                compare_numb = 100;
                for (int counter = 0; counter < 12; counter++)
                {
                    if (numbers[counter] < compare_numb)
                    {
                        compare_numb = numbers[counter];
                    }
                }

                Console.WriteLine("The minimum number is:" + compare_numb);
                ////sorting the array from min to max
                for (int counter = 1; counter >= 11; counter--)
                {
                    if (numbers[counter - 1] > numbers[counter])
                    {
                        bubble = numbers[counter];
                        numbers[counter - 1] = numbers[counter];
                        numbers[counter] = bubble;
                    }
                }

                for (int counter = 0; counter < 12; counter++)
                {
                    Console.Write(numbers[counter] + " ");
                }
            }

            /// <summary>
            /// The Eight
            /// </summary>
            public void Eight()
            {
                const int Dim1 = 7;
                const int Dim2 = 7;
                const int Dim3 = 5;
                Random rand = new Random();
                int[,,] arr = new int[Dim1, Dim2, Dim3];
                for (int i = 0; i < Dim1; i++)
                {
                    for (int j = 0; j < Dim2; j++)
                    {
                        for (int k = 0; k < Dim3; k++)
                        {
                            arr[i, j, k] = rand.Next(-50, 12);
                        }
                    }
                }

                for (int i = 0; i < Dim1; i++)
                {
                    for (int j = 0; j < Dim2; j++)

                    {
                        for (int k = 0; k < Dim3; k++)

                        {
                            if (arr[i, j, k] > 0)
                            {
                                arr[i, j, k] = 0;
                            }

                            Console.WriteLine("arr [" + i + "]" + "[" + j + "]" + "[" + k + "]" + " " + arr[i, j, k]);
                        }
                    }
                }
            }

            /// <summary>
            /// The Nineth
            /// </summary>
            public void Nineth()
            {
                const int Dim = 18;
                int sum = 0;
                int[] arr = new int[Dim];
                Random rand = new Random();
                for (int counter = 0; counter < Dim; counter++)
                {
                    arr[counter] = rand.Next(-50, 50);
                    Console.WriteLine("arr[" + counter + "]" + arr[counter]);
                    if (arr[counter] >= 0)
                    {
                        sum = arr[counter];
                    }
                }

                Console.WriteLine("Sum of elements is:" + sum);
            }

            /// <summary>
            /// The Tenth
            /// </summary>
            public void Tenth()
            {
                const int Dim1 = 5;
                const int Dim2 = 7;
                int sum = 0;
                Random rand = new Random();
                int[,] arr = new int[Dim1, Dim2];
                for (int i = 0; i < Dim1; i++)
                {
                    for (int j = 0; j < Dim2; j++)
                    {
                        arr[i, j] = rand.Next(-50, 50);
                        if ((i + j) % 2 == 0)
                        {
                            sum = arr[i, j];
                        }
                    }
                }

                for (int i = 0; i < Dim1; i++)
                {
                    for (int j = 0; j < Dim2; j++)
                    {
                        Console.Write(arr[i, j] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("The sum of numbers such as dim1 and dim2 are being divided by 2 is:" + sum);
            }

            /// <summary>
            /// The Eleventh
            /// </summary>
            public void Eleventh()
            {
                Console.WriteLine("enter the text in less than 128 symbols:");
                string text = Console.ReadLine();
                ////assuming that each letter is a word in a sentence
                int[] mas = new int[128];
                int sum = 0, avg_length = 0, count_words = 0;
                for (int counter = 0; counter < text.Length; counter++)
                {
                    if (Char.IsLetterOrDigit(text, counter) == true)
                    {
                        sum += 1;
                    }
                    else
                    {
                        mas[counter] = sum;
                        sum = 0;
                    }
                }

                for (int counter = 0; counter < 128; counter++)
                {
                    if (mas[counter] != 0)
                    {
                        count_words += 1;
                    }

                    avg_length = mas[counter] + avg_length;
                }

                if (count_words == 0)
                {
                    Console.WriteLine("Error! You didn't enter a single word! Try again.");
                }
                else
                {
                    avg_length = avg_length / count_words;
                    Console.WriteLine("The average word length is:" + avg_length);
                }
            }

            /// <summary>
            /// The Twelveth
            /// </summary>
            public void Twelveth()
            {
                string firstString = string.Empty;
                string secondString = string.Empty;
                string finalString = string.Empty;
                Console.WriteLine("Enter the first string:");
                firstString = Console.ReadLine();
                Console.WriteLine("enter the second string:");
                secondString = Console.ReadLine();
                foreach (char ch in firstString)
                {
                    if (!secondString.Contains(ch))
                    {
                        finalString += ch;
                    }
                    else
                    {
                        finalString += ch;
                        finalString += ch;
                    }

                    Console.WriteLine("Результат = {0}", finalString);
                }
            }

            /// <summary>
            /// The Thirteen
            /// </summary>
            public void Thirteen()
            {
                string str = string.Empty;
                string star = "*";
                StringBuilder sb = new StringBuilder();
                int n = 1000;
                Stopwatch swatch = new Stopwatch();
                int new_counter = 13;
                FileStream output_file = new FileStream("TextFileTest.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(output_file);
                    while (new_counter != -1)
                    {
                        swatch.Start();
                        for (int i = 0; i < n; i++)
                        {
                            sb.Append("*");
                        }

                        swatch.Stop();
                        TimeSpan ts = new TimeSpan();
                        ts = swatch.Elapsed;
                        /*Console.WriteLine(ts.ToString());*/
                        writer.WriteLine("class StringBuilder time:" + "   " + ts.ToString());
                        new_counter--;
                        swatch.Reset();
                    }

                new_counter = 13;
                    while (new_counter != -1)
                    {
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();
                        for (int i = 0; i < n; i++)
                        {
                            str += star;
                        }

                        stopWatch.Stop();
                        //// Get the elapsed time as a TimeSpan value.

                        TimeSpan times = stopWatch.Elapsed;
                        //// Format and display the TimeSpan value.

                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", times.Hours, times.Minutes, times.Seconds, times.Milliseconds);
                        /*Console.WriteLine("RunTime " + elapsedTime);*/
                        writer.WriteLine("class String time:" + "   " + elapsedTime);
                        new_counter--;
                        stopWatch.Reset();
                    }

                writer.Close();
            }
        }
    }
}
