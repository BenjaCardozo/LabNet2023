using Division.Excepciones;
using Division.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Presentacion
{
    public class Menu
    {
        public static void menu()
        {
            while (true)
            {
                Console.WriteLine("Seleccione un punto del practico para hacer:");
                Console.WriteLine("1. Metodo que divida un numero, si es cero lanza una excepcion");
                Console.WriteLine("2. Metodo que divida dos numeros");
                Console.WriteLine("3. Clase Logic que dispara una excepcion");
                Console.WriteLine("4. Clase Logic que dispara una excepcion personalizada");
                Console.WriteLine("5. Salir");
                try
                {
                    int opcion = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1:
                            Punto1();
                            break;
                        case 2:
                            Punto2();
                            break;
                        case 3:
                            Punto3y4(true);
                            break;
                        case 4:
                            Punto3y4(false);
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor seleccione una opción del 1 al 5.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Seguro ingresó una letra o no ingresó nada!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                ContinuarYLimpiarConsola();
            }
        }
        static void ContinuarYLimpiarConsola()
        {
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void Punto1()
        {
            Console.Write("Ingresa el divisor para una division: ");
            Operar.DividirPor(double.Parse(Console.ReadLine()));
        }
        static void Punto2()
        {
            double dividendo;
            double divisor;
            try
            {
                Console.Write("Ingresa el primer número: ");
                dividendo = double.Parse(Console.ReadLine());
                Console.Write("Ingresa el segundo número: ");
                divisor = double.Parse(Console.ReadLine());
                Operar.Division(dividendo, divisor);
            }
            catch (FormatException)
            {
                Console.WriteLine("Sos lolero o ingresaste una letra o nada?");
            }
        }
        static void Punto3y4(bool op)
        {
            try
            {
                Logic.MetodoConExcepcion(op);
            }
            catch ( InvalidProgramException ex)
            {
                Console.WriteLine($"Se ha capturado una excepción: {ex.GetType().Name}. Mensaje: {ex.Message}");
            }
            catch(BenjaExcepcion ex)
            {
                Console.WriteLine($"Se ha capturado una excepción: {ex.GetType().Name}. Mensaje: {ex.Message}");
            }
            
        }

    }
}
