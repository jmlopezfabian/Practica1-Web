using Microsoft.AspNetCore.Mvc;
using Practica1.Model;
using Practica1.Context;
using Microsoft.EntityFrameworkCore;

namespace Practica1.Controllers
{
    [ApiController]
    [Route("InventarioController")]
    public class InventarioController
    {
        [HttpGet]
        public JsonResult getInventario()
        {
            List<Inventario> inventarios = new List<Inventario>();
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var aux = contexto.inventarios;
                foreach(var item in aux)
                {
                    
                    inventarios.Add(new Inventario
                    {
                        Numero = item.Numero,
                        Producto = item.Producto,
                        Cantidad = item.Cantidad,
                        Due = item.Due
                    });
                    
                }
            }
            return new JsonResult(inventarios);
        }

        [HttpPost]
        public JsonResult postInventario([FromBody] Inventario new_inventario)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                contexto.inventarios.Add(new_inventario);

                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }

        [HttpPatch]
        public JsonResult patchInventario([FromBody] Inventario new_inv)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.inventarios.SingleOrDefault(i => i.Numero == new_inv.Numero);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.inventarios.Attach(new_inv);
                    contexto.Entry(new_inv).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deleteInventario([FromBody] Inventario new_inv)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.inventarios.SingleOrDefault(i => i.Numero == new_inv.Numero);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.inventarios.Attach(new_inv);
                    contexto.Entry(new_inv).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }
    }
}
