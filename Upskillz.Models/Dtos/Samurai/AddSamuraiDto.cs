using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upskillz.Models.Dtos.Samurai
{
    public class AddSamuraiDto
    {
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
