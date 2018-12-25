namespace Task6._2
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
            Queue<Person> personQueue = new Queue<Person>();
            Person new_person = new Person("Anna", 9);
            Person second_person = new Person("Mary", 13);
            Person third_person = new Person("Seba", 18);
            new_person.CameToWork(new_person.PersonName, new_person.ArrivalTime, personQueue);
            second_person.CameToWork(second_person.PersonName, second_person.ArrivalTime, personQueue);
            third_person.CameToWork(third_person.PersonName, third_person.ArrivalTime, personQueue);
            new_person.LeftWork(new_person.PersonName, personQueue);
            Console.ReadKey();
        }
    }
}
