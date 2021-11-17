using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Upskillz.Core.Interfaces;
using Upskillz.Data.Abstractions;

namespace Upskillz.Web.Controllers
{
    public class SamuraiController : Controller
    {
        private readonly ISamuraiService _samuraiService;

        public SamuraiController(ISamuraiService samuraiService)
        {
            _samuraiService = samuraiService;
        }
        public async Task<IActionResult> AllSamurais()
        {
            var samuraisTask = await _samuraiService.GetSamurais();
            var samurais = samuraisTask.Data;
            return View(samurais);
        }
    }
}
