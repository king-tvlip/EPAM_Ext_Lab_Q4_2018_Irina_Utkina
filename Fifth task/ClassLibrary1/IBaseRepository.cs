namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IBaseRepository<DefT> where DefT : class, new()
    {
        DefT Get(int id);

        List<DefT> GetAll();

        bool Save(DefT entity);

        bool Delete(int id);
    }
}