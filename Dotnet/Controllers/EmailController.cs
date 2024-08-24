
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}