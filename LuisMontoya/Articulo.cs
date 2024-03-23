using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    public class Articulos
    {
        // Atributos protegidos
        protected string[] codigo = new string[5];
        protected string[] nombre = new string[5];
        protected double[] precio = new double[5];
        protected int cantidadArticulos = 0;

        // Constructor en blanco
        public Articulos() { }

        // Constructor con todos los parámetros

        public Articulos(string[] codigos, string[] nombres, double[] precios)
        {
            if (codigos.Length != nombres.Length || nombres.Length != precios.Length)
            {
                throw new ArgumentException("Los arreglos deben tener la misma longitud.");
            }

            if (codigos.Length > 5)
            {
                throw new ArgumentException("No se pueden ingresar más de 5 artículos.");
            }

            for (int i = 0; i < codigos.Length; i++)
            {
                codigo[i] = codigos[i];
                nombre[i] = nombres[i];
                precio[i] = precios[i];
                cantidadArticulos++;
            }
        }

        // Getters y Setters
        public string[] Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string[] Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double[] Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        // Método para agregar artículo
        public void AgregarArticulos(string codigo, string nombre, double precio)
        {
            if (cantidadArticulos < 5)
            {
                this.codigo[cantidadArticulos] = codigo;
                this.nombre[cantidadArticulos] = nombre;
                this.precio[cantidadArticulos] = precio;
                cantidadArticulos++;
                Console.WriteLine("Artículo agregado correctamente.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más artículos, límite alcanzado.");
            }
        }

        // Método para consultar artículo
        public int ConsultarArticulos()
        {
            Console.WriteLine("Digite el código del artículo: ");
            string codigo = Console.ReadLine();
            for (int i = 0; i < cantidadArticulos; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    Console.WriteLine("Código: " + this.codigo[i]);
                    Console.WriteLine("Nombre: " + this.nombre[i]);
                    Console.WriteLine("Precio: " + this.precio[i]);
                    return i; // Devolvemos la posición del artículo encontrado
                }
            }
            Console.WriteLine("Artículo no encontrado.");
            return -1; // Devolvemos -1 si el artículo no se encuentra
        }

        // Método para borrar artículo
        public void BorrarArticulos(string codigo)
        {
            for (int i = 0; i < cantidadArticulos; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    for (int j = i; j < cantidadArticulos - 1; j++)
                    {
                        this.codigo[j] = this.codigo[j + 1];
                        this.nombre[j] = this.nombre[j + 1];
                        this.precio[j] = this.precio[j + 1];
                    }
                    this.codigo[cantidadArticulos - 1] = null;
                    this.nombre[cantidadArticulos - 1] = null;
                    this.precio[cantidadArticulos - 1] = 0;
                    cantidadArticulos--;
                    Console.WriteLine("Artículo borrado correctamente.");
                    return;
                }
            }
            Console.WriteLine("Artículo no encontrado.");
        }

        //Metodo para mostrar articulos
        public void MostrarArticulos(Articulos articulos)
        {
            if (articulos.cantidadArticulos == 0)
            {
                Console.WriteLine("No hay artículos para mostrar.");
            }
            else
            {
                Console.WriteLine("Listado de Artículos:");
                for (int i = 0; i < articulos.cantidadArticulos; i++)
                {
                    Console.WriteLine($"Código: {articulos.codigo[i]}, Nombre: {articulos.nombre[i]}, Precio: {articulos.precio[i]}");
                }
            }
        }

    }
  
}
