namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User : Roles, IUserRepository
    {
        /// <summary>
        /// personal name
        /// </summary>
        /// <summary>
        /// is a list of themes an its rating
        /// </summary>
        private List<User> listOfUsers = new List<User>();

        public User()
        {
            this.Name = string.Empty;

            this.Rating = null;

            this.ID = -1;
        }

        public User(string name, List<Themes> listThemes, int id)
        {
            this.Name = name;

            this.Rating = listThemes;

            this.ID = id;
        }

        public string Name { get; set; }

        public int ID { get; set; }

        public List<Themes> Rating { get; set; }

        public void InitiallizeUserRatingAndName()
        {
            List<Themes> ivansList = new List<Themes>();
            List<Themes> petrsList = new List<Themes>();
            ivansList.Add(new Themes("F#", 0, 50));
            petrsList.Add(new Themes("C++", 0, 99));
            this.listOfUsers.Add(new User("Ivan", ivansList, 1));
            this.listOfUsers.Add(new User("Petr", petrsList, 2));
        }

        public User Choose_theme_and_rate(User user)
        {
            Themes themeAdd = new Themes();
            themeAdd.Theme = "Pascal";
            themeAdd.Themer = 3;
            themeAdd.Id = user.Rating.Count() + 1;
            user.Rating.Add(themeAdd);
            return user;
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            int startVolume = this.listOfUsers.Count();
            foreach (var variable in this.listOfUsers)
            {
                if (variable.ID == id)
                {
                    this.listOfUsers.Remove(variable);
                    break;
                }
            }

            int newVolume = this.listOfUsers.Count();
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

        public User Get(int id)
        {
            User userToreturn = new User();
            this.InitiallizeUserRatingAndName();
            foreach (var variable in this.listOfUsers)
            {
                if (variable.ID == id)
                {
                    userToreturn = variable;
                    break;
                }
            }

            return userToreturn; 
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return this.listOfUsers;
            throw new NotImplementedException();
        }

        public bool Save(User entity)
        {
            int startVolume = this.listOfUsers.Count();
            this.listOfUsers.Add(entity);
            int newVolume = this.listOfUsers.Count();
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
    }
}