using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica1.Context;
using Practica1.Model;
//7166
namespace Practica1.Controllers
{
    [Route("AlmacenController")]
    [ApiController]
    public class AlmacenController
    {

        [HttpGet]
        public JsonResult getAlmacen()
        {
            List<Almacen> almacenes = new List<Almacen>();
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var aux = contexto.almacenes;
                foreach (var item in aux)
                {
                    almacenes.Add(new Almacen
                    {
                        numero = item.numero,
                        nombre = item.nombre,
                        inventarios = item.inventarios
                    });

                }
            }
            return new JsonResult(almacenes);
        }

        [HttpPost]
        public JsonResult postProducto([FromBody] Almacen new_almacen)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                contexto.almacenes.Add(new_almacen);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }


        [HttpPatch]
        public JsonResult patchProducto([FromBody] Almacen new_almacen)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.almacenes.SingleOrDefault(i => i.numero == new_almacen.numero);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.almacenes.Attach(new_almacen);
                    contexto.Entry(new_almacen).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deleteProducto([FromBody] Almacen new_almacen)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.almacenes.SingleOrDefault(i => i.numero == new_almacen.numero);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.almacenes.Attach(new_almacen);
                    contexto.Entry(new_almacen).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }


    }
}
