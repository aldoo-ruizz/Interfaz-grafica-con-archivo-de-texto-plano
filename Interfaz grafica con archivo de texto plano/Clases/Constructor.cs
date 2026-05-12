using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz_grafica_con_archivo_de_texto_plano.Clases
{
    /// <summary>
    /// 120526
    /// se creo una clase Constructor que tiene las propiedades Id, Nombre, Precio y Cantidad. Esta clase se utiliza para crear objetos que representan los productos que se agregan, modifican y eliminan en la interfaz gráfica. Cada objeto de la clase Constructor representa un registro de producto con su respectiva información.
    /// </summary>
    internal class Constructor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public Constructor(int id, string nombre, int precio, int cantidad)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
            
