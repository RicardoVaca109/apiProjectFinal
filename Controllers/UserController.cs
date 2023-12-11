using apiBodega.Data;
using apiBodega.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiBodega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> users = await _db.usuarios.ToListAsync();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{IdUser}")]
        public async Task<IActionResult> Get(int IdUser)
        {
            User user = await _db.usuarios.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User usuario)
        {

            // En caso de que el framework no valide que ya exista un ID que ya existe debemos validar nosotros
            User existingUser = await _db.usuarios.FirstOrDefaultAsync(x => x.UserMail== usuario.UserMail && x.UserPassword == usuario.UserPassword);

            //var existingUser = _db.usuarios.FirstOrDefaultAsync(u => u.UserMail == existingUser.UserMail && u.UserPassword == existingUser.UserPassword);
            if (existingUser != null)
            {
                return Ok(existingUser);
            }
            else
            {
                return NotFound("El usuario no existe.");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            User nuevouser = await _db.usuarios.FirstOrDefaultAsync(x => x.IdUser == newUser.IdUser);
            if (nuevouser == null && newUser != null)
            {
                await _db.usuarios.AddAsync(newUser);
                await _db.SaveChangesAsync();
                return Ok(newUser);
            }

            return BadRequest("No se creo correctamente el  usuario");
        }

        [HttpDelete("{IdUser}")]
        public async Task<IActionResult> Delete(int IdUser)
        {
            User usuario = await _db.usuarios.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if (usuario != null)
            {
                _db.usuarios.Remove(usuario);
                await _db.SaveChangesAsync();
                return Ok("Usuario Eliminado Correctamente");
            }
            return BadRequest("No se logró eliminar al usuario");
        }

        /*[HttpGet]
        [Route("api/User/VerifyCredentials")]
        public async Task<IActionResult> VerifyCredentials(string usermail, string userpassword)
        {
            // Lógica para verificar las credenciales en tu base de datos o sistema de autenticación
            var user = _db.usuarios.FirstAsync(u=> u.UserMail == usermail && u.UserPassword==userpassword);

            if (user != null && usermail==)
            {
                return Ok("El usuario SI existe."); // Retorna el usuario si las credenciales son correctas
            }
            else
            {
                return NotFound("No existe usuario"); // Retorna un código 404 si las credenciales son incorrectas o el usuario no existe
            }*/
        

    }
}
