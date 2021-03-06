using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Infra.Mapeamento
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("TB_Comentarios");

            builder.Property(x => x.Id);

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.FotoId)
                .IsRequired();

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Foto)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.FotoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Usuario);
        }
    }
}