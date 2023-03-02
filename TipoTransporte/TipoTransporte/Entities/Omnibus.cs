using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoTransporte.Models;

namespace TipoTransporte.Entities
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int Pasajeros) : base(Pasajeros)
        {
        }

        public override string Avanzar()
        {
            throw new NotImplementedException();
        }

        public override string Detenerse()
        {
            throw new NotImplementedException();
        }
    }
}
