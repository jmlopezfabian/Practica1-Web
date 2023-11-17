

namespace Practica1.DTO
{
    public class Almacen
    {
        public int numero { get; set; }
        public string nombre { get; set; }
        public int inventarios { get; set; } //Hacemos una lista de inventarios de tipo inventario

        public Almacen(int new_numero, string new_nombre, int new_inventarios)
        {
            numero = new_numero;
            nombre = new_nombre;
            inventarios = new_inventarios;
        }
    }
}