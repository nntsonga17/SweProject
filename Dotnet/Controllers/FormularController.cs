using System.Net.Mail;
using System.Text;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Authorization;
namespace Web.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class FormularController : Controller
    {
        private readonly KlinikaContext _context;
        private readonly PacijentController _pacijentController;
        private readonly EmailController _emailController;

        public FormularController(KlinikaContext context,IEmailService emailService)
        {
            _context=context;
            _pacijentController = new PacijentController(context);
            _emailController = new EmailController(emailService);
        }
        [HttpPost]
        [Route("createFormular")]
        //ZOVE PACIJENT!!
        public async Task<IActionResult> DodajFormular([FromBody] Formular formular)
        {
            try
            {
                bool exists = _context.Pacijenti.Any(p=>p.Email == formular.Email);
                if(!exists)
                {
                    await _pacijentController.DodajPacijenta(formular);
                }
                formular.Scheduled = false;
                var pacijent = await _context.Pacijenti.FirstAsync(p => p.Email == formular.Email);
                await _context.Formulari.AddAsync(formular);
                await _context.SaveChangesAsync();
                return Ok(formular);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpGet,Authorize(Roles = "user,dir")]
        [Route("getFormulars/{scheduled}")]
        public async Task<IActionResult> getFormulars(bool scheduled)
        {
            try
            {
            if (scheduled)
            {
                var formulars = await _context.Formulari.Where(f=>f.Scheduled == true).ToListAsync();
                return Ok(formulars);
            }
            else
            {
                var formulars = await _context.Formulari.Where(f=>f.Scheduled == false).ToListAsync();
                return Ok(formulars);
            }
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpGet,Authorize(Roles = "user,dir")]
        [Route("getFormularsByDoctorId/{doctorId}")]
        public async Task<IActionResult> getFormularsByDoctorId(int doctorId)
        {
            try
            {
            var formulari = await _context.Formulari.Where(f=>f.Doktor.ID == doctorId).ToListAsync();
            return Ok(formulari);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpPut,Authorize(Roles = "user,dir")]
        [Route("scheduleFormular/{formularId}/{dateTime}/{doctorId}")]
        public async Task<IActionResult> scheduleFormular(int formularId, DateTime dateTime,int doctorId)
        {
            try
            {
                var formular = await _context.Formulari.FindAsync(formularId);
                if(formular == null)
                {
                    return BadRequest("formular je null");
                }
                var doktor = await _context.ClanoviKlinike.FindAsync(doctorId);
                if(doktor == null)
                {
                return BadRequest("doktor je null");
                }
                formular.Scheduled = true;
                formular.Doktor=doktor;
                formular.datumPregleda = dateTime;
                _context.Formulari.Update(formular);
                await _context.SaveChangesAsync();
                
                EmailDTO req = new EmailDTO(formular.Email,formular.Ime,dateTime.ToString());
                _emailController.SendEmail(req);
                return Ok(req.Subject);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpDelete,Authorize(Roles = "dir")]
        [Route("removeFormular/{formId}")]
        public async Task<IActionResult> deleteFormular(int formId)
        {
            try{
                var form = await _context.Formulari.FindAsync(formId);
                _context.Formulari.Remove(form);
                await _context.SaveChangesAsync();
                return Ok(form);
            }
             catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
    }
}