using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Models;

namespace Upskillz.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Samurai> Samurais { get; }
        IGenericRepository<Quote> Quotes { get; }
        IGenericRepository<Battle> Battles { get; }

        Task Save();
    }
}
