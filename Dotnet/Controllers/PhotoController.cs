using Web.Services.ImageService;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        private readonly PhotoService _photoService;

        public PhotoController(PhotoService photoService)
        {
            _photoService = photoService;
        }

        
    }
}