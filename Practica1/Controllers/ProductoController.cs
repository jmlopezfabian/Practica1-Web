using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Practica1.Context;
using Practica1.Model;

namespace Practica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController
    {
        [HttpGet]
        public JsonResult getProducto()
        {
            List<Producto> productos = new List<Producto>();
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var aux = contexto.productos;
                foreach (var item in aux)
                {
                    productos.Add(new Producto
                    {
                        NumeroSKU = item.NumeroSKU,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Foto = item.Foto
                    });
                 
                }
            }
            return new JsonResult(productos);
        }

        [HttpPost]
        public JsonResult postProducto([FromBody] Producto new_producto)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                contexto.productos.Add(new_producto);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }
    }
}
