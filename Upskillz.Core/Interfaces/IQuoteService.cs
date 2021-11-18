using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Models;
using Upskillz.Utilities;

namespace Upskillz.Core.Interfaces
{
    public interface IQuoteService
    {
        Task<Response<Quote>> GetQuote(int id);
        Task<Response<IEnumerable<Quote>>> GetQuotes();
    }
}
