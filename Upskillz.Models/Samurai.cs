using System;
using System.Collections.Generic;

namespace Upskillz.Models
{
    public class Samurai
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
