using apiBodega.Data;
using apiBodega.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiBodega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public EmpresaController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Empresa> business = await _db.empresas.ToListAsync();
            return Ok(business);
        }

        [HttpGet("EmpresaID")]
        public async Task<IActionResult> EmpresaID()
        {
            List<int> businessIDs = await _db.empresas.Select(e => e.EmpresaID).ToListAsync();

            return Ok(businessIDs);
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{EmpresaID}")]
        public async Task<IActionResult> Get(int EmpresaID)
        {
            Empresa empresas = await _db.empresas.FirstOrDefaultAsync(x => x.EmpresaID == EmpresaID);
            if (empresas != null) {
                return Ok(empresas);
            }
            return BadRequest();
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empresa empresas )
        {
            Empresa empresa2 = await _db.empresas.FirstOrDefaultAsync(x => x.EmpresaID == empresas.EmpresaID);
            if (empresa2 == null && empresas != null) { 
                await _db.empresas.AddAsync(empresas);
                await _db.SaveChangesAsync();
                return Ok(empresas);
            }
            return BadRequest();
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{EmpresaID}")]
        public async Task<IActionResult> Put(int EmpresaID, [FromBody] Empresa empresa)
        {
            Empresa empresa2 = await _db.empresas.FirstOrDefaultAsync(x => x.EmpresaID == EmpresaID);
            if (empresa2 != null)
            {
                //empresa2.EmpresaID = empresa.EmpresaID != null ? empresa.EmpresaID : empresa2.EmpresaID; 
                empresa2.NombreEmpresa = empresa.NombreEmpresa != null ? empresa.NombreEmpresa : empresa2.NombreEmpresa;
                empresa2.Resumen = empresa.Resumen != null ? empresa.Resumen : empresa2.Resumen;
                _db.empresas.Update(empresa2);
                await _db.SaveChangesAsync();
                return Ok(empresa2);
            }
            return BadRequest();
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{EmpresaID}")]
        public async Task<IActionResult> Delete (int EmpresaID)
        {
            Empresa empresa = await _db.empresas.FirstOrDefaultAsync(x => x.EmpresaID == EmpresaID);
            if (empresa != null)
            {
                _db.empresas.Remove(empresa);
                await _db.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest();
        }
    }
}
