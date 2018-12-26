namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IManagerRepository : IBaseRepository<Manager>
    {
        void Init();//todo pn не самое удачное название метода. Init лучше) Подробности о работе метода можно в summary загнать. Советую не использовать подчеркивания. CamelCase лучше и проще.
    }
}
