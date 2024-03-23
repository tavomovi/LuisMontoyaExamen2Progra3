using LuisMontoya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    public class Categorias
    {
        private string nombre;

        public Categorias()
        {
           
        }
        // Constructor
        public Categorias(string nombre)
        {
            this.nombre = nombre;
        }
        // Método promoción
        public virtual void Promoción()
        {
            Console.WriteLine("Descuentos y promociones");
        }

        // Lista de las tres categorías posibles
        private static List<Categorias> categoria = new List<Categorias>()
        {
            new Categorias("1- Categoría 1 (15%)"),
            new Categorias("2- Categoría 2 (2x1)"),
            new Categorias("3- Categoría 3 (50%)")
        };

        //Metodo listado de categorias
        public void ListarCategorías()
        {
            Console.WriteLine("Listado de Categorías:");
            foreach (var categoria in categoria)
            {
                Console.WriteLine(categoria.nombre);
            }
        }

        //funcion booleana para saber si la categoria existe
        static bool ExisteCategoría(List<Categorias> categorias)
        {
            // Comprobar si hay al menos una categoría en la lista
            return categorias.Count > 0;
        }
    }


    //Clase Categoria 1
    public class Categoria1 : Categorias
    {
        public Categoria1() : base("Categoría 1")
        {
        }

        // Método promoción específico para Categoría1
        public override void Promoción()
        {
            Console.WriteLine("Descuento de 15%");
        }
    }

    //Clase Categoria 2
    public class Categoria2 : Categorias
    {
        public Categoria2() : base("Categoría 2")
        {
        }
        // Método promoción específico para Categoría1
        public override void Promoción()
        {
            Console.WriteLine("Promoción 2 por 1");
        }
    }

    //Clase Categoria 3
    public class Categoria3 : Categorias
    {
        public Categoria3() : base("Categoría 3")
        {
        }
        // Método promoción específico para Categoría1
        public override void Promoción()
        {
            Console.WriteLine("Todo a mitad de precio");
        }
    }
}