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
        public string ImageUrl { get; set; }
        public string ShortStory { get; set; }
        public string Quote { get; set; }
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
