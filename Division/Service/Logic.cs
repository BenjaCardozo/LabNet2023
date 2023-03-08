using Division.Excepciones;
using System;

namespace Division.Service
{
    public class Logic
    {
        public static void MetodoConExcepcion(bool op)
        {
            if (op)
            {
                throw new InvalidProgramException();
            }else if (!op)
            {
                throw new BenjaExcepcion();
            }
        }
    }
}
