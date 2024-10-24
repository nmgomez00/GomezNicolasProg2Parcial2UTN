using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using sistemaPanaderia.Enums;

namespace sistemaPanaderia.Modelos
{
    public static class Menu
    {
        private static List<Action> Acciones = new List<Action>
       {
           AgregarProducto,
           MostrarProductos,
           ActualizarProducto,
           EliminarProducto,
           CalcularPrecioTotal
       };
        public static void MostrarMenu()
        {
            GestionProductos.CargarDatos();
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n --- Menu de productos ---\n" +
                    "1. Agregar producto \n" +
                    "2. Mostrar productos\n" +
                    "3. Actualizar producto\n" +
                    "4. Eliminar producto \n" +
                    "5. Calcular precio total de la mercancia \n" +
                    "6. Salir \n");
                Console.WriteLine("Seleccone una opcion");
                string opcion = Console.ReadLine();
                int indice;
                if (int.TryParse(opcion, out indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
            }
        }
        static Producto CrearProducto()
        {
            Console.WriteLine("Escriba el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto:");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Seleccone la Categoria: ");
            foreach (var Categoria in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine($".{(int)Categoria}. {Categoria}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Categoria categoriaSeleccion = (Categoria)seleccion;


            Producto nuevoProducto= new Producto(nombre, precio, categoriaSeleccion);


            return nuevoProducto;
        }
        static public void AgregarProducto()
        {
            var NuevoProducto = CrearProducto();
            GestionProductos.Agregar(NuevoProducto);
        }
        static void MostrarProductos() => GestionProductos.MostrarProductos();
        static void ActualizarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo precio:");
            decimal precio = decimal.Parse(Console.ReadLine());


            GestionProductos.ActualizarProducto(nombre, precio);
        }
        static void EliminarProducto()
        {
            Console.WriteLine("Ingrese el nombre de la producto:");
            string nombre = Console.ReadLine();
            GestionProductos.EliminarProducto(nombre);
        }
        static void CalcularPrecioTotal() => GestionProductos.CalcularPrecioTotal();
    }
}

