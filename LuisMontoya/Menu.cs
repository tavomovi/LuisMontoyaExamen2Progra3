using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    public static class Menu
    {

        static Articulos articulos = new Articulos();
        static Vendedores vendedor = new Vendedores();
        static Categorias categoria = new Categorias();
        public static void MenuPrincipal()
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("a-Artículos");
            Console.WriteLine("b-Facturación");
            Console.WriteLine("c-Reporte");
            Console.WriteLine("d-Salir");
        }

        public static void MenuArticulos()
        {
            Console.WriteLine("Submenú Artículos:");
            Console.WriteLine("1-Agregar");
            Console.WriteLine("2-Borrar");
            Console.WriteLine("3-Consultar");
            Console.WriteLine("4-Salir submenu");

        }

        public static void EjecutarMenu()
        {

            while (true)
            {
                Console.Clear();
                MenuPrincipal();
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine().ToLower();
                Console.Clear();
                if (opcion == "a")
                {
                    while (true)
                    {
                        Console.Clear();
                        double precio;
                        MenuArticulos();
                        Console.Write("Seleccione una opción del submenú de Artículos: ");
                        string subopcion = Console.ReadLine();
                        Console.Clear();

                        if (subopcion == "1")// AGREGAR ARTICULO
                        {
                            string codigo;
                            string nombre;
                            do
                            {
                                codigo = LeerEntradaValida("Digite el codigo del artículo: ", esNumerica: true);
                                if (string.IsNullOrWhiteSpace(codigo))
                                    Console.WriteLine("El codigo no puede quedar en blanco.");
                            } while (string.IsNullOrWhiteSpace(codigo));

                            do
                            {
                                nombre = LeerEntradaValida("Digite el nombre del artículo: ", esNumerica: false);
                                if (string.IsNullOrWhiteSpace(nombre))
                                    Console.WriteLine("El nombre no puede quedar en blanco ni contener numeros.");
                            } while (string.IsNullOrWhiteSpace(nombre));


                            while (true)
                            {
                                Console.WriteLine("Digite el precio del artículo: ");

                                if (!double.TryParse(Console.ReadLine(), out precio))
                                {
                                    Console.WriteLine("Error: El precio debe ser un número válido.");
                                }
                                else break;
                            }

                            articulos.AgregarArticulos(codigo, nombre, precio);
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                        else if (subopcion == "2") //BORRAR ARTICULO
                        {
                            articulos.MostrarArticulos(articulos);

                            // Llamada a método para borrar artículo
                            Console.WriteLine("Digite el codigo del artículo: ");
                            string codigo = Console.ReadLine();
                            articulos.BorrarArticulos(codigo);

                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                        else if (subopcion == "3") // CONSULTAR ARTICULO
                        {
                            // Llamada a método para consultar artículo
                            articulos.MostrarArticulos(articulos);
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                        else if (subopcion == "4")
                        {
                            // Salir del Submenu
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida.");
                        }
                    }
                }
                else if (opcion == "b") //FACTURACION
                {
                    Factura(); // Llamada a método para facturar
                }
                else if (opcion == "c")
                {
                    Console.WriteLine("REPORTES.");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Vendedores.");
                    vendedor.ListadoVendedores();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("---------------------------");

                    Console.WriteLine("Categorias de descuento.");
                    categoria.ListarCategorías();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("---------------------------");

                    Console.WriteLine("Articulos.");
                    articulos.MostrarArticulos(articulos);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
                else if (opcion == "d")
                {
                    Console.WriteLine("Saliendo del programa.");

                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }

        public static void Factura()
        {
            string[] temporalCodigos = new string[5];
            string[] temporalArticulos = new string[5];
            double[] temporalPrecios = new double[5];
            string op = "1";
            int articulosComprados = 0;
            string codigo = "";
            string nombreArticulo = "";
            double precioArticulo = 0;
            double subTotal = 0;
            double precioTotal = 0;
            int pos;
            string nombreVendedor;
            bool opci = true;
            int articuloSi = 0;

            do
            {
                Console.WriteLine("Digite (no) si desea salir.");
                nombreVendedor = vendedor.ObtenerNombrePorCodigo();
                if (nombreVendedor.ToLower() == "no") { return; }
            } while (nombreVendedor == "");

            while (op == "1")
            {
                pos = articulos.ConsultarArticulos();
                if (pos != -1)
                {
                    codigo = articulos.Codigo[pos];
                    nombreArticulo = articulos.Nombre[pos];
                    precioArticulo = articulos.Precio[pos];
                    temporalCodigos[articulosComprados] = codigo;
                    temporalArticulos[articulosComprados] = nombreArticulo;
                    temporalPrecios[articulosComprados] = precioArticulo;
                    articulosComprados++;
                }

                opci = true;
                while (opci == true) 
                {
                    Console.WriteLine("Desea agregar un nuevo articulo a la compra. (1-Si / 2-No)");
                    op = Console.ReadLine();
                    if (op == "1") { opci = false; }
                    else if (op == "2") { opci = false; Console.WriteLine("Saliendo del carrito"); }
                    else { Console.WriteLine("Opción no válida."); 
                    }
                }

            }
            Console.WriteLine("Precione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            // Verificar si no hay artículos comprados
            if (articulosComprados == 0)
            {
                Console.WriteLine("No hay artículos comprados. Saliendo de la facturación. Presione tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("-------- Preventa --------");
            for (int j = 0; j < articulosComprados; j++)
            {
                Console.WriteLine($"Artículo: {temporalCodigos[j]}, Nombre: {temporalArticulos[j]}, Precio: {temporalPrecios[j]}");
                subTotal = subTotal + temporalPrecios[j];
            }

            Console.WriteLine($"Vendedor: {nombreVendedor}, Sub Total: {subTotal}");
            string opt;
            do
            {
                Console.WriteLine("Desea aplicar algun descuento. (1-Si / 2-No)");
                opt = Console.ReadLine();
                if (opt != "1" && opt != "2") { Console.WriteLine("Opción no válida."); }

            } while (opt != "1" && opt != "2");

            string opcion ="" ;
            while (true)
            {
                if (opt == "1")
                {
                    categoria.Promoción();
                    categoria.ListarCategorías();
                    Console.WriteLine("4- No aplica descuento");
                    Console.Write("");
                    Console.Write("Seleccione una opción");
                    opcion = Console.ReadLine();
                    
                    switch (opcion)
                    {
                        case "1":
                            Categoria1 categoria1 = new Categoria1();
                            categoria1.Promoción();
                            Console.WriteLine("Precione una tecla para continuar");
                            Console.ReadKey();
                            precioTotal = subTotal * 0.85;
                            break;

                        case "2":
                            Categoria2 categoria2 = new Categoria2();
                            categoria2.Promoción();
                            precioTotal = subTotal;
                            subTotal *= 2;
                            Console.WriteLine("Precione una tecla para continuar");
                            Console.ReadKey();
                            break;
                        case "3":
                            Categoria3 categoria3 = new Categoria3();
                            categoria3.Promoción();
                            Console.WriteLine("Precione una tecla para continuar");
                            Console.ReadKey();
                            precioTotal = subTotal * 0.5;
                            break;
                        case "4":
                            Console.WriteLine("No Aplica.");
                            precioTotal = subTotal;
                            Console.WriteLine("Precione una tecla para continuar");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                    break;
                }
                else if (opt == "2")
                {
                    precioTotal = subTotal; break;
                }
                else
                {
                    Console.WriteLine("Opción no válida."); Console.WriteLine("¿Desea aplicar algún descuento? (1-Si / 2-No )");
                    opt = Console.ReadLine();
                }

            }
            Console.Clear();
            Console.WriteLine("-------- Facturacion --------");
            if (opcion == "2") {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < articulosComprados; j++)
                    {
                        Console.WriteLine($"Artículo: {temporalCodigos[j]}, Nombre: {temporalArticulos[j]}, Precio: {temporalPrecios[j]}");
                    }
                }                
            }

            else for (int j = 0; j < articulosComprados; j++)
                {
                    Console.WriteLine($"Artículo: {temporalCodigos[j]}, Nombre: {temporalArticulos[j]}, Precio: {temporalPrecios[j]}");
                }

            if (opcion == "1") { Console.WriteLine($"Descuento: 15%"); }
            else if (opcion == "2") { Console.WriteLine($"Descuento: 2x1"); }
            else if (opcion == "3") { Console.WriteLine($"Descuento: Mitad de precio"); }
            else if (opcion == "4") { Console.WriteLine($"Descuento: No aplica descuento"); }
            Console.WriteLine($"Vendedor: {nombreVendedor}, Sub Total: {subTotal}, Total por pagar: {precioTotal}");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private static string LeerEntradaValida(string mensaje, bool esNumerica)
        {
            Console.WriteLine(mensaje);
            string entrada = Console.ReadLine();
            while ((esNumerica && !entrada.All(char.IsDigit)) || (!esNumerica && !entrada.Replace(" ", "").All(char.IsLetter)))
            {
                Console.WriteLine($"Entrada inválida. Por favor, ingrese una entrada {(esNumerica ? "numérica" : "alfabética")}.");

                Console.WriteLine(mensaje);
                entrada = Console.ReadLine();
            }
            return entrada;
        }







    }
}