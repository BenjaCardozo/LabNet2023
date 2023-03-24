using System.Collections.Generic;

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
