using Division.Excepciones;
using System;

namespace Division.Service
{
    public class Logic
    {
        public static void MetodoConExcepcion(bool op)
        {
            try
            {
                if (op)
                {
                    throw new InvalidProgramException();
                }else if (!op)
                {
                    throw new BenjaExcepcion();
                }
            }
            catch (InvalidProgramException)
            {
                throw;
            }
            catch(BenjaExcepcion) 
            {
                throw;
            }
        }
    }
}
