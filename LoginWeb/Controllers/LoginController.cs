using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LoginWeb.Identity;
using LoginWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LoginWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // User Validation Example and Claims Creation
        [HttpPost]
        public async Task<IActionResult> Index(int id, string passw)
        {
            var findUser = new UserWeb().GetUsers().FirstOrDefault(x => x.Id == id && x.Password == passw);
            if (findUser == null)
                return View();

            await AddClaimsLogin(findUser);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            // Remove cookies and redirect to login
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }

        private async Task AddClaimsLogin(UserWeb user)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            // Adds the values to the claims we create.
            identity.AddClaim(new Claim(IdentityExtensions.CustomClaimTypes.Id, user.Id.ToString()));
            identity.AddClaim(new Claim(IdentityExtensions.CustomClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(IdentityExtensions.CustomClaimTypes.Job, user.Job));

            // Creates the context of user authentication.
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = true
                });
        }
    }
}