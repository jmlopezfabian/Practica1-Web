using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica1.Context;
using Practica1.Model;

namespace Practica1.Controllers
{
    [Route("UsuarioController")]
    [ApiController]
    public class UsuarioController
    {
        [HttpGet]
        public JsonResult getUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var aux = contexto.usuarios;
                foreach (var item in aux)
                {
                    usuarios.Add(new Usuario
                    { 
                        Id = item.Id,
                        NombreUsuario = item.NombreUsuario,
                        NombreCompleto = item.NombreCompleto,
                        Contrasena = item.Contrasena,
                        NivelAcceso = item.NivelAcceso
                    });

                }
            }
            return new JsonResult(usuarios);
        }

        [HttpPost]
        public JsonResult postUsuario([FromBody] Usuario new_usuario)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                contexto.usuarios.Add(new_usuario);
                contexto.SaveChanges();
                validacion = true;
            }
            return new JsonResult(validacion);
        }

        [HttpPatch]
        public JsonResult patchProducto([FromBody] Usuario new_usuario)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.usuarios.SingleOrDefault(i => i.Id == new_usuario.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.usuarios.Attach(new_usuario);
                    contexto.Entry(new_usuario).State = EntityState.Modified;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

        [HttpDelete]
        public JsonResult deleteProducto([FromBody] Usuario new_usuario)
        {
            bool validacion = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var existe = contexto.usuarios.SingleOrDefault(i => i.Id == new_usuario.Id);
                if (existe != null)
                {
                    contexto.Entry(existe).State = EntityState.Detached;
                    contexto.usuarios.Attach(new_usuario);
                    contexto.Entry(new_usuario).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    validacion = true;
                }

                return new JsonResult(validacion);
            }
        }

    }
}
