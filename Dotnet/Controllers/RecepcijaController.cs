using Microsoft.AspNetCore.Authorization;
namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class RecepcijaController : Controller
    {
        private readonly KlinikaContext _context;

        public RecepcijaController(KlinikaContext context)
        {
            _context = context;
        }

        [HttpPost, Authorize(Roles = "dir")]
        [Route("addReception")]
        public async Task<IActionResult> DodajRecepciju([FromBody] Recepcija recepcija)
        {
            try
            {
                await _context.Recepcije.AddAsync(recepcija);
                await _context.SaveChangesAsync();
                return Ok(recepcija);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpDelete, Authorize(Roles = "dir")]
        [Route("removeReception/{id}")]
        public async Task<IActionResult> ObrisiRecepciju(int id)
        {
            try
            {
                var r = await _context.Recepcije.FindAsync(id);
                _context.Recepcije.Remove(r);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
    }
}