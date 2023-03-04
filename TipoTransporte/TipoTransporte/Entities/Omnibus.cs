using TipoTransporte.Models;

namespace TipoTransporte.Entities
{
    public class Omnibus : TransportePublico
    {

        private static readonly int _cantMax = 60;
        public Omnibus(int Id, int Pasajeros) : base(Id, Pasajeros){}

        public static int CantMax
        {
            get { return _cantMax; }
        }

        //Polimorfismo de los metodos avanzar y detenerse
        public override string Avanzar()
        {
            return $"Omnibus {Id}: {Pasajeros} pasajeros";
        }
        public override string Detenerse()
        {
            return "El Omnibus se detiene por exceso de pasajeros...";
        }


    }
}
