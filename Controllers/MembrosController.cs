using ipcsmembros.Contexts;
using ipcsmembros.ViewModels.Membros;
using Microsoft.AspNetCore.Mvc;
using ipcsmembros.Models.Entities;
using FluentValidation;
using ipcsmembros.Validators.Membros;
using FluentValidation.AspNetCore;
using System.ComponentModel.DataAnnotations;

namespace ipcsmembros.Controllers
{
    public class MembrosController : Controller
    {
        private readonly MembroContext _context;

        private readonly IValidator<AdicionarMembroViewModel> _adicionarMembroValidator;

        private const int TAMANHO_PAGINA = 10;

        public MembrosController(MembroContext context, IValidator<AdicionarMembroViewModel> adicionarMembroValidator)
        {
            _context = context;
            _adicionarMembroValidator = adicionarMembroValidator;
        }

        public IActionResult Index(string filtro, int pagina = 1)
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
            ViewBag.NumeroPagina = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((decimal)membros.Count() / TAMANHO_PAGINA);
            return View(membros.Skip((pagina - 1) * TAMANHO_PAGINA).Take(TAMANHO_PAGINA));
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(AdicionarMembroViewModel dados)
        {
            var validacao = _adicionarMembroValidator.Validate(dados);

            if(!validacao.IsValid) 
            {
                validacao.AddToModelState(ModelState, string.Empty);
                return View(dados);
            }

            var membro = new Membro
            {
                Nome = dados.Nome,
                Email = dados.Email
            };

            _context.Membros.Add(membro);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id) 
        {
            var membro = _context.Membros.Find(id);

            if(membro != null)
            {
                return View(new EditarMembroViewModel
                {
                    Id = membro.Id,
                    Nome = membro.Nome,
                    Email = membro.Email
                });
                
            }

            return NotFound();
        }
    }
}
