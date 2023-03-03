using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipoTransporte.Models
{
    public abstract class TransportePublico
    {
        private int _id;
        private int _pasajeros;

        public TransportePublico(int Id ,int Pasajeros)
        {
            _id = Id;
            _pasajeros = Pasajeros;
        }

        public int Pasajeros
        {
            get { return _pasajeros; }
            set { _pasajeros = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
