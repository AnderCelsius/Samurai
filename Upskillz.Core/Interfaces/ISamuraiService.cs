using System.Collections.Generic;
using System.Threading.Tasks;
using Upskillz.Models;
using Upskillz.Models.Dtos.Samurai;
using Upskillz.Utilities;

namespace Upskillz.Core.Interfaces
{
    public interface ISamuraiService
    {
        Task<Response<IEnumerable<Samurai>>> GetSamurais();
        Task<Response<Samurai>> GetSamurai(string Id);
        Task<Response<string>> UpdateSamurai(string samuraiId, UpdateSamuraiDto model);
        Task<Response<string>> UpdatePhoto(string samuraiId, AddImageDto imageDto);

    }
}
