using System;

namespace Werter.Dogs.Dominio.Dtos
{
    public class ComentarioDto
    {
        public string NomeDeUsuario { get; set; }
        public Guid ComentarioId { get; set; }
        public DateTime DataHora { get; set; }
        public string Texto { get; set; }
    }
}