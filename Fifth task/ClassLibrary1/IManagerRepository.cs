namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IManagerRepository : IBaseRepository<Manager>
    {
        void InitiallizeNewManagerAndAttachedUsers();
    }
}
