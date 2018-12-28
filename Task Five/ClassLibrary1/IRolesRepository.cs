using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    interface IRolesRepository : IBaseRepository<T>
    {
        void Set_role();
        void Change_role();
        void Create_role();
        void Delete_role();
    }
}
