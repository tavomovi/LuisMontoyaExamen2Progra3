using LuisMontoya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LuisMontoya
{
    public class Vendedores
    {
        // Diccionario para almacenar los vendedores
        private Dictionary<string, string> vendedores;


        public Vendedores()
        {
            vendedores = new Dictionary<string, string>();
            
            vendedores.Add("1", "Juan");
            vendedores.Add("2", "María");
        }



        // Método para listar vendedores
        public void ListadoVendedores()
        {
            Console.WriteLine("Listado de Vendedores:");
            foreach (var vendedor in vendedores)
            {
                Console.WriteLine($"Código: {vendedor.Key}, Nombre: {vendedor.Value}");
            }
        }

        // Método para obtener el nombre del vendedor por su código
        public string ObtenerNombrePorCodigo()
        {
            string nombre = "";
            Console.WriteLine("Ingrese el codigo del vendedor: ");
            string codigo = Console.ReadLine();
            // Verificar si el código del vendedor existe
            if (vendedores.ContainsKey(codigo))
            {
                nombre = vendedores[codigo];
                return nombre;
            }
            else if (codigo=="no")
            {
                nombre = "no";
                return nombre;
            }
            else
            {
                Console.WriteLine("El vendedor no existe.");
                return nombre;
            }
        }
    }

}


/// CLASE VENDEDOR 1
public class Vendedor1 : IVendedores.IVendedor1
{
    private string nombre;

    // Constructor con el nombre del vendedor ya asignado
    public Vendedor1(string nombre)
    {
        this.nombre = nombre;
    }

    // Implementación de la interfaz Ivendedor1
    public void VentasContado()
    {
        Console.WriteLine($"El vendedor {nombre} realiza ventas al contado.");
    }
}


/// CLASE VENDEDOR 2
public class Vendedor2 : IVendedores.IVendedor2
{
    // Atributo nombre del vendedor
    private string nombre;

    // Constructor con el nombre del vendedor ya asignado
    public Vendedor2(string nombre)
    {
        this.nombre = nombre;
    }

    // Implementación del método VentasCredito de IVendedor2
    public string VentasCredito()
    {
        return $"El vendedor {nombre} realiza ventas a crédito.";
    }
}






