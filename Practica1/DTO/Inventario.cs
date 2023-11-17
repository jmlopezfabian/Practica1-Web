namespace Practica1.DTO
{
    public class Inventario
    {
        public int Numero { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public string Due { get; set; }

        public Inventario(int new_Numero, string new_Producto, int new_Cantidad, string new_Due)
        {
            Numero = new_Numero;
            Producto = new_Producto;
            Cantidad = new_Cantidad;
            Due = new_Due;
        }
    }
}
