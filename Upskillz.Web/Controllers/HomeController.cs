using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Upskillz.Core.Interfaces;
using Upskillz.Web.Models;

namespace Upskillz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IQuoteService _quoteService;

        public HomeController(ILogger logger, IQuoteService quoteService)
        {
            _logger = logger;
            _quoteService = quoteService;
        }

        public async Task<IActionResult> Index()
        {
            var quotesTask = await _quoteService.GetQuotes();
            var quotes = quotesTask.Data;
            return View(quotes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
