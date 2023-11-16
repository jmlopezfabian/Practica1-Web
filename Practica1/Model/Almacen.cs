namespace Practica1.Model
{
    public class Almacen
    {
        public int numero { get; set; }
        public string nombre { get; set; }
        public List<Inventario> inventarios { get; set; } //Hacemos una lista de inventarios de tipo inventario
    }
}