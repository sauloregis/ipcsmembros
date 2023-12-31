using ipcsmembros.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ipcsmembros.Models.EntityConfigurations
{
    public class MembroConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("Membros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ativo)
                   .IsRequired();

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(255);
            
            builder.Property(x => x.Email)
                   .HasMaxLength(255);

            builder.Property(x => x.Celular)
                   .HasMaxLength(11);

            builder.Property(x => x.Sexo)
                   .HasMaxLength(1);

            builder.Property(x => x.TipoMembro)
                   .IsRequired();

            builder.Property(x => x.DataNascimento);
        }
    }
}