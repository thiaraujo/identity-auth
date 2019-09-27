using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoginWeb.Controllers
{
    // Use the [Authorize] attribute to have ASP.NET do the necessary handles to validate the Identity state.
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
