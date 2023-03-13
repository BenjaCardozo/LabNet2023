using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Service.Interface
{
    interface IABMService <T, TKey>
    {
        IEnumerable<T> GetAll();
        T GetById(TKey id);
        void Add(T newClass);
        void Delete(TKey id);
        void Update(T updateClass);
        IEnumerable<T> Find(string find);
    }
}
