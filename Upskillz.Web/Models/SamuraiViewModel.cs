using System.Collections.Generic;
using Upskillz.Models;

namespace Upskillz.Web.Models
{
    public class SamuraiViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Story { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<Battle> Battles { get; set; }
    }
}
