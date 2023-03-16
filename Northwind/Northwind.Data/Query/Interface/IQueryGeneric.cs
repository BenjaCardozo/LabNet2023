using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Query.Interface
{
    public interface IQueryGeneric <T,TKey>
    {
        List<T> GetAll();
        T GetByID(TKey id);
        bool ExistID(TKey id);
        List<T> GetByString(string str);
        TKey LastID();
    }
}
