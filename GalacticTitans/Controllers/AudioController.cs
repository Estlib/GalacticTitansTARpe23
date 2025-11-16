using Microsoft.AspNetCore.Mvc;

namespace GalacticTitans.Controllers
{
    public class AudioController : Controller
    {
        public IActionResult AudioPlayer()
        {
            return View();
        }
    }
}
