using Microsoft.AspNetCore.Mvc;

namespace Practica1.DTO
{
    public class Producto
    {
        public int NumeroSKU { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set;}
        public string Foto { get; set;}

        public Producto(int new_NumeroSKU, string new_Nombre, string new_Descripcion, string new_Foto)
        {
            NumeroSKU = new_NumeroSKU;
            Nombre = new_Nombre;
            Descripcion = new_Descripcion;
            Foto = new_Foto;
        }
    }
}
