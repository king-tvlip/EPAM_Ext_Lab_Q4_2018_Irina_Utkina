namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Strings_to_compare
    {
        public delegate bool Comparison(string stroka1, string stroka2);

        public List<string> CompareStrings(List<string> strlist)
        {
            ////возвращает длину строки
            for (int i = 0; i < 2; i++)
            {
                Comparison compare = new Comparison(this.StringsCondition);
                if (compare(strlist[i], strlist[i + 1]) == true)
                {
                    var newstring = strlist[i];
                    strlist[i] = strlist[i + 1];
                    strlist[i + 1] = newstring;
                }
                else
                {
                    strlist.Sort();
                }
            }

            return strlist;
        }

        ////метод сортировки
        public bool StringsCondition(string str1, string str2)
        {
            ////экземпляр делегата
            bool result = true;
            if (str1.Length > str2.Length)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        ////очистка списка строк
        public void Clear(List<string> strlist)
        {
            strlist.Clear();
        }

        ////вывод списка в консоль
        public void Show_array(List<string> strlist)
        {
            foreach (string sentence in strlist)
            {
                Console.WriteLine(sentence);
            }
        }
    }

    public class Program6Part1
    {
        public static void Main(string[] args)
        {
            Strings_to_compare stringe = new Strings_to_compare();
            var strlist = new List<string>() { "first line", "secon line", "third line" };
            stringe.CompareStrings(strlist);
            stringe.Show_array(strlist);
            Console.ReadKey();
        }
    }
}

