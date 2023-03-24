using Northwind.Data;
using Northwind.Logic.Application;
using Northwind.UI.Extension;
using System;
using System.Collections.Generic;

namespace Northwind.UI.Presentation
{
    public class ShippersPresentation 
    { 
        private readonly ShippersLogic _logic;
        public ShippersPresentation()
        {
            _logic = new ShippersLogic();
            Console.Title = "MENU DE EXPEDIDORES";
        }

        public void ShippersMenu()
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
                            ListShippers();
                            break;
                        case 5:
                            Console.Clear();
                            FindShippersByName();
                            break;
                        case 6:
                            Console.Clear();
                            FindShipperByID();
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
            Console.WriteLine("========== MENÚ DE EXPEDIDORES ==========");
            Console.WriteLine("1. AGREGAR EXPEDIDOR");
            Console.WriteLine("2. ELMINAR EXPEDIDOR");
            Console.WriteLine("3. MODIFICAR EXPEDIDOR");
            Console.WriteLine("4. LISTAR EXPEDIDORES");
            Console.WriteLine("5. BUSCAR EXPEDIDOR POR NOMBRE DE COMPAÑIA");
            Console.WriteLine("6. BUSCAR EXPEDIDOR POR ID");
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
            Console.Title = "Agregar Expedidor";
            try
            {
                Console.WriteLine("Ingrese el nombre de la compañia:");
                string companyName = Console.ReadLine();
                if (!VerifyStringField(companyName))
                {
                    throw new ArgumentException("El nombre de la compañia no puede estar" +
                        " vacía o solo debe contener letras.");
                }

                Console.WriteLine("Ingrese el telefono:");
                string companyPhone = Console.ReadLine();
                if (!IsValidPhoneNumber(companyPhone))
                {
                    throw new ArgumentException("El telefono debe cumplir con el patrón de número (123) 456-7890 o no puede estar" +
                        " vacío");
                }

                Shippers newShipper = new Shippers
                {
                    CompanyName = companyName,
                    Phone = companyPhone
                };
                _logic.Add(newShipper);

                Console.WriteLine("El expedidor se agregó correctamente.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al agregar el expedidor: " + ex.Message);
            }
        }
        void DeleteMenu()
        {
            Console.Title = "Eliminar Expedidor";
            try
            {
                ListShippers();
                Console.WriteLine("Ingrese el ID del expedidor a eliminar:");
                int shipperId = int.Parse(Console.ReadLine());
                _logic.Delete(shipperId);
                Console.WriteLine("El expedidor se eliminó correctamente.");
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
            Console.Title = "Modificar Expedidor";
            try
            {
                ListShippers();
                Console.WriteLine("Ingrese el ID del expedidor a modificar:");
                int shipperId = int.Parse(Console.ReadLine());

                Shippers shipperToUpdate = _logic.GetByID(shipperId);

                if (shipperToUpdate == null)
                {
                    throw new ArgumentException("No se encontró el expedidor con el ID ingresado.");
                }

                Console.WriteLine("Ingrese el nuevo nombre de la compañia del expedidor:");
                string companyName = Console.ReadLine();
                if (!VerifyStringField(companyName))
                {
                    throw new ArgumentException("El nombre de la compañia no puede estar" +
                        " vacía o solo debe contener letras.");
                }
                Console.WriteLine("Ingrese el nuevo telefono:");
                string phone = Console.ReadLine();
                if (!IsValidPhoneNumber(phone))
                {
                    throw new ArgumentException("El telefono debe cumplir con el patrón de número (123) 456-7890 o no puede estar" +
                        " vacío");
                }
                shipperToUpdate.CompanyName = companyName;
                shipperToUpdate.Phone = phone;

                _logic.Update(shipperToUpdate);

                Console.WriteLine("El expedidor se modificó correctamente.");
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
                Console.WriteLine("Ocurrió un error al modificar el expedidor: " + ex.Message);
            }
        }
        void ListShippers()
        {
            Console.Title = "Listar Expedidores";
            try
            {
                List<Shippers> shippers = _logic.GetAll();

                Console.WriteLine("ID \t| NOMBRE DE LA COMPAÑIA \t| TELEFONO");
                foreach (var shipper in shippers)
                {
                    Console.WriteLine($"{shipper.ShipperID} \t| {shipper.CompanyName} \t| {shipper.Phone}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void FindShippersByName()
        {
            Console.Title = "Buscar Expedidor por Nombre";
            try
            {
                Console.WriteLine("Ingrese el nombre de la compañia del expedidor a buscar:");
                string companyName = Console.ReadLine();

                List<Shippers> shippers = _logic.GetByString(companyName);

                if (shippers.Count == 0)
                {
                    Console.WriteLine("No se encontraron expedidores con la compañia ingresada.");
                    return;
                }

                Console.WriteLine("ID \t| NOMBRE DE LA COMPAÑIA \t| TELEFONO");
                foreach (var shipper in shippers)
                {
                    Console.WriteLine($"{shipper.ShipperID} \t| {shipper.CompanyName} \t| {shipper.Phone}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void FindShipperByID()
        {
            Console.Title = "Buscar Expedidor por ID";
            try
            {
                Console.WriteLine("Ingrese el ID del expedidor que desea buscar:");
                int shipperId = int.Parse(Console.ReadLine());

                Shippers shipper = _logic.GetByID(shipperId);

                if (shipper != null)
                {
                    Console.WriteLine("Categoría encontrada:");
                    Console.WriteLine($"ID: {shipper.ShipperID}");
                    Console.WriteLine($"Nombre: {shipper.CompanyName}");
                    Console.WriteLine($"Descripción: {shipper.Phone}");
                }
                else
                {
                    Console.WriteLine($"No se encontró ningun expedidor con el ID {shipperId}");
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

        static bool VerifyStringField(string categoryField) => categoryField.ContainsOnlyLetters();
        static bool IsValidPhoneNumber(string phone) => phone.IsValidPhoneNumber();
    }
}