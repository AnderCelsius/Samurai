using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Upskillz.Core.Interfaces;
using Upskillz.Data.Abstractions;
using Upskillz.Models;
using Upskillz.Models.Dtos.Samurai;
using Upskillz.Web.Models;

namespace Upskillz.Web.Controllers
{
    public class SamuraiController : Controller
    {
        private readonly ISamuraiService _samuraiService;
        private readonly IMapper _mapper;

        public SamuraiController(ISamuraiService samuraiService, IMapper mapper)
        {
            _mapper = mapper;
            _samuraiService = samuraiService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllSamurais(string searchTerm = null)
        {
            if(searchTerm == null)
            {
                var samuraisTask = await _samuraiService.GetSamurais();
                var samurais = samuraisTask.Data;
                return View(samurais);
            }
            var searchResultTask = await _samuraiService.Search(searchTerm);
            var searchResult = searchResultTask.Data;

            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
                return PartialView("_SamuraiList", searchResult);
            else
                return View(searchResult);

        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult AddSamurai()
        {
            var model = new AddSamuraiViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSamurai(AddSamuraiViewModel model)
        {
            if (ModelState.IsValid)
            {
                var addSamuraiDto = _mapper.Map<AddSamuraiDto>(model);
                var response = await _samuraiService.AddSamurai(addSamuraiDto);
                if (response.Succeeded)
                {
                    var result = response.Data;
                    return Json(result, new JsonSerializerSettings());
                }
                ModelState.AddModelError("", response.Message);
            }
            return View(model);
            
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Autocomplete(string term)
        {
            var samuraisTask = await _samuraiService.QuickSearch(term);
            var samurais = samuraisTask.Data;
            var model = samurais.Select(r => new
            {
                label = r.Name
            });
            return Json(model, new JsonSerializerSettings());
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
