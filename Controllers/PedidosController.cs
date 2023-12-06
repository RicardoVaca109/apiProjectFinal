using apiBodega.Data;
using apiBodega.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiBodega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public PedidosController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: PedidosController

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Pedidos> pedidos = await _db.pedidos.ToListAsync();
            return Ok(pedidos);
        }

        [HttpGet("ClienteId")]
        public async Task<IActionResult> ClienteId()
        {
            List<int> clienteids = await _db.pedidos.Select(e => e.ClienteId).ToListAsync();

            return Ok(clienteids);
        }
    }
}
