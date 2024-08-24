using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Web.Services.ImageService;
using Web.Services;
using Microsoft.AspNetCore.Identity;

namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ClanKlinikeController : ControllerBase
    {
        private readonly KlinikaContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPhotoService _photoService;
        private readonly IUserService2 _userService;

        public ClanKlinikeController(KlinikaContext context,IConfiguration conf,IPhotoService photoService, IUserService2 userService)
        {
            _context=context;
            _configuration = conf;
            _photoService = photoService;
            _userService = userService;
        }

        [HttpGet]
        [Route("getAllDoctors")]
        public async Task<IActionResult> getAllDoctors()
        {
            try
            {
                var clanovi = await _context.ClanoviKlinike.ToListAsync();
                return Ok(clanovi);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpPost, Authorize(Roles = "dir")]
        [Route("addDoctor/{idRecepcije}")]
        public async Task< IActionResult> DodajClanaKlinike([FromBody]ClanKlinike clan,int idRecepcije)
        {
            try
            {
                var r = await _context.Recepcije.FindAsync(idRecepcije);
                clan.RadnoMesto = r;
                await _context.AddAsync(clan);
                await _context.SaveChangesAsync();
                return Ok(clan);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        
        [HttpPut, Authorize(Roles = "dir")]
        [Route("updateDoctor")]
        public async Task<IActionResult> AzurirajClanaKlinike([FromBody] ClanKlinike clan)
        {
            try
            {
                _context.Update<ClanKlinike>(clan);
                await _context.SaveChangesAsync();
                return Ok(clan);
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpDelete, Authorize(Roles = "dir")]
        [Route("removeDoctor/{email}")]
        public async Task<IActionResult> ObrisiClanaKlinike(string email)
        {
            try
            {
                var clan = await _context.ClanoviKlinike.Where(p=>p.Email == email).FirstAsync();
                _context.Remove(clan);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Web.ClanReqRegister req)
        {
            bool exists = _context.ClanoviKlinike.Any(p=>p.Email == req.email);

            if(exists)
            {
                return BadRequest("Email vec postoji");
            }
            ClanKlinike noviClan = new ClanKlinike
            {
                Email = "string",
                PasswordHash = "string",
                Ime = "string",
                Prezime = "string",
                BrojTelefona = "string",
                Direktor = false
            };
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(req.password);

            noviClan.Email = req.email;
            noviClan.PasswordHash = passwordHash;
            noviClan.Ime = req.ime;
            noviClan.Prezime = req.prezime;
            noviClan.BrojTelefona = req.BrojTelefona;
            noviClan.Direktor = req.direktor;

            await _context.ClanoviKlinike.AddAsync(noviClan);
            await _context.SaveChangesAsync();
            string AccountType = "user";
            if(noviClan.Direktor==true)
            {
                AccountType = "dir";
            }
            string token = CreateToken(noviClan,AccountType);
            var result = new{token,AccountType};
            return Ok(result);
        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> Login([FromBody] Web.LoginReq req)
        {
            bool exists = _context.ClanoviKlinike.Any(p=>p.Email==req.email);
            if(exists)
            {
                var clanTmp = await _context.ClanoviKlinike.Where(p=>p.Email == req.email).FirstAsync();
                
                if(!BCrypt.Net.BCrypt.Verify(req.password, clanTmp.PasswordHash))
                {
                    return BadRequest("Netacna lozinka");
                }
                string AccountType = "user";

                if(clanTmp.Direktor == true)
                {
                    AccountType = "dir";
                }
                string token = CreateToken(clanTmp,AccountType);
                var result = new {token, AccountType};
                return Ok(result);
            }
            return BadRequest("Nije pronadjen email");
        }

        private string CreateToken(ClanKlinike clan, string accType)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, clan.ID.ToString(), "id"),
                new Claim(ClaimTypes.Role, $"{accType}", "role")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("JwtSettings:Key").Value
            ));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        [HttpPost,Authorize(Roles = "user,dir")]
        [Route("addData/{spec}")]
        public async Task<IActionResult> DodajPodatke(int idClana,string spec)
        {
            try
            {
                var c = await _context.ClanoviKlinike.FindAsync(idClana);
                c.Specijalizacija = spec;
                await _context.SaveChangesAsync();
                return Ok(c);
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        [HttpPost,Authorize(Roles = "user,dir")]
        [Route("UploadPhoto/{file}/{idKorisnika}")]
        public async Task<IActionResult> uploadPhoto(IFormFile file, int idKorisnika)
        {
            var korisnik = await _context.ClanoviKlinike.FindAsync(idKorisnika);

            var result = await _photoService.AddPhotoAsync(file);

            if(result.Error != null) return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            await _context.Slike.AddAsync(photo);
            korisnik.Slika = photo;
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ec)
            {
                return BadRequest(ec.Message);
            }
        }
        
        [Authorize]
        [HttpGet("/user")]
        public async Task<IActionResult> getLoggedInUser()
        {
           var id = _userService.GetUserId();
           var role = _userService.GetUserRole();
           var bul = _userService.IsAuthenticated();

           var result = new {id, role};
           
           return Ok(result);
        }
    }
}
