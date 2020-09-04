using System;

namespace Werter.Dogs.Dominio.Dtos
{
    public class EstatisticaDto
    {
        public Guid FotoId { get; set; }
        public string Nome { get; set; }
        public int QtdAcessos { get; set; }

        public EstatisticaDto(Guid fotoId, string nome, int qtdAcessos)
        {
            this.FotoId = fotoId;
            this.Nome = nome;
            this.QtdAcessos = qtdAcessos;
        }
    }
}