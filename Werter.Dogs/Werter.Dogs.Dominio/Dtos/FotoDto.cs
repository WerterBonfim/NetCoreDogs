using System;
using System.Collections.Generic;

namespace Werter.Dogs.Dominio.Dtos
{
    public class FotoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Peso { get; set; }
        public int QtdAcessos { get; set; }
        public List<ComentarioDto> Comentarios { get; set; }
        public string Extencao { get; set; }
        public string Src { get; set; }
        public string Autor { get; set; }
    }
}