namespace Task6._2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        public Person(string name)
        {
            this.PersonName = name;
        }

        public Person(string name, int arrTime)
        {
            this.PersonName = name;
            this.ArrivalTime = arrTime;
        }

        public delegate void Message(string Name, Queue<Person> PersonQueue);

        public delegate void GreetMessage(string Name, int time, Queue<Person> PersonQueue);

        public event Message Came;

        public event Message Left;

        public int ArrivalTime { get; set; }

        public string PersonName { get; set; }

        public void OnCame(string name, Queue<Person> personQueue)
        {
            if (this.Came != null)
            {
                Console.WriteLine(name + " came to work.");
            }
        }

        public void OnLeave(string name, Queue<Person> personQueue)
        {
            if (this.Left != null)
            {
                Person personAway = personQueue.Dequeue();
                Console.WriteLine(personAway.PersonName + " left office.");
            }
        }

        public void ShowMessage(string message, Queue<Person> personQueue)
        {
            Console.WriteLine(message);
        }

        public void CameToWork(string name, int time, Queue<Person> personQueue)
        {
            Person person = new Person(name, time);
            GreetMessage greetingByPerson = new GreetMessage(person.Greet);
            Message sayByeByPerson = new Message(person.SayBye);
            person.Came += this.ShowMessage;
            person.Left += this.ShowMessage;
            person.OnCame(name, personQueue);

            person.Greet(name, person.ArrivalTime, personQueue);
            personQueue.Enqueue(person);
        }

        public void LeftWork(string name, Queue<Person> personQueue)
        {
            Person person = new Person(name);
            Message sayByeByPerson = new Message(person.SayBye);
            person.Left += this.ShowMessage;
            person.OnLeave(name, personQueue);
            person.SayBye(name, personQueue);
        }

        public void Greet(string name, int time, Queue<Person> personQueue)
        {
            int time1 = 12;
            int time2 = 17;
                if (time < time1)
                {
                    foreach (Person person in personQueue)
                    {
                        Console.WriteLine("Good morning" + "," + " " + name + " said " + person.PersonName);
                    }
                }
                else if ((time >= time1) && (time < time2))
                {
                    foreach (Person person in personQueue)
                    {
                        Console.WriteLine("Good afternoon" + "," + " " + name + " said " + person.PersonName);
                    }
                }
                else if (time >= time2)
                {
                    foreach (Person person in personQueue)
                    {
                        Console.WriteLine("Good evening" + "," + " " + name + " said " + person.PersonName);
                    }
                }
        }

        public void SayBye(string name, Queue<Person> personQueue)
        {
            foreach (Person person in personQueue)
            {
                Console.WriteLine("Bye!" + name + " said " + person.PersonName);
            }
        }
    }
}
