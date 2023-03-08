using System;

namespace Division.Service
{
    public class Operar
    {
        public static double DividirPor(double divisor)
        {
            try
            {
                double resultado = 1000 / divisor;
                if (divisor == 0)
                {
                    throw new DivideByZeroException();
                }
                return resultado;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static double Division(double dividendo, double divisor)
        {
            try
            {
                double resultado = dividendo / divisor;
                if (divisor == 0)
                {
                    throw new DivideByZeroException();
                }
                return resultado;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
