using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class strings_to_compare
    {
        public delegate List<string> Comparison(List<string> stroka);
        public List<string> Compare_strings(List<string> strlist)
        {
            ////возвращает длину строки
            for (int i = 0; i < 2; i++)
            {
                if (strlist[i+1].Length < strlist[i].Length)
                {
                    var newstring = strlist[i];
                    strlist[i] = strlist[i + 1];
                    strlist[i + 1] = newstring;
                }
            }
            return strlist;
        }
        //метод сортировки
        public List<string> Order_strings(List<string> strlist)
        {
            ////экземпляр делегата
            Comparison compare = new Comparison(Compare_strings);
            strlist = compare(strlist);
            return strlist;
        }

        public void clear(List<string> strlist)
        {
            strlist.Clear();
        }

        public void show_array(List<string> strlist)
        {
            foreach(string sentence in strlist)
            {
                Console.WriteLine(sentence);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            strings_to_compare stringe = new strings_to_compare();
            var strlist = new List<string>() { "first line", "second line", "third line" };
            stringe.Order_strings(strlist);
            stringe.show_array(strlist);
            Console.ReadKey();
        }
    }
}
