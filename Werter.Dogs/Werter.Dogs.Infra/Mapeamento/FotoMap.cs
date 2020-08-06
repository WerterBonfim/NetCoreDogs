using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Infra.Mapeamento
{
    public class FotoMap : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("TB_Fotos");

            builder.Property(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(30)
                .IsRequired();


            builder.Property(x => x.Nome)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Idade)                
                .IsRequired();

            builder.Property(x => x.Peso)                
                .IsRequired();

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Fotos)
                .IsRequired();
            
        }
    }
}
