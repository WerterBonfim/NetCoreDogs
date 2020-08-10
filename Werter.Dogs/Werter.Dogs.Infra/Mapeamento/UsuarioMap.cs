using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Infra.Mapeamento
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_Usuarios");

            builder.Property(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(30)
                .IsRequired(false);


            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NomeDeUsuario)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasMaxLength(90)
                .IsRequired();
            
            builder.Property(x => x.DataHoraAlteracao);

            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Fotos)
                .WithOne(x => x.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
