using System;
using System.Collections.Generic;

namespace Upskillz.Models
{
    public class Battle : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Samurai> Samurais { get; set; } = new List<Samurai>();
    }
}