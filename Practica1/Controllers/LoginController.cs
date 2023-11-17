using Microsoft.AspNetCore.Mvc;
using Practica1.Model;
using Practica1.Context;

namespace Practica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    
    public class LoginController
    {
        [HttpPost]
        public bool login([FromBody] Usuario new_user)
        {
            bool existe = false;
            using (AlmacenContext contexto = new AlmacenContext())
            {
                var user_aux = contexto.usuarios;
                foreach(var item in user_aux)
                {
                    if(item.NombreUsuario == new_user.NombreUsuario && item.Contrasena == new_user.Contrasena)
                    {
                        existe = true;
                    }
                }
                return existe;
            }
        }
    }
}
