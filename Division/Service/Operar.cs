using System;

namespace Division.Service
{
    public class Operar
    {
        public static double DividirPor(double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            double resultado = 1000 / divisor;
            return resultado;
        }
        public static double Division(double dividendo, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            double resultado = dividendo / divisor;
            return resultado;
        }

    }
}
