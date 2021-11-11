using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Data.Abstractions;
using Upskillz.Models;

namespace Upskillz.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Samurai> _samurais;
        private IGenericRepository<Quote> _quotes;
        private IGenericRepository<Battle> _battles;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a new instance of GenericRepositoy<Samurai> if _samurais is null
        /// </summary>
        public IGenericRepository<Samurai> Samurais => _samurais ??= new GenericRepository<Samurai>(_context);

        public IGenericRepository<Quote> Quotes => _quotes ??= new GenericRepository<Quote>(_context);

        public IGenericRepository<Battle> Battles => _battles ??= new GenericRepository<Battle>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
