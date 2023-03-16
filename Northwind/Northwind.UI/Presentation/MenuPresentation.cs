using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.UI.Presentation
{
    public class MenuPresentation
    {
        public MenuPresentation()
        {
            Console.Title = "MENU GENERAL";
        }

        public void MenuGeneral()
        {
            while (true)
            {
                MenuOptions();
                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            CategoriesPresentation _categories = new CategoriesPresentation();
                            ContinuarYLimpiarConsola();
                            _categories.CategoriesMenu();
                            break;
                        case 2:
                            ShippersPresentation _shipper = new ShippersPresentation();
                            ContinuarYLimpiarConsola();
                            _shipper.ShippersMenu();
                            break;
                        case 3:
                            Console.WriteLine("Saliendo...");
                            ContinuarYLimpiarConsola();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor seleccione una opción del 1 al 3.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese un valor válido por favor.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido una Exception.");
                    Console.WriteLine(ex.GetType().Name);
                    Console.WriteLine(ex.Message);
                }
                ContinuarYLimpiarConsola();
            }
        }

        static void MenuOptions()
        {
            Console.WriteLine("========== MENU GENERAL ==========");
            Console.WriteLine("1. IR A MENÚ DE CATEGORIAS");
            Console.WriteLine("2. IR A MENÚ DE EXPEDIDORES");
            Console.WriteLine("3. SALIR");
            Console.Write("Selecione una opción: ");
        }
        static void ContinuarYLimpiarConsola()
        {
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
