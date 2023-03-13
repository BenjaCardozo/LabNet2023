using NorthWindPractica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.Logic.Logic
{
    public abstract class BaseLogic
    {
        protected readonly NorthwindContext _context;
        protected BaseLogic()=> _context = new NorthwindContext();
    }
}
