using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistemaPanaderia.Enums;
using sistemaPanaderia.Modelos;

namespace sistemaPanaderia.Modelos
{
    public static class GestionProductos
    {
        static List<Producto> Productos = new List<Producto>();
        static string Archivo = "Productos.txt";
        static public void Agregar(Producto producto)
        {
            Productos.Add(producto);
            Console.WriteLine("Producto agregado con exito");
            GuardarProducto(producto);
        }
        static public void MostrarProductos()
        {
            if (Productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados");
            }
            else
            {
                Console.WriteLine("\nLista de productos");
                foreach (var producto in Productos)
                {
                    Console.WriteLine(producto);
                }
            }
        }
        static public void ActualizarProducto(string nombre, decimal precio)
        {
            var producto = Productos.Find(m => m.Nombre == nombre);
            if (producto == null)
            {
                Console.WriteLine($"producto '{nombre}' no encontrado.");
            }
            else
            {
                producto.Precio = precio;
               
                Console.WriteLine($"producto '{nombre}' actualizado.");
                GuardarDatos();
            }
        }
        static public void EliminarProducto(string nombre)
        {
            var producto = Productos.Find(m => m.Nombre == nombre);
            if (producto == null)
            {
                Console.WriteLine($"producto '{nombre}' no encontrado.");
            }
            else
            {
                Productos.Remove(producto);
                Console.WriteLine($"producto '{nombre}' eliminado.");
                GuardarDatos();
            }
        }
        static void GuardarProducto(Producto producto)
        {
            using StreamWriter writer = new(Archivo, true);
            writer.WriteLine(producto);
        }

        static void GuardarDatos()
        {
            using StreamWriter writer = new(Archivo);
            foreach (var producto in Productos)
            {
                writer.WriteLine(producto);
            }
        }

        static public void CargarDatos()
        {
            if (File.Exists(Archivo))
            {
                foreach (var linea in File.ReadLines(Archivo))
                {
                    string[] d = linea.Split(",");

                    string nombre = d[0];
                    decimal precio = decimal.Parse(d[1]);

                    Categoria categoria = (Categoria)Enum.Parse(typeof(Categoria), d[1]);



                    Producto producto = new Producto(nombre, precio, categoria);
                    Productos.Add(producto);
                }
                Console.WriteLine("Datos cargados correctamente.");
            }
        }
        static public void CalcularPrecioTotal()
        {
            decimal total = 0;
            foreach(var  producto in Productos){
                total = total + producto.Precio;
            }
            Console.WriteLine($"El valor total de la mercancia es de {total} pesos.");
        }
    }
}
