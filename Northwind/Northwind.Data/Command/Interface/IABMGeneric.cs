using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Command.Interface
{
    interface IABMGeneric<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
