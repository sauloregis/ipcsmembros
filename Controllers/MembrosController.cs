using ipcsmembros.Contexts;
using ipcsmembros.ViewModels.Membros;
using Microsoft.AspNetCore.Mvc;
using ipcsmembros.ViewModels.Membros;

namespace ipcsmembros.Controllers
{
    public class MembrosController : Controller
    {
        private readonly MembroContext _context;

        public MembrosController(MembroContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filtro)
        {
            var membros = _context.Membros.Where(x => x.Nome.Contains(filtro) || x.Email.Contains(filtro))
                                          .Select(x => new ListarMembroViewModel
                                          {
                                              Id = x.Id,
                                              Nome = x.Nome,
                                              Email = x.Email,
                                              DataNascimento = x.DataNascimento
                                          });
            ViewBag.Filtro = filtro;
            return View(membros);
        }
    }
}
