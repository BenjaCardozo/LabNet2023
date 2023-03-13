using NorthWindPractica.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Logic.Logic
{
    public class GenericABM<T, TKey> : IABMLogic<T, TKey>
    {
        public void Add(T newClass)
        {
            throw new NotImplementedException();
        }

        public void Delete(T deleteClass)
        {
            throw new NotImplementedException();
        }

        public bool ExistID(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(string find)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Update(T updateClass)
        {
            throw new NotImplementedException();
        }
    }
}
