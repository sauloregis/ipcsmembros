using FluentValidation;
using FluentValidation.AspNetCore;
using ipcsmembros.Contexts;
using ipcsmembros.Models.Entities;
using ipcsmembros.ViewModels.Membros;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ipcsmembros.Controllers
{
    public class MembrosController : Controller
    {
        private readonly MembroContext _context;

        private readonly IValidator<AdicionarMembroViewModel> _adicionarMembroValidator;
        private readonly IValidator<EditarMembroViewModel> _editarMembroValidator;

        private const int TAMANHO_PAGINA = 10;

        public MembrosController(MembroContext context, IValidator<AdicionarMembroViewModel> adicionarMembroValidator, IValidator<EditarMembroViewModel> editarMembroValidator)
        {
            _context = context;
            _adicionarMembroValidator = adicionarMembroValidator;
            _editarMembroValidator = editarMembroValidator;
        }

        public IActionResult Index(string filtro, int pagina = 1)
        {
            var membros = _context.Membros.Where(x => x.Nome.Contains(filtro) || x.Email.Contains(filtro))
                                          .Select(x => new ListarMembroViewModel
                                          {
                                              Id = x.Id,
                                              Nome = x.Nome,
                                              //TipoMembro = (EnumTipoMembro)x.TipoMembro,
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

            if (!validacao.IsValid)
            {
                validacao.AddToModelState(ModelState, string.Empty);
                return View(dados);
            }

            var membro = new Membro
            {
                Nome = dados.Nome,
                Ativo = true,
                Email = dados.Email,
                Celular = Regex.Replace(dados.Celular, "[^0-9]", ""),
                Sexo = dados.Sexo,
                TipoMembro = dados.TipoMembro,
                DataNascimento = dados.DataNascimento
            };

            _context.Membros.Add(membro);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var membro = _context.Membros.Find(id);

            if (membro != null)
            {
                return View(new EditarMembroViewModel
                {
                    Id = membro.Id,
                    Nome = membro.Nome,
                    Ativo = membro.Ativo,
                    Email = membro.Email,
                    Celular = !string.IsNullOrEmpty(membro.Celular) ? Regex.Replace(membro.Celular, "[^0-9]", "") : "",
                    Sexo = membro.Sexo,
                    TipoMembro = membro.TipoMembro,
                    DataNascimento = membro.DataNascimento
                });
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, EditarMembroViewModel dados)
        {
            var validacao = _editarMembroValidator.Validate(dados);

            if (!validacao.IsValid)
            {
                validacao.AddToModelState(ModelState, string.Empty);
                return View(dados);
            }

            var membro = _context.Membros.Find(id);

            if (membro != null)
            {
                membro.Nome = dados.Nome;
                membro.Ativo = dados.Ativo;
                membro.Email = dados.Email;
                membro.Celular = !string.IsNullOrEmpty(dados.Celular) ? Regex.Replace(dados.Celular, "[^0-9]", "") : "";
                membro.Sexo = dados.Sexo;
                membro.TipoMembro = dados.TipoMembro;
                membro.DataNascimento = dados.DataNascimento;
                _context.Membros.Update(membro);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var membro = _context.Membros.Find(id);

            if (membro != null)
            {
                return View(new ListarMembroViewModel
                {
                    Id = membro.Id,
                    Nome = membro.Nome,
                    Email = membro.Email
                });
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id)
        {
            var membro = _context.Membros.Find(id);

            if (membro != null)
            {
                _context.Membros.Remove(membro);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
