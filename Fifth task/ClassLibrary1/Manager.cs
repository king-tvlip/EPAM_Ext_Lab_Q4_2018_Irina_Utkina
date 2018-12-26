namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Manager : IManagerRepository //todo pn класс User отдельно, реализация IUserRepository - отдельно. Переделать
    {
        private List<Manager> managerList = new List<Manager>();

        public Manager()
        {
            this.Name = string.Empty;
            this.Attached_users = null;
            this.ID = -1;
        }

        public Manager(string name, List<User> users, int id)
        {
            this.Name = name;
            this.Attached_users = users;
            this.ID = id;
        }

        public int ID { get; set; }

        public List<User> Attached_users { get; set; }

        public string Name { get; set; }

        //initiallization
        public void Init()
        {
            List<Themes> ivansList = new List<Themes>();
            List<Themes> petrsList = new List<Themes>();
            ivansList.Add(new Themes("F#", 0, 50));
            petrsList.Add(new Themes("C++", 0, 99));
            List<User> managersUsersList = new List<User>();
            managersUsersList.Add(new User("Ivan", ivansList, 1));
            managersUsersList.Add(new User("Petr", petrsList, 2));
            this.managerList.Add(new Manager("Anna", managersUsersList, 1));
            this.managerList.Add(new Manager("Sam", managersUsersList, 2));
        }

        // deletes the attached user by his id
        public bool Delete(int id)
        {
            int startVolume = this.managerList.Count();
            this.managerList.RemoveAt(id);
            int newVolume = this.managerList.Count();
            if (newVolume != startVolume)
            {
                return true;
            }
            else
            {
                return false;
            }

            throw new NotImplementedException();
        }

        // gets the attached user's name by his id
        public Manager Get(int id)
        {
            Manager managerToReturn = new Manager();
            this.Init();
            foreach (var variable in this.managerList)
            {
                if (variable.ID == id)
                {
                    managerToReturn = variable;
                    break;
                }
            }

            return managerToReturn;
            throw new NotImplementedException();
        }

        // get all attached users' names in the list
        public List<Manager> GetAll()
        {
            return this.managerList;
            throw new NotImplementedException();
        }

        // adds a new manager
        public bool Save(Manager entity)
        {
            int startCapacity = this.managerList.Count();
            this.managerList.Add(entity);
            int newCapacity = this.managerList.Count();
            if (newCapacity != startCapacity)
            {
                return true;
            }
            else
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}