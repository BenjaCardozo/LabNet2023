using System;

namespace Division.Excepciones
{
    public class BenjaExcepcion : Exception
    {
        public BenjaExcepcion(string message) : base(message) { }
        public BenjaExcepcion() : base("Ha ocurrido la Benja Excepcion personalizada.") {}
    }
}
