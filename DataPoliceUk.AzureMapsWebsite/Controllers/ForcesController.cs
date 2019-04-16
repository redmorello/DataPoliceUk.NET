using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Controllers
{
    public class ForcesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Forces description page.";

            return View();
        }
    }
}
