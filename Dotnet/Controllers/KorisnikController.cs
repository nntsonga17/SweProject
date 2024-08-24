namespace Web.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]

    public class KorisnikController : Controller
    {
        private readonly KlinikaContext _context;
        public KorisnikController(KlinikaContext context)
        {
            _context=context;
        }

        [HttpGet]
        [Route("sviKorisnici")]
        public async Task<IActionResult> getKorisnike()
        {
            var korisnici = await _context.Korisnici.ToListAsync();

            return Ok(korisnici);
        }
        [HttpPost]
        [Route("dodajKorisnikaTEST")]

        public async Task<IActionResult> dodajKorisnika([FromBody] Korisnik korisnikRequest)
        {
            await _context.Korisnici.AddAsync(korisnikRequest);
            await _context.SaveChangesAsync();

            return Ok(korisnikRequest);
        }
        
    }
}