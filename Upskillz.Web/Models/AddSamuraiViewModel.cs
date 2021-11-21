using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Upskillz.Web.Models
{
    public class AddSamuraiViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Name { get; set; }
        public string ImageUrl { get; set; } = "https://cdn.dribbble.com/users/145072/screenshots/4258729/samuraidrib_copy.jpg";    

        [Required(ErrorMessage = "This field is required")]
        public string ShortStory { get; set; }

        [Required(ErrorMessage = "Please enter a quote for the legend")]
        public string Quote { get; set; }
    }
}
