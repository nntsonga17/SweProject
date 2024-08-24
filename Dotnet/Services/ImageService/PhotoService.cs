using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace Web.Services.ImageService
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _config;
        public PhotoService(IConfiguration config)
        {
            _config = config;
            var acc = new Account(
                _config.GetSection("CloudinarySettings:CloudName").Value,
                _config.GetSection("CloudinarySettings:ApiKey").Value,
                _config.GetSection("CloudinarySettings:ApiSecret").Value
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0 )
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName,stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}