namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Strings_to_compare
    {
        public delegate List<string> Comparison(List<string> stroka);

        public List<string> Compare_strings(List<string> strlist)
        {
            ////возвращает длину строки

            for (int i = 0; i < 2; i++)
            {
                if (strlist[i + 1].Length < strlist[i].Length)
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

        public List<string> Order_strings(List<string> strlist)
        {
            ////экземпляр делегата

            Comparison compare = new Comparison(this.Compare_strings);
            strlist = compare(strlist);
            return strlist;
        }

        public void Clear(List<string> strlist)
        {
            strlist.Clear();
        }

        public void Show_array(List<string> strlist)
        {
            foreach (string sentence in strlist)
            {
                Console.WriteLine(sentence);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Strings_to_compare stringe = new Strings_to_compare();
            var strlist = new List<string>() { "first line", "secon line", "third line" };
            stringe.Order_strings(strlist);
            stringe.Show_array(strlist);
            Console.ReadKey();
        }
    }
}
