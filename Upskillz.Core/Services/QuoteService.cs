using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using Upskillz.Core.Interfaces;
using Upskillz.Data.Abstractions;
using Upskillz.Models;
using Upskillz.Utilities;

namespace Upskillz.Core.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public QuoteService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response<Quote>> GetQuote(int id)
        {
            _logger.Information($"Attempting to get Quote with Id = {id}");
            var quote = await _unitOfWork.Quotes.Get(q => q.Id == id);
            if (quote == null)
            {
                _logger.Information($"Search ended with no result");
                return Response<Quote>.Fail($"Quote with Id = {id} does not exist");
            }

            _logger.Information($"Quote returned");
            return Response<Quote>.Success(string.Empty, quote);
        }

        public async Task<Response<IEnumerable<Quote>>> GetQuotes()
        {
            var includes = new List<string>() { "Samurai" };

            _logger.Information("Getting all samurais");
            var quotes = await _unitOfWork.Quotes.GetAll(includes: includes);
            return Response<IEnumerable<Quote>>.Success("Here are the Quotes", quotes);
        }

    }
}
