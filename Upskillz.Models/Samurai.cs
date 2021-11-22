using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Upskillz.Models
{
    public class Samurai : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ShortStory { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
