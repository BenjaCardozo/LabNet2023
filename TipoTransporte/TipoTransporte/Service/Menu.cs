using System;
using System.Collections.Generic;
using System.Linq;
using TipoTransporte.Entities;
using TipoTransporte.Models;

namespace TipoTransporte.Service
{
    //Decidi hacer todo el menu en una nueva clase para que el codigo quede mas limpio
    public class Menu
    {
        //Este sería un menú principal
        public static void IngresarTransportes()
        {
            List<TransportePublico> transportes = new List<TransportePublico>();
            int opcion = 0;
            do
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ingresar Taxis");
                Console.WriteLine("2. Ingresar Omnibus");
                Console.WriteLine("3. Salir");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            IngresarTaxi(transportes);
                            IngresarOmnibus(transportes);
                            break;
                        case 2:
                            IngresarOmnibus(transportes);
                            IngresarTaxi(transportes);
                            break;
                        case 3:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, seleccione 1 o 2.");
                            break;
                    }
                }
                //Esta excepcion es para cuando el usuario ingresa un valor no numérico al intentar ingresar la opcion.
                catch (FormatException)
                {
                    Console.WriteLine("Opción inválida. Por favor, seleccione 1 o 2.");
                }
                //Esta excepcion es para cuando se produce una error al intentar convertir el valor ingresado a un número entero.
                catch (OverflowException)
                {
                    Console.WriteLine("Opción inválida. El número ingresado es demasiado grande.");
                }
                //Manejo cualquier otra excepcion que se pueda producir
                catch (Exception ex)
                {
                    Console.WriteLine("Se ha producido un error: " + ex.Message);
                }
                //transportes
                //    .Select(t => "-----------------------------------------------------------------\n" 
                //    + t.Avanzar())
                //    .ToList()
                //    .ForEach(Console.WriteLine);

                transportes.ForEach(t =>
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    

                    if (t is Omnibus && t.Pasajeros > Omnibus.CantMax)
                    {
                        Console.WriteLine(t.Detenerse());
                    }
                    else if (t is Taxi && t.Pasajeros > Taxi.CantMax)
                    {
                        Console.WriteLine(t.Detenerse());
                    } else
                    {
                        Console.WriteLine(t.Avanzar());
                    }
                });

                Console.WriteLine("-----------------------------------------------------------------");
                transportes.Clear();

            } while (opcion != 3);
        }

        //Hice por serparado el ingresar taxi e ingresar omnibus para que quede un codigo mas limpio
        static List<TransportePublico> IngresarTaxi(List<TransportePublico> transportes)
        {
            int id = 0;
            for (int i = 0; i < 5; i++)
            {
                int pasajeros = 0;
                bool ingresoValido = false;
                do
                {
                    //i+1 indica el nuemro del taxi y un maximo de 4 porque solo pueden ir 4 pasajeros en un taxi sin contar el conductor
                    Console.Write("Ingrese la cantidad de pasajeros para el Taxi " + (i + 1) + " (máximo 4): ");
                    try
                    {
                        pasajeros = int.Parse(Console.ReadLine());

                        //como no cuento el conductor, no permito ingresar 0
                        if (pasajeros <= 0 || pasajeros > Taxi.CantMax)
                        {
                            Console.WriteLine("Cantidad de pasajeros inválida. Ingrese un valor entre 0 y 4.");
                        }
                        else
                        {
                            ingresoValido = true;
                        }
                    }
                    //Esta excepcion es para cuando el usuario ingresa un valor no numérico al intentar ingresar la cantidad de pasajeros.
                    catch (FormatException)
                    {
                        Console.WriteLine("El valor ingresado no es un número válido. Intente nuevamente.");
                    }
                    //Esta excepcion es para cuando se produce una erro al intentar convertir el valor ingresado a un número entero.
                    catch (OverflowException)
                    {
                        Console.WriteLine("El número ingresado es demasiado grande o pequeño. Intente nuevamente.");
                    }
                } while (!ingresoValido);

                //Apesar de que pidieron datos no hardcodeados
                //pense hacerlo de esta manera porque por lo general el usuario no ingresa el id de un objeto
                id++;
                transportes.Add(new Taxi(id, pasajeros));
            }

            return transportes;
        }

        static List<TransportePublico> IngresarOmnibus(List<TransportePublico> transportes)
        {
            int id = 0;
            for (int i = 0; i < 5; i++)
            {
                int pasajeros = 0;
                bool esNumeroValido = false;
                do
                {
                    //como maximo 60 solo por un estimado
                    Console.Write("Ingrese la cantidad de pasajeros para el Omnibus " + (i + 1) + " (máximo 60): ");
                    string input = Console.ReadLine();
                    try
                    {
                        pasajeros = int.Parse(input);
                        if (pasajeros < 0 || pasajeros > Omnibus.CantMax)
                        {
                            Console.WriteLine("Cantidad de pasajeros inválida. Ingrese un valor entre 0 y 60.");
                        }
                        else
                        {
                            esNumeroValido = true;
                        }
                    }
                    //Esta excepcion es para cuando el usuario ingresa un valor no numérico al intentar ingresar la cantidad de pasajeros.
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un valor numérico.");
                    }
                    //Esta excepcion es para cuando se produce una erro al intentar convertir el valor ingresado a un número entero.
                    catch (OverflowException)
                    {
                        Console.WriteLine("El número ingresado es demasiado grande.");
                    }
                } while (!esNumeroValido);

                id++;
                transportes.Add(new Omnibus(id, pasajeros));
            }

            return transportes;
        }

    }
}

