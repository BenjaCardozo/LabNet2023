using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoTransporte.Models;

namespace TipoTransporte.Entities
{
    public class Taxi : TransportePublico
    {
        public Taxi(int Pasajeros) : base(Pasajeros)
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
