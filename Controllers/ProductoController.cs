using apiBodega.Data;
using apiBodega.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiBodega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public ProductoController(ApplicationDBContext db)
        {
            _db = db;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Producto> productos =await _db.products.ToListAsync();
            return Ok(productos);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{ProveedorId}")]
        public async Task<IActionResult> Get(int ProveedorId)
        {
            List<Producto> productos = await _db.products.Where(x => x.ProveedorId == ProveedorId).ToListAsync();
            if (productos.Count > 0) {
                return Ok(productos);
            }
            return BadRequest("No se encontraron productos para el ProveedorID proporcionado.");
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] Producto producto)
        {
            Producto producto2 = await _db.products.FirstOrDefaultAsync(x => x.ProductoId == producto.ProductoId);
            if(producto2 == null && producto != null) { 
                await _db.products.AddAsync(producto);
                await _db.SaveChangesAsync();
                return Ok(producto);
            }
            return BadRequest();
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{ProductoId}")]
        public async Task<IActionResult>Put(int ProductoId, [FromBody] Producto producto)
        {
            Producto producto2 = await _db.products.FirstOrDefaultAsync(x => x.ProductoId == ProductoId);
            if (producto2 != null)
            {
                producto2.Nombre = producto.Nombre != null ? producto.Nombre : producto2.Nombre;
                producto2.Descripcion = producto.Descripcion != null ? producto.Descripcion : producto2.Descripcion;
                producto2.Precio = producto.Precio != 0 ? producto.Precio : producto2.Precio;
                producto2.CtdenStock = producto.CtdenStock != 0 ? producto.CtdenStock : producto2.CtdenStock ;
                _db.products.Update(producto2);
                await _db.SaveChangesAsync();
                return Ok(producto2);
            }
            return BadRequest();

        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{ProductoId}")]
        public async Task<IActionResult> Delete(int ProductoId)
        {
            Producto producto = await _db.products.FirstOrDefaultAsync(x => x.ProductoId == ProductoId);
            if (producto != null)
            {
                _db.products.Remove(producto);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
