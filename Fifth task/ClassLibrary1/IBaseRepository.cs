namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IBaseRepository<DefT> where DefT : class, new()
    {
        /// <summary>
        /// where DefT - any class type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DefT Get(int id);

        List<DefT> GetAll();

        bool Save(DefT entity);

        bool Delete(int id);
    }
}