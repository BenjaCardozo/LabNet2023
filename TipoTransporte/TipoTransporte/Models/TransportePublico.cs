namespace TipoTransporte.Models
{
    public abstract class TransportePublico
    {
        //utilizando id para poder mostrar luego por consola el numero del transporte
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
