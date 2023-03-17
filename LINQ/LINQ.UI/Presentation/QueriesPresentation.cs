using LINQ.Data;
using LINQ.Entities.DTO;
using LINQ.Logic.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.UI.Presentation
{
    public class QueriesPresentation
    {
        private readonly CustomerApplication customerApplication = new CustomerApplication(); 
        private readonly ProductsApplication productsApplication = new ProductsApplication();
        public QueriesPresentation() 
        {
            Console.Title = "SELECCION DE EJERCICIO";
        }
        public void QueriesMenu()
        {
            while (true)
            {
                OpcionDeEjercicio();
                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            ContinuarYLimpiarConsola();
                            MostrarCustomer();
                            break;
                        case 2:
                            ContinuarYLimpiarConsola();
                            MostrarProductosSinStock();
                            break;
                        case 3:
                            ContinuarYLimpiarConsola();
                            MostrarProductosConStockYCuentesMasDeTres();
                            break;
                        case 4:
                            ContinuarYLimpiarConsola();
                            MostrarCustomersDondeRegionEsWA();
                            break;
                        case 5:
                            ContinuarYLimpiarConsola();
                            MostrarProductoConElID();
                            break;
                        case 6:
                            ContinuarYLimpiarConsola();
                            MostrarNombres();
                            break;
                        case 7:
                            ContinuarYLimpiarConsola();
                            JoinCustomersYOrders();
                            break;
                        case 8:
                            ContinuarYLimpiarConsola();
                            PrimerosCustomersRegionWA();
                            break;
                        case 9:
                            ContinuarYLimpiarConsola();
                            MostrarProductosOrdenados();
                            break;
                        case 10:
                            ContinuarYLimpiarConsola();
                            MostrarProductosOrdenadosPorUnidad();
                            break;
                        case 11:
                            ContinuarYLimpiarConsola();
                            MostrarCategoriasConProductos();
                            break;
                        case 12:
                            ContinuarYLimpiarConsola();
                            PrimerElemento();
                            break;
                        case 13:
                            ContinuarYLimpiarConsola();
                            OrdenesCustomers();
                            break;
                        case 14:
                            Console.WriteLine("Saliendo...");
                            ContinuarYLimpiarConsola();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor seleccione una opción del 1 al 14.");
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
        static void OpcionDeEjercicio()
        {
            Console.WriteLine("========== MENU DE EJERCICIOS ==========");
            Console.WriteLine("1. Query para devolver un objeto customer");
            Console.WriteLine("2. Query que devuelve productos sin stock");
            Console.WriteLine("3. Query que devuelve los productos con stock y que cuestan mas de $3 por unidad");
            Console.WriteLine("4. Query para devolver todos los customers de la Región WA");
            Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID del producto sea igual a 789");
            Console.WriteLine("6. Mostrar nombre de customers en minuscula y mayuscula");
            Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
            Console.WriteLine("========== EJERCICIOS EXTRAS ==========");
            Console.WriteLine("8. Query para devolver los primeros 3 Customers de la  Región WA");
            Console.WriteLine("9. Query para devolver lista de productos ordenados por nombre");
            Console.WriteLine("10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor");
            Console.WriteLine("11. Query para devolver las distintas categorías asociadas a los productos");
            Console.WriteLine("12. Query para devolver el primer elemento de una lista de productos");
            Console.WriteLine("13. Query para devolver los customer con la cantidad de ordenes asociadas");
            Console.WriteLine("14. Salir.");
            Console.Write("Selecione una opción: ");
        }
        static void ContinuarYLimpiarConsola()
        {
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        void MostrarCustomer ()
        {
            try
            {
                Customers resultado = customerApplication.GetCustomerByID();

                Console.WriteLine($"Company Name: {resultado.CompanyName}");
                Console.WriteLine($"Contact Name: {resultado.ContactName}");
                Console.WriteLine($"Contact Title: {resultado.ContactTitle}");
                Console.WriteLine($"Address: {resultado.Address}");
                Console.WriteLine($"City: {resultado.City}");
                Console.WriteLine($"Region: {resultado.Region}");
                Console.WriteLine($"Postal Code: {resultado.PostalCode}");
                Console.WriteLine($"Country: {resultado.Country}");
                Console.WriteLine($"Phone: {resultado.Phone}");
                Console.WriteLine($"Fax: {resultado.Fax}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        void MostrarProductosSinStock()
        {
            try
            {
                List<Products> products =  productsApplication.ProductsWhithoutStock();

                foreach (Products product in products)
                {
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Quantity Per Unit: {product.QuantityPerUnit}");
                    Console.WriteLine($"Unit Price: $ {product.UnitPrice?.ToString("0.00")}");
                    Console.WriteLine($"Units In Stock: {product.UnitsInStock}");
                    if (product.Discontinued)
                    {
                       Console.WriteLine("Discontinued");
                    }
                    Console.WriteLine("=======================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void MostrarProductosConStockYCuentesMasDeTres()
        {
            try
            {
                List<Products> products = productsApplication.WhithStockAndPriceperUnitHigherthree();

                foreach (Products product in products)
                {
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Quantity Per Unit: {product.QuantityPerUnit}");
                    Console.WriteLine($"Unit Price: $ {product.UnitPrice?.ToString("0.00")}");
                    Console.WriteLine($"Units In Stock: {product.UnitsInStock}");
                    if (product.Discontinued)
                    {
                        Console.WriteLine("Discontinued");
                    }
                    Console.WriteLine("=======================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void MostrarCustomersDondeRegionEsWA()
        {
            try
            {
                List<Customers> customers = customerApplication.RegionIsWA();

                foreach (Customers customer in customers)
                {
                    Console.WriteLine($"Company Name: {customer.CompanyName}");
                    Console.WriteLine($"Contact Name: {customer.ContactName}");
                    Console.WriteLine($"Contact Title: {customer.ContactTitle}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine($"City: {customer.City}");
                    Console.WriteLine($"Region: {customer.Region}");
                    Console.WriteLine($"Postal Code: {customer.PostalCode}");
                    Console.WriteLine($"Country: {customer.Country}");
                    Console.WriteLine($"Phone: {customer.Phone}");
                    Console.WriteLine($"Fax: {customer.Fax}");
                    Console.WriteLine("=======================================================");
                }                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void MostrarProductoConElID()
        {
            try
            { 
                Products product = productsApplication.BuscarELID();
                               
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Quantity Per Unit: {product.QuantityPerUnit}");
                Console.WriteLine($"Unit Price: $ {product.UnitPrice?.ToString("0.00")}");
                Console.WriteLine($"Units In Stock: {product.UnitsInStock}");
                if (product.Discontinued)
                {
                    Console.WriteLine("Discontinued");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void MostrarNombres()
        {
            try
            {
                List<string> nombres = customerApplication.GetCustomersName();
                foreach (var nombre in nombres)
                {
                    Console.WriteLine($"{nombre.ToLower()} || {nombre.ToUpper()}");
                    Console.WriteLine("=======================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void JoinCustomersYOrders()
        {
            try
            {
                List<CustomerOrderDTO> customerOrders = customerApplication.JoinCustomersOrders();
                foreach (var item in customerOrders)
                {
                    Console.WriteLine($"Customer Name: {item.CustomerName}, Order Date: {item.OrderDate}, Region: {item.Region}");
                    Console.WriteLine("===========================================================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void PrimerosCustomersRegionWA()
        {

            try
            {
                List<Customers> customers = customerApplication.RegionIsWA();
                customers = customers.Take(3).ToList();

                foreach (Customers customer in customers)
                {
                    Console.WriteLine($"Company Name: {customer.CompanyName}");
                    Console.WriteLine($"Contact Name: {customer.ContactName}");
                    Console.WriteLine($"Contact Title: {customer.ContactTitle}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine($"City: {customer.City}");
                    Console.WriteLine($"Region: {customer.Region}");
                    Console.WriteLine($"Postal Code: {customer.PostalCode}");
                    Console.WriteLine($"Country: {customer.Country}");
                    Console.WriteLine($"Phone: {customer.Phone}");
                    Console.WriteLine($"Fax: {customer.Fax}");
                    Console.WriteLine("=======================================================");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void MostrarProductosOrdenados()
        {
            try
            {
                List<string> nombres = productsApplication.OrderByName();

                foreach (string nombre in nombres)
                {
                    Console.WriteLine($"- {nombre}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void MostrarProductosOrdenadosPorUnidad()
        {
            try
            {
                List<Products> products = productsApplication.OrderByStock();

                foreach (Products product in products)
                {
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Quantity Per Unit: {product.QuantityPerUnit}");
                    Console.WriteLine($"Unit Price: $ {product.UnitPrice?.ToString("0.00")}");
                    Console.WriteLine($"Units In Stock: {product.UnitsInStock}");
                    if (product.Discontinued)
                    {
                        Console.WriteLine("Discontinued");
                    }
                    Console.WriteLine("=======================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: ", ex.Message);
            }
        }
        private void MostrarCategoriasConProductos()
        {
            try
            {
                List<Categories> categoryProducts = productsApplication.JoinCategoryProduct();

                foreach (Categories categoryProduct in categoryProducts)
                {
                    Console.WriteLine("Category Name: " + categoryProduct.CategoryName);
                    Console.WriteLine("=======================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void PrimerElemento()
        {
            try
            {
                Products product = productsApplication.FirsElement();

                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Quantity Per Unit: {product.QuantityPerUnit}");
                Console.WriteLine($"Unit Price: $ {product.UnitPrice?.ToString("0.00")}");
                Console.WriteLine($"Units In Stock: {product.UnitsInStock}");
                if (product.Discontinued)
                {
                    Console.WriteLine("Discontinued");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void OrdenesCustomers()
        {
            try
            {
                List<CustomerOrderCountDTO> customers = customerApplication.JoinCustomersOrdersCount();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer: {customer.CustomerName} - ContactTitle: {customer.ContactTitle} - Order Count: {customer.OrderCount}");
                    Console.WriteLine("===================================================================================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
