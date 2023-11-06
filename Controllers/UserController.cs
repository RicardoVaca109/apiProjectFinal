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
            if (user != null) {
                return Ok(user);
            }
            return BadRequest();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User userToValidate)
        {
            if (userToValidate != null)
            {
                
                var existingUser = await _db.usuarios.FirstOrDefaultAsync(u => u.UserMail == userToValidate.UserMail);

                if (existingUser != null)
                {
                    return Ok("El usuario ya existe.");
                }
                else
                {
                    return NotFound("El usuario no existe.");
                }
            }

            return BadRequest("Los datos del usuario son inválidos.");
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            User nuevouser = await _db.usuarios.FirstOrDefaultAsync(x => x.IdUser == newUser.IdUser);
            if (nuevouser == null && newUser !=null)
            {
                await _db.usuarios.AddAsync(newUser);
                await _db.SaveChangesAsync();
                return Ok(newUser);
            }

            return BadRequest("No se creo usuario");
        }
        [HttpDelete("{IdUser}")]
        public async Task<IActionResult> Delete(int IdUser)
        {
            User usuario = await _db.usuarios.FirstOrDefaultAsync(x => x.IdUser == IdUser);
            if (usuario != null)
            {
                _db.usuarios.Remove(usuario);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

    }
}
