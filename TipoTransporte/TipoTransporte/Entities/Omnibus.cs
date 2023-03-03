using TipoTransporte.Models;

namespace TipoTransporte.Entities
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int Id, int Pasajeros) : base(Id, Pasajeros) {}


        //Polimorfismo de los metodos avanzar y detenerse
        public override string Avanzar()
        {
            return $"Omnibus {Id}: {Pasajeros} pasajeros";
        }
        public override string Detenerse()
        {
            return "El Omnibus se detiene...";
        }
    }
}
