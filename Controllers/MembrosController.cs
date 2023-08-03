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

        public IActionResult Index()
        {
            var membros = _context.Membros.Select(x => new ListarMembroViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                DataNascimento = x.DataNascimento
            });

            return View(membros);
        }
    }
}
