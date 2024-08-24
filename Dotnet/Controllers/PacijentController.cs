using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class PacijentController : Controller

    {
        private readonly KlinikaContext _context;
        public PacijentController(KlinikaContext context)
        {
            _context=context;
        }
        [HttpPost]
        public async Task<IActionResult> DodajPacijenta(Formular formular)
        {
            try
            {
                Pacijent pacijent = new Pacijent
                {
                    Ime = formular.Ime,
                    Prezime = formular.Prezime,
                    Email = formular.Email,
                    BrojTelefona = formular.BrojTelefona,
                    DatumRodjenja = formular.DatumRodjenja
                };
                await _context.Pacijenti.AddAsync(pacijent);
                await _context.SaveChangesAsync();
                return Ok(pacijent);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpGet]
        [Route("getAllPatients")]
        public async Task<IActionResult> getAllPatients()
        {
            try
            {
                var pacijenti = await _context.Pacijenti.ToListAsync();
                return Ok(pacijenti);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpDelete,Authorize(Roles = "dir")]
        [Route("removePatient/{patientId}")]
        public async Task<IActionResult> deletePatient(int patientId)
        {
            try
            {
                var patient = await _context.Pacijenti.FindAsync(patientId);
                _context.Pacijenti.Remove(patient);
                await _context.SaveChangesAsync();
                return Ok(patient);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
    }
}