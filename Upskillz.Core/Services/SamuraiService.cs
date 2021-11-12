using AutoMapper;
using Serilog;
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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SamuraiService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<Samurai>> AddSamurai(AddSamuraiDto samuraiDto)
        {
            var samurai = _mapper.Map<Samurai>(samuraiDto);
            await _unitOfWork.Samurais.Insert(samurai);
            await _unitOfWork.Save();

            return null;
        }

        public Task<Response<string>> DeleteQuotesForSamurai(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> DeleteSamurai(string id)
        {
            var samurai = await _unitOfWork.Samurais.GetById(id);
            if(samurai == null)
            {
                return Response<bool>.Fail("Samurai does not exist");
            }
            _unitOfWork.Samurais.Delete(samurai);
            await _unitOfWork.Save();
            return Response<bool>.Success(string.Empty, true);
        }

        public async Task<Response<Samurai>> GetSamurai(int id)
        {
            var includes = new List<string>() { "Quote" , "Battle" };

            _logger.Information($"Attempting to get Samurai with Id = {id}");
            var samurai = await _unitOfWork.Samurais.Get(q => q.Id == id, includes);
            if (samurai == null)
            {
                _logger.Information($"Search ended with no result");
                return Response<Samurai>.Fail($"Samurai with Id = {id} does not exist");
            }

            _logger.Information($"Samurai {samurai.Name} returned");
            return Response<Samurai>.Success(string.Empty, samurai);
        }

        public async Task<Response<IEnumerable<Samurai>>> GetSamurais()
        {
            _logger.Information("Getting all samurais");
            var samurais = await _unitOfWork.Samurais.GetAll(includes: new List<string> { "Quotes"});
            return Response<IEnumerable<Samurai>>.Success("Here are the Samurais", samurais);
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
