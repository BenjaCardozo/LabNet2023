using NorthWindPractica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Logic.Interface
{
    interface IABMLogic<T, TKey>
    {
        IEnumerable<T> GetAll();
        T GetById(TKey id);
        void Add(T newClass);
        void Delete(T deleteClass);
        void Update(T updateClass);
        bool ExistID (TKey id);
        IEnumerable<T> Find(string find);
    }
}
