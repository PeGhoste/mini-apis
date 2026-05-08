using Microsoft.AspNetCore.Mvc;
using login_basico.DAO;
using login_basico.DTO;

namespace login_basico.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        // Inyectamos el UserDao
        private readonly UsersDao _uDao;

        // Creamos el constructor con la inyección de dependencia
        public LoginController(UsersDao uDao)
        {
            _uDao = uDao;
        }

        // POST: api/login/login
        // Servicio de login - autenticar usuario
        // Recibe: username, password
        // Retorna: mensaje de éxito/error, datos del usuario
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  UsersDTORequest request)
        {
            var user = await _uDao.Login(request.usuario, request.pass);

            if(user != null)
            {
                return Ok();
            }

            return StatusCode(404);

        }


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

