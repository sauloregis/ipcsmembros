using FluentValidation;
using ipcsmembros.Contexts;
using ipcsmembros.ViewModels.Membros;

namespace ipcsmembros.Validators.Membros
{
    public class EditarMembroValidator : AbstractValidator<EditarMembroViewModel>
    {
        public EditarMembroValidator(MembroContext context)
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Por favor, preencha o campo Nome.")
                                .MaximumLength(255).WithMessage("O nome deve ter até {MaxLenght} caracteres.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Por favor, preencha o campo Email.")
                                 .MaximumLength(255).WithMessage("O email deve ter até {MaxLenght} caracteres.");
            
            RuleFor(x => x).Must(x => !context.Membros.Any(m => m.Email == x.Email && m.Id != x.Id)).WithMessage("Esse Email já está sendo usado.");
        }
    }
}
