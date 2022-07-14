using Aspnet.Mal3ab.Models;
using AspnetRun.Application.Interfaces;
using AspnetRun.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aspnet.Mal3ab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourtService _courtService;

        public HomeController(ILogger<HomeController> logger, ICourtService courtService)
        {
            _logger = logger;
            _courtService = courtService;
        }

        public IActionResult Index()
        {

            return View(_courtService.SearchCourts(new CourtDto { Take = 6 }));
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