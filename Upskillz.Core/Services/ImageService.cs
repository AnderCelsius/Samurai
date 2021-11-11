using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Core.Interfaces;
using Upskillz.Utilities;

namespace Upskillz.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _config;
        private readonly Cloudinary _cloudinary;
        public ImageService(IConfiguration config, Cloudinary cloudinary)
        {
            _config = config;
            _cloudinary = cloudinary;
        }
        public async Task<Response<UploadResult>> UploadAsync(IFormFile image)
        {
            var pictureSize = Convert.ToInt64(_config["PhotoSettings:Size"]);
            var pictureFormat = false;

            if (image.Length > pictureSize)
            {
                return Response<UploadResult>.Fail("File size exceeded", StatusCodes.Status400BadRequest);
            }
            

            var listOfImageExtensions = new List<string>() { ".jpg", ".png", ".jpeg" };

            foreach (var item in listOfImageExtensions)
            {
                if ((image.FileName.ToLower().EndsWith(item)))
                {
                    pictureFormat = true;
                    break;
                }
            }

            if (pictureFormat == false)
            {
                return Response<UploadResult>.Fail("File format not supported", StatusCodes.Status400BadRequest);
            }

            var uploadResult = new ImageUploadResult();

            using (var imageStream = image.OpenReadStream())
            {
                string filename = Guid.NewGuid().ToString() + image.FileName;

                uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(filename + Guid.NewGuid().ToString(), imageStream),
                    PublicId = "Samurai/" + filename
                });
            }            

            return Response<UploadResult>.Success("Image uploaded successfully", uploadResult);
        }

        public async Task<Response<DelResResult>> DeleteResourcesAsync(string publicId)
        {
            var delParams = new DelResParams
            {
                PublicIds = new List<string> { publicId },
                All = true,
                KeepOriginal = false,
                Invalidate = true
            };


            DelResResult deletionResult = await _cloudinary.DeleteResourcesAsync(delParams);
            if (deletionResult.Error != null)
            {
                return Response<DelResResult>.Fail(deletionResult.Error.ToString(), StatusCodes.Status500InternalServerError);
            }

            return Response<DelResResult>.Success("Resource deleted successfully", deletionResult);
        }
    }
}
