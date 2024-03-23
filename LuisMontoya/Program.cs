using LuisMontoya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LuisMontoya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de Ventas.");
            Vendedores vendedor = new Vendedores();
            



            Menu.EjecutarMenu();
        }
    }
}
