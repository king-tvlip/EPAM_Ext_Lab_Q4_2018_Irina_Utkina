namespace _3rd_task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
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
                Int32.TryParse(get_num, out new_num);
                    if (new_num == 1)
                    {
                        task.First();
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
                    else if (new_num == 0)
                    {
                        Console.WriteLine("Thank you for participating!");
                    }
            }

            Console.ReadKey();
        }

        public class Tasks
        {
            public void First()
            {
                string height = string.Empty, width = string.Empty;
                int h = 0, w = 0;
                Console.WriteLine("Enter the height and width in following order ( each must be a positive number over 0) : ");
                height = Console.ReadLine();
                width = Console.ReadLine();
                Int32.TryParse(height, out h);
                Int32.TryParse(width, out w);
                if ((h <= 0) || (w <= 0))
                {
                    Console.WriteLine("Error! Enter two positive numbers over 0");
                    height = Console.ReadLine();
                    width = Console.ReadLine();
                    Int32.TryParse(height, out h);
                    Int32.TryParse(width, out w);
                }

                Console.Write("the area of rectangle with width = " + w + "and height = " + h + "is" + " " + h * w);
            }

            /*public void Second()
            {
                string N = "";
                int iterations = 0, n = 0;
                string star = "*";
                //количество строк со звездами
                Console.WriteLine("Enter the positive number of lines over 0 under 50:");
                N = Console.ReadLine();
                Int32.TryParse(N, out n);
                if ((n > 50) || (n < 0))
                {
                    Console.WriteLine("Error! Enter the positive number of lines OVER 0 UNDER 50:");
                    N = Console.ReadLine();
                    Int32.TryParse(N, out n);
                }
                do
                {
                    for (int i = 1; i < n + 1; i++)
                    {
                        Console.WriteLine(star);
                        iterations += 1;
                    };
                }
                while (iterations < n + 1);
            }
            public void Third()
                {
                    string N = "";
                    string spaces = " ";
                    string stars = "*";
                    int n = 0;
                    Console.WriteLine("Enter the positive number number between 2 and 11:");
                    N = Console.ReadLine();
                    Int32.TryParse(N, out n);
                    int counter = 1;
                    if((n <= 0)||(n > 11))
                    {
                        Console.WriteLine("Error! Enter the POSITIVE number over 2 and less than 11:");
                        N = Console.ReadLine();
                        Int32.TryParse(N, out n);
                };
                    for (int lines = 1; lines < n+1; lines++)
                    //отсчет звездочек
                    {
                    for (int iter = n; iter > 0; iter++)
                    //отсчет пробелов
                    {
                        while (counter != ((iter - 1) / 2))
                        //вычтем середину
                        {
                            Console.WriteLine(spaces);
                            counter += 1;
                        }

                        for (int count = 1; count < lines; count++)
                        {
                            Console.WriteLine(stars);
                        }
                        while (counter != ((iter - 1) / 2))
                        {
                            Console.WriteLine(spaces);
                            counter += 1;
                        }
                    }
                }
                }

            public void fourth()
                {
                string N = "";
                int n = 0;
                Console.WriteLine("Enter the positive integer number less than 10:");
                N = Console.ReadLine();
                Int32.TryParse(N, out n);
                for(int outer_counter = 0; outer_counter < n; outer_counter++)
                    //отсчет количества треугольников
                {

                }
                }*/
            public void Fifth()
            {
                int sum = 0, counter = 1;
                while (counter < 1001)
                {
                    if ((counter % 3 == 0) || (counter % 5 == 0))
                    {
                        sum = sum + counter;
                    }

                    counter = counter + 1;
                }

                Console.Write("The sum is:" + " " + sum);
            }

            public void Sixth()
            {
                int[] mas = new int[3];
                string param1 = "Bold", param2 = "Italic", param3 = "Underline";
                string num = string.Empty;
                int get_num = -1;
                int counter = 0;
                while (get_num != 0)

                {
                    if (counter > 2)
                    {
                        counter = 0;
                    }

                    Console.WriteLine("Enter the parameter: Bold(1), Italic(2), Underline(3) or enter 0 to quit the program:");
                    num = Console.ReadLine();
                    Int32.TryParse(num, out get_num);
                    if (get_num == 1)

                    {
                        ////удаление
                        for (int i = 0; i < 3; i++)
                        {
                            if (mas[i] == 1)
                            {
                                mas[i] = 0;
                            }
                        }
                        mas[counter] = 1;
                    }
                    if (get_num == 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (mas[i] == 2)
                            {
                                mas[i] = 0;
                            }
                        }
                        mas[counter] = 2;
                    }

                    if (get_num == 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (mas[i] == 3)
                            {
                                mas[i] = 0;
                            }
                        }
                        mas[counter] = 3;
                    }

                    counter = counter + 1;
                    ////вывод на консоль
                    for (int i = 0; i < 2; i++)
                    {
                        if (mas[i] == 1)
                        {
                            Console.WriteLine(param1);
                        }
                        if (mas[i] == 2)
                        {
                            Console.WriteLine(param2);
                        }
                        if (mas[i] == 3)
                        {
                            Console.WriteLine(param3);
                        }

                    }
                }
            }

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
            /* public void Twelveth()
             {
                 string first_sentence, second_sentence, overwritten = "";
                 Console.WriteLine("Enter the text in less than 128 symbols:");
                 first_sentence = Console.ReadLine();
                 Console.WriteLine("Enter the second line of text in less than 128 symbols:");
                 second_sentence = Console.ReadLine();
                 /*сраниваем буквы второй строки и удваиваем, если они совпадают с буквами в первой. в противном случае, 
                  * переписываем символ строки так, как он есть

                 for (int counter = 0; counter < second_sentence.Length; counter++)
                 {
                     for (int new_counter = 0; new_counter < first_sentence.Length; new_counter++)
                     {
                         if (first_sentence[new_counter] == second_sentence[counter])
                         {
                             overwritten = overwritten + first_sentence[new_counter] + first_sentence[new_counter];
                         }
                         else
                         {
                             overwritten = overwritten + first_sentence[new_counter];
                         }
                     }
                 }
                 Console.WriteLine("The new sentence is:" + overwritten);
             }*/
            /* public void Twelveth()
             {
                 Console.WriteLine("Enter the first line of text:");
                 string first_string = Console.ReadLine();
                 Console.WriteLine("Enter the second line of text:");
                 string second_string = Console.ReadLine();
                 string overwritten = "";
                 string new_string = "";
                 for(int i = 0; i < second_string.Length; i++)
                 {
                     for(int j = 0; j < first_string.Length; j++)
                     {
                         //символы совпадают
                         if(second_string[i] == first_string[j])
                         {
                             overwritten = overwritten + second_string[i] + second_string[i];
                            new_string = new_string.Insert(j, overwritten.ToString());
                             second_string = second_string.Remove(i, 1);
                             overwritten = "";
                         }
                         else
                         {
                             new_string = new_string.Insert(j, first_string[j].ToString());
                         }
                     }
                 }
                 Console.WriteLine("The new string is" + " " + new_string);
             }*/
        }
    }
}
