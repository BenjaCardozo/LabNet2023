using System;

namespace Division.Service
{
    public class Operar
    {
        public static void DividirPor(double divisor)
        {
            try
            {
                double resultado = 1000 / divisor;

                if (divisor == 0)
                {
                    throw new DivideByZeroException();
                }
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ha ocurrido una excepción: {ex.Message}");
                Console.WriteLine("");
            }
            finally
            {
                Console.WriteLine("La operación ha terminado.");
                Console.WriteLine("");
            }
        }

        public static void Division(double dividendo, double divisor)
        {
            try
            {
                if (divisor == 0)
                {
                    throw new DivideByZeroException();
                }
                double resultado = dividendo / divisor;
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!");
                Console.WriteLine($"Ha ocurrido una excepción: {ex.Message}");
                Console.WriteLine("");
            }
            finally
            {
                Console.WriteLine("La operación ha terminado.");
                Console.WriteLine("");
            }
        }

    }
}
