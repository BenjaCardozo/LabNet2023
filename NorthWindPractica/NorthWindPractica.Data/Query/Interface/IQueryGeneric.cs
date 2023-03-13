using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Data.Query.Interface
{
    interface IQueryGeneric <T, TKey>
    {
        List<T> GetAll();
        T GetByID(TKey id);
        bool ExistID(TKey id);
    }
}
