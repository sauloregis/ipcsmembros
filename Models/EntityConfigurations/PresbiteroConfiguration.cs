using ipcsmembros.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ipcsmembros.Models.EntityConfigurations
{
    public class PresbiteroConfiguration : IEntityTypeConfiguration<Presbitero>
    {
        public void Configure(EntityTypeBuilder<Presbitero> builder)
        {
            builder.ToTable("Presbiteros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Email)
                       .HasMaxLength(255);

            builder.Property(x => x.CPF)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.HasIndex(x => x.CPF)
                    .IsUnique();

            builder.Property(x => x.DataNascimento)
                    .IsRequired();
        }
    }
}
