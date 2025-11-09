using GalacticTitans.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GalacticTitans.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ResourceListing()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult GeneralError()
        {
            List<string> errordatas = ["StatusMessage", "Something went wrong, go back and hope your shit didnt delete."];
            ViewBag.ErrorDatas = errordatas;
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult UnderConstructionError()
        {
            List<string> errordatas = ["Area", "Login/Register", "Status", "Under Construction"];
            ViewBag.ErrorDatas = errordatas;
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult PlanetsUnavailableError()
        {
            List<string> errordatas = ["Area", "Planets", "Status", "Unavailable"];
            ViewBag.ErrorDatas = errordatas;
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult TitansUnavailable()
        {
            List<string> errordatas = ["Area", "Titans", "Status", "Unavailable", "StatusMessage", "For one unknown reason or another, this area is unavailable"];
            ViewBag.ErrorDatas = errordatas;
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult TitansUnderConstructionError()
        {
            List<string> errordatas = ["Area", "Titans", "Status", "Under Construction", "StatusMessage", "This area is under construction.\nIf this is displayed in a gameplay setting,\nplease notify a sysadmin. Go to \"Contacts\" \nand send email to us with info specified on page. "];
            ViewBag.ErrorDatas = errordatas;
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
