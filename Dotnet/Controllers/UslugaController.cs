using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UslugaController : Controller
    {
        private readonly KlinikaContext _context;

        public UslugaController(KlinikaContext context)
        {
            _context=context;
        }
        [HttpPost, Authorize(Roles = "dir")]
        [Route("addService")]
        public async Task<IActionResult> DodajUslugu([FromBody] Usluga usluga)
        {
            try
            {
                await _context.AddAsync(usluga);
                await _context.SaveChangesAsync();
                return Ok(usluga);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpPut, Authorize(Roles = "dir")]
        [Route("updateService")]
        public async Task<IActionResult> AzurirajUslugu([FromBody] Usluga usluga)
        {
            try
            {
                _context.Usluge.Update(usluga);
                await _context.SaveChangesAsync();
                return Ok(usluga);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpDelete, Authorize(Roles = "dir")]
        [Route("removeService/{id}")]
        public async Task<IActionResult> ObrisiUslugu(int id)
        {
            try
            {
                var u = await _context.Usluge.FindAsync(id);
                _context.Usluge.Remove(u);
                await _context.SaveChangesAsync();
                return Ok(u);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpGet]
        [Route("getAllServices")]
        public async Task<IActionResult> getAllServices()
        {
            try
            {
                var services = await _context.Usluge.ToListAsync();
                return Ok(services);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
    }
}