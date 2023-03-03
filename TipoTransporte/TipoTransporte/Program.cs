using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipoTransporte.Entities;
using TipoTransporte.Models;

namespace TipoTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IngresarTransportes();


            Console.ReadLine();
        }

        static void IngresarTransportes()
        {
            List<TransportePublico> transportes = new List<TransportePublico>();
            try
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ingresar Taxis");
                Console.WriteLine("2. Ingresar Omnibus");

                int opcion = int.Parse(Console.ReadLine());
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
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione 1 o 2.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida. Por favor, seleccione 1 o 2.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Opción inválida. El número ingresado es demasiado grande.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex.Message);
            }

            foreach (TransportePublico transporte in transportes)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine(transporte.Avanzar());
            }
        }

        static List<TransportePublico> IngresarTaxi(List<TransportePublico> transportes)
        {
            int id = 0;
            for (int i = 0; i < 5; i++)
            {
                int pasajeros = 0;
                bool ingresoValido = false;
                do
                {
                    Console.Write("Ingrese la cantidad de pasajeros para el Taxi " + (i + 1) + " (máximo 4): ");
                    try
                    {
                        pasajeros = int.Parse(Console.ReadLine());
                        if (pasajeros <= 0 || pasajeros > 4)
                        {
                            Console.WriteLine("Cantidad de pasajeros inválida. Ingrese un valor entre 0 y 4.");
                        }
                        else
                        {
                            ingresoValido = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("El valor ingresado no es un número válido. Intente nuevamente.");
                    }
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
                int pasajeros;
                do
                {
                    Console.Write("Ingrese la cantidad de pasajeros para el Omnibus " + (i + 1) + " (máximo 60): ");
                    pasajeros = int.Parse(Console.ReadLine());
                    if (pasajeros < 0 || pasajeros > 60)
                    {
                        Console.WriteLine("Cantidad de pasajeros inválida. Ingrese un valor entre 0 y 60.");
                    }
                } while (pasajeros < 1 || pasajeros > 60);

                id++;
                transportes.Add(new Omnibus(id, pasajeros));
            }

            return transportes;
        }

    }

}
