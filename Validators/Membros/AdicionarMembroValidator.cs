using FluentValidation;
using ipcsmembros.Contexts;
using ipcsmembros.ViewModels.Membros;

namespace ipcsmembros.Validators.Membros
{
    public class AdicionarMembroValidator : AbstractValidator<AdicionarMembroViewModel>
    {
        public AdicionarMembroValidator(MembroContext context)
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Por favor, preencha o campo Nome.")
                                .MaximumLength(255).WithMessage("O nome deve ter até {MaxLenght} caracteres.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Por favor, preencha o campo Email.")
                                 .MaximumLength(255).WithMessage("O email deve ter até {MaxLenght} caracteres.")
                                 .Must(email => context.Membros.Any(m => m.Email == email)).WithMessage("Esse Email já está em uso.");
        }
    }
}
