using ipcsmembros.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace ipcsmembros.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
