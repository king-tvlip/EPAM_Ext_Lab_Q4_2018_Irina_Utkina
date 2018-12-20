using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    interface IList<T>
    {
        void clear(List<T> list);
        void show_array(List<T> list);
    }
}
