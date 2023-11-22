using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica1.Context;
using Practica1.Model;

namespace Practica1.Controllers
{
    [Route("ProductoController")]
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

        [HttpPatch]
        public JsonResult patchProducto([FromBody] Producto new_producto)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.productos.SingleOrDefault(i => i.NumeroSKU == new_producto.NumeroSKU);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.productos.Attach(new_producto);
                    contexto.Entry(new_producto).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deleteProducto([FromBody] Producto new_producto)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.productos.SingleOrDefault(i => i.NumeroSKU == new_producto.NumeroSKU);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.productos.Attach(new_producto);
                    contexto.Entry(new_producto).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }
    }
}
