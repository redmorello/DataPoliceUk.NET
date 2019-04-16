using Microsoft.AspNetCore.Mvc;

namespace DataPoliceUk.AzureMapsWebsite.Controllers
{
    public class StreetCrimesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Street Crimes description page.";

            return View();
        }
    }
}
