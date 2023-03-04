using TipoTransporte.Models;

namespace TipoTransporte.Entities
{
    public class Taxi : TransportePublico
    {
        private static readonly int _cantMax = 4;

        public Taxi(int Id, int Pasajeros) : base(Id, Pasajeros){}

        public static int CantMax
        {
            get { return _cantMax; }
        }

        //Polimorfismo de los metodos avanzar y detenerse
        public override string Avanzar()
        {
            return string.Format("Taxi {0}: {1} pasajeros", Id, Pasajeros);
        }
        public override string Detenerse()
        {
            return $"El Taxi {Id} se detiene por exceso de pasajeros...";
        }
    }
}
