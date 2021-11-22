using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Upskillz.Utilities;

namespace Upskillz.Core.Interfaces
{
    public interface IImageService
    {
        Task<Response<UploadResult>> UploadAsync(IFormFile image);
        Task<Response<DelResResult>> DeleteResourcesAsync(string publicId);
    }
}
