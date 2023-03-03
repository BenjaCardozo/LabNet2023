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
        public Taxi(int Id, int Pasajeros) : base(Id, Pasajeros) {}

        public override string Avanzar()
        {
            return string.Format("Taxi {0}: {1} pasajeros", Id, Pasajeros);
        }
        public override string Detenerse()
        {
            return "El Taxi se detiene...";
        }
    }
}
