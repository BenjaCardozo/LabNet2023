using NorthWindPractica.Data;
using NorthWindPractica.Service.Service;
using NorthWindPractica.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindPractica.UI.Presentation
{
    public class CategoriesPresentation
    { 
        private readonly CategoriesService _service = new CategoriesService();

        
        public void CategoriesMenu()
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
                            AddMenu();
                            break;
                        case 2:
                            Console.WriteLine("Has seleccionado la opción 2");
                            break;
                        case 3:
                            Console.WriteLine("Has seleccionado la opción 3");
                            break;
                        case 4:
                            Console.WriteLine("Has seleccionado la opción 4");
                            break;
                        case 5:
                            Console.WriteLine("Has seleccionado la opción 5");
                            break;
                        case 6:
                            Console.WriteLine("Adiós");
                            return;
                        case 7:
                            MenuPresentation menu = new MenuPresentation();
                            ContinuarYLimpiarConsola();
                            menu.MenuGeneral();                           
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
            Console.WriteLine("========== MENÚ DE CATEGORIAS ==========");
            Console.WriteLine("1. AGREGAR CATEGORIA");
            Console.WriteLine("2. ELMINAR CATEGORIA");
            Console.WriteLine("3. MOFICAR CATEGORIA");
            Console.WriteLine("4. LISTAR CATEGORIAS");
            Console.WriteLine("5. BUSCAR CATEGORIA POR DESCRIPCION");
            Console.WriteLine("6. BUSCAR CATEGORIA POR ID");
            Console.WriteLine("7. VOLVER A MENÚ GENERAL");

            Console.Write("Seleccione una opción: ");
        }
        static void ContinuarYLimpiarConsola()
        {
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        public void AddMenu()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la categoría:");
                string categoryName = Console.ReadLine();
                if (!VerifyStringField(categoryName))
                {
                    throw new ArgumentException("El nombre de la categoría no puede estar" +
                        " vacía o solo debe contener letras.");
                }

                Console.WriteLine("Ingrese la descripción de la categoría:");
                string categoryDescription = Console.ReadLine();
                if (!VerifyStringField(categoryDescription))
                {
                    throw new ArgumentException("La descripcion de la categoría no puede estar" +
                        " vacía o solo debe contener letras.");
                }

                Categories newCategory = new Categories
                {
                    CategoryName = categoryName,
                    Description = categoryDescription
                };
                _service.Add(newCategory);

                Console.WriteLine("La categoría se agregó correctamente.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al agregar la categoría: " + ex.Message);
            }
        }

        public static bool VerifyStringField(string categoryField) => categoryField.ContainsOnlyLetters() || categoryField != null;
    }
}
