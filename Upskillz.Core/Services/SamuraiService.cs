using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Core.Interfaces;
using Upskillz.Data.Abstractions;
using Upskillz.Models;
using Upskillz.Models.Dtos.Samurai;
using Upskillz.Utilities;

namespace Upskillz.Core.Services
{
    public class SamuraiService : ISamuraiService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SamuraiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Response<Samurai>> AddSamurai(AddSamuraiDto samurai)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> DeleteQuotesForSamurai(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteSamurai(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Samurai>> GetSamurai(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Samurai>>> GetSamurais()
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdatePhoto(string samuraiId, AddImageDto imageDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdateSamurai(string samuraiId, UpdateSamuraiDto model)
        {
            throw new NotImplementedException();
        }
    }
}
