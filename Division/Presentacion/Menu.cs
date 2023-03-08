using Division.Excepciones;
using Division.Service;
using System;

namespace Division.Presentacion
{
    public class Menu
    {
        public static void Presentacion()
        {
            while (true)
            {
                Opciones();
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
                    Console.WriteLine("Ha ocurrido una Exetion.");
                    Console.WriteLine(ex.GetType().Name);
                    Console.WriteLine(ex.Message);
                }
                ContinuarYLimpiarConsola();
            }
        }
        static void Opciones()
        {
            Console.WriteLine("Seleccione un punto del practico para hacer:");
            Console.WriteLine("1. Metodo par ingresar un divisor, si es cero lanza una excepcion");
            Console.WriteLine("2. Metodo que divida dos numeros");
            Console.WriteLine("3. Clase Logic que dispara una excepcion");
            Console.WriteLine("4. Clase Logic que dispara una excepcion personalizada");
            Console.WriteLine("5. Salir");
        }
        static void ContinuarYLimpiarConsola()
        {
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void Punto1()
        {
            try
            {
                Console.Write("Ingresa el divisor para una division: ");
                double divisor = double.Parse(Console.ReadLine());
                double resultado = Operar.DividirPor(divisor);
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ha ocurrido una excepción: {ex.Message}");
                Console.WriteLine("");
            }
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("La operación ha terminado.");
                Console.WriteLine("");
            }
        }
        static void Punto2()
        {
            double dividendo;
            double divisor;
            try
            {
                Console.Write("Ingresa el dividendo de una division: ");
                dividendo = double.Parse(Console.ReadLine());
                Console.Write("Ahora ingresa el divisor: ");
                divisor = double.Parse(Console.ReadLine());
                double resultado = Operar.Division(dividendo, divisor);
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!");
                Console.WriteLine($"Ha ocurrido una excepción: {ex.Message}");
                Console.WriteLine("");
            }
            catch (FormatException)
            {
                Console.WriteLine("Sos lolero o ingresaste una letra o nada?");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("La operación ha terminado.");
                Console.WriteLine("");
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
