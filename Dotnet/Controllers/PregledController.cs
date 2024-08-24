using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class PregledController : Controller
    {
        public readonly KlinikaContext _context;
       private readonly EmailController _emailController;

        public PregledController(KlinikaContext context, IEmailService emailService)
        {
            _context = context;
            _emailController = new EmailController(emailService);
        }
        [HttpPost, Authorize(Roles = "user,dir")]
        [Route("createReport/{idLekara}/{idPacijenta}")]
        public async Task<IActionResult> DodajPregled([FromBody] Pregled pregled,int idLekara, int idPacijenta)
        {
            try
            {
                var l = await _context.ClanoviKlinike.FindAsync(idLekara);
                if(l == null) return BadRequest("Ne postoji lekar");
                pregled.Doktor = l;
                var pacijent = await _context.Pacijenti.FindAsync(idPacijenta);
                if(pacijent == null) return BadRequest("Ne postoji pacijent");
                pregled.Pacijent = pacijent;


                //if(form == null) return BadRequest("form je nul");
                //pregled.DatumVreme = form.datumPregleda;

                await _context.Pregledi.AddAsync(pregled);
                await _context.SaveChangesAsync();
                string datum = "27.11.2001";
                EmailDTO req = new EmailDTO(pacijent.Email,pacijent.Ime,pregled.Dijagnoza,datum);
                _emailController.SendEmail(req);
                return Ok(pregled);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpGet, Authorize(Roles = "user,dir")]
        [Route("getAllReportsByDoctorId/{doctorId}")]
        public async Task<IActionResult> getAllReportsByDoctorId(int doctorId)
        {
            try
            {
                var doktor = await _context.ClanoviKlinike.FindAsync(doctorId);
                var pregledi = await _context.Pregledi.Where(p => p.Doktor == doktor).ToListAsync();
                return Ok(pregledi);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
    }
}