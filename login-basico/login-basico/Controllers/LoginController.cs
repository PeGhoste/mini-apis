using Microsoft.AspNetCore.Mvc;

namespace login_basico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        // POST: api/login/login
        // Servicio de login - autenticar usuario
        // Recibe: username, password
        // Retorna: mensaje de éxito/error, datos del usuario

        // POST: api/login/register  
        // Servicio de registro - crear nuevo usuario
        // Recibe: username, email, password
        // Retorna: mensaje de éxito/error, ID del nuevo usuario

        // PUT: api/login/update/{id}
        // Servicio de actualización - modificar datos de usuario
        // Recibe: email, password (opcionales)
        // Retorna: mensaje de éxito/error, datos actualizados
    }
}
