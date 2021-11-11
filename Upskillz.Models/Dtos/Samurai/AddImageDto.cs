using Microsoft.AspNetCore.Http;

namespace Upskillz.Models.Dtos.Samurai
{
    public class AddImageDto
    {
        public IFormFile File { get; set; }
    }
}
