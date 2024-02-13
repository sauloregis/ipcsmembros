using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ipcsmembros.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = "/")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl = "/")
        {
            // Lógica de autenticação aqui
            if (username == "usuario" && password == "senha")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return LocalRedirect(returnUrl);
            }

            ViewBag.ErrorMessage = "Credenciais inválidas";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
