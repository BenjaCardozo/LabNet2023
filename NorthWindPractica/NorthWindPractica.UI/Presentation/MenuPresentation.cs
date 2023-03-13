using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.UI.Presentation
{
    public class MenuPresentation
    {
        public MenuPresentation() 
        {
            Console.Title = "MENU GENERAL";
        }

        public void MenuGeneral()
        {
            bool menu = true;
            while (menu)
            {
                MenuOptions();
                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            CategoriesPresentation _categories = new CategoriesPresentation();
                            _categories.CategoriesMenu();
                            break;
                        case 2:
                            Console.WriteLine("Has seleccionado la opción 2");
                            break;
                        case 3:
                            menu = false;
                            Console.WriteLine("Has seleccionado la opción 3");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor seleccione una opción del 1 al 7.");
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
            Console.WriteLine("2. Opción 2");
            Console.WriteLine("3. Opción 3");
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
