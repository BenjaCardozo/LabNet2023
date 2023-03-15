using Northwind.Data;
using Northwind.Logic.Application;
using Northwind.UI.Extension;
using System;
using System.Collections.Generic;

namespace Northwind.UI.Presentation
{
    public class CategoriesPresentation
    {
        private readonly CategoriesLogic _logic;
        public CategoriesPresentation()
        {
            _logic = new CategoriesLogic();
            Console.Title = "MENU DE CATEGORIAS";
        }

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
                            Console.Clear();
                            AddMenu();
                            break;
                        case 2:
                            Console.Clear();
                            DeleteMenu();
                            break;
                        case 3:
                            Console.Clear();
                            UpdateMenu();
                            break;
                        case 4:
                            Console.Clear();
                            ListCategories();
                            break;
                        case 5:
                            Console.Clear();
                            FindCategoriesByName();
                            break;
                        case 6:
                            Console.Clear();
                            FindCategoryByID();
                            break;
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
            Console.WriteLine("3. MODIFICAR CATEGORIA");
            Console.WriteLine("4. LISTAR CATEGORIAS");
            Console.WriteLine("5. BUSCAR CATEGORIA POR NOMBRE");
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
        void AddMenu()
        {
            Console.Title = "Agregar Categoria";
            try
            {
                Console.WriteLine("Ingrese el nombre de la nueva categoría:");
                string categoryName = Console.ReadLine();
                if (!VerifyStringField(categoryName))
                {
                    throw new ArgumentException("El nombre de la categoría no puede estar" +
                        " vacía o solo debe contener letras.");
                }

                Console.WriteLine("Ingrese la descripción de la nueva categoría:");
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
                _logic.Add(newCategory);

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
        void DeleteMenu()
        {
            Console.Title = "Eliminar Categoria";
            try
            {
                ListCategories();
                Console.WriteLine("Ingrese el ID de la categoría a eliminar:");
                int categoryId = int.Parse(Console.ReadLine());
                _logic.Delete(categoryId);
                Console.WriteLine("La categoría se eliminó correctamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingrese un valor numérico válido por favor.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void UpdateMenu()
        {
            Console.Title = "Modificar Categoria";
            try
            {
                ListCategories();
                Console.WriteLine("Ingrese el ID de la categoría a modificar:");
                int categoryId = int.Parse(Console.ReadLine());

                Categories categoryToUpdate = _logic.GetByID(categoryId);

                if (categoryToUpdate == null)
                {
                    throw new ArgumentException("No se encontró la categoría con el ID ingresado.");
                }

                Console.WriteLine("Ingrese el nuevo nombre de la categoría:");
                string categoryName = Console.ReadLine();
                if (!VerifyStringField(categoryName))
                {
                    throw new ArgumentException("El nombre de la categoría no puede estar" +
                        " vacía o solo debe contener letras.");
                }

                Console.WriteLine("Ingrese la nueva descripción de la categoría:");
                string categoryDescription = Console.ReadLine();
                if (!VerifyStringField(categoryDescription))
                {
                    throw new ArgumentException("La descripción de la categoría no puede estar" +
                        " vacía o solo debe contener letras.");
                }

                categoryToUpdate.CategoryName = categoryName;
                categoryToUpdate.Description = categoryDescription;

                _logic.Update(categoryToUpdate);

                Console.WriteLine("La categoría se modificó correctamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingrese un valor numérico válido por favor.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al modificar la categoría: " + ex.Message);
            }
        }
        void ListCategories()
        {
            Console.Title = "Listar Categorias";
            try
            {
                List<Categories> categories = _logic.GetAll();

                Console.WriteLine("ID \t| NOMBRE \t| DESCRIPCIÓN");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.CategoryID} \t| {category.CategoryName} \t| {category.Description}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void FindCategoriesByName()
        {
            Console.Title = "Buscar Categoria por Nombre";
            try
            {
                Console.WriteLine("Ingrese el nombre de la categoría a buscar:");
                string categoryName = Console.ReadLine();

                List<Categories> categories = _logic.GetByString(categoryName);

                if (categories.Count == 0)
                {
                    Console.WriteLine("No se encontraron categorías con el nombre ingresado.");
                    return;
                }

                Console.WriteLine("ID \t| NOMBRE \t| DESCRIPCIÓN");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.CategoryID} \t| {category.CategoryName} \t| {category.Description}");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void FindCategoryByID()
        {
            Console.Title = "Buscar Categoria por ID";
            try
            {
                Console.WriteLine("Ingrese el ID de la categoría que desea buscar:");
                int categoryId = int.Parse(Console.ReadLine());

                Categories category = _logic.GetByID(categoryId);

                if (category != null)
                {
                    Console.WriteLine("Categoría encontrada:");
                    Console.WriteLine($"ID: {category.CategoryID}");
                    Console.WriteLine($"Nombre: {category.CategoryName}");
                    Console.WriteLine($"Descripción: {category.Description}");
                }
                else
                {
                    Console.WriteLine($"No se encontró ninguna categoría con el ID {categoryId}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("El ID debe ser un número entero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static bool VerifyStringField(string categoryField) => categoryField.ContainsOnlyLetters() || categoryField != null;
    }
}