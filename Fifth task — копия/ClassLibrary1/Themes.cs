namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Themes
    {
        private List<Themes> listOfThemes = new List<Themes>();

        public Themes()
        {
            this.Theme = null;
            this.Id = -1;
            this.Themer = -1;
        }

        public Themes(string themes, int id, int ther)
        {
            this.Theme = themes;
            this.Id = id;
            this.Themer = ther;
        }

        public string Theme { get; set; }

        public int Id { get; set; }

        public int Themer { get; set; }

        public void CreateTheme(Themes new_obj)
        {
            this.listOfThemes.Add(new_obj);
            throw new System.NotImplementedException();
        }

        public void DeleteTheme(int id)
        {
            this.listOfThemes.RemoveAt(id);
            throw new System.NotImplementedException();
        }

        public void EditThemeName(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ShowThemeNameNumber(Themes themes)
        {
            throw new System.NotImplementedException();
        }
    }
}