using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Performance
{
    public class Menu
    {

        public static void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("Seleccione el punto que desea realizar:");
                Console.WriteLine("1. Metoddo que lanza excepcion al divir por cero");
                Console.WriteLine("2. Metodo donde permita dividir dos numero, controlando excepciones y donde solo Chuck Norris divide por cero");
                Console.WriteLine("3. Clase Logic con excepcion a gusto");
                Console.WriteLine("4. Clase Logic pero con excepcion personalizada");
                Console.WriteLine("5. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------------------");
                        break;
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("--------------------------------------------------------------");
                        break;
                    case 5:
                        Environment.Exit(0);
                        Console.WriteLine("--------------------------------------------------------------");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor seleccione una opción del 1 al 5.");
                        break;
                }
            }
        }
    }
}
