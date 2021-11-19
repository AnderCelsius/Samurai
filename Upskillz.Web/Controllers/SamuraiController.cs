using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Upskillz.Core.Interfaces;
using Upskillz.Data.Abstractions;
using Upskillz.Web.Models;

namespace Upskillz.Web.Controllers
{
    public class SamuraiController : Controller
    {
        private readonly ISamuraiService _samuraiService;

        public SamuraiController(ISamuraiService samuraiService)
        {
            _samuraiService = samuraiService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllSamurais()
        {
            var samuraisTask = await _samuraiService.GetSamurais();
            var samurais = samuraisTask.Data;
            return View(samurais);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SamuraiDetails(string samuraiId)
        {
            var samuraiTask = await _samuraiService.GetSamurai(samuraiId);
            var samurai = samuraiTask.Data;
            if(samurai != null)
            {
                var model = new SamuraiViewModel
                {
                    Id = samurai.Id,
                    Name = samurai.Name,
                    ImageUrl = samurai.ImageUrl,
                    Story = samurai.ShortStory,
                    Quotes = samurai.Quotes,
                    Battles = samurai.Battles
                };
                return View(model);
            }
            return NotFound();
        }
    }
}
