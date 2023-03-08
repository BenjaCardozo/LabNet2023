using System;

namespace Division.Service
{
    public class Operar
    {
        static void DividirPor()
        {
            try
            {
                Console.Write("Ingresa un número: ");
                int numero = Convert.ToInt32(Console.ReadLine());
                double resultado = 1000 / numero;
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ha ocurrido una excepción: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("La operación ha terminado.");
            }
        }

        public static void Division(int dividendo, int divisor)
        {
            try
            {
                int resultado = dividendo / divisor;
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Solo Julio Profe tiene permitido dividir por cero!");
                Console.WriteLine($"Ha ocurrido una excepción: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Seguro ingresó una letra o no ingresó nada!");
            }
            finally
            {
                Console.WriteLine("La operación ha terminado.");
            }
        }

    }
}
