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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
