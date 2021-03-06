using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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