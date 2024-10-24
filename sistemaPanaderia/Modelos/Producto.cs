using sistemaPanaderia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemaPanaderia.Modelos
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio {get; set; }
        public Categoria Categoria { get; set; }

        public Producto (string nombre, decimal precio, Categoria categoria)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }
        public override string ToString()
        {
            return $"{Nombre},{Precio},{Categoria}";
        }
    }
}
