using System;

namespace Werter.Dogs.Dominio.Dtos
{
    public class ComentarioDto
    {
        public Guid Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public DateTime DataHora { get; set; }
        public string Texto { get; set; }
    }
}