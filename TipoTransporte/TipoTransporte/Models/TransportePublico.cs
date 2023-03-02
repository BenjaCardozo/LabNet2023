using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipoTransporte.Models
{
    public abstract class TransportePublico
    {
        public int Pasajeros { get; set; }

        public TransportePublico(int Pasajeros) 
        {
            this.Pasajeros = Pasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
