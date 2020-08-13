using System;
using System.Collections.Generic;

namespace Werter.Dogs.Dominio.Dtos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string NomeDeUsuario { get; set; }
        public List<FotoDto> Fotos { get; set; }
        
    }
}