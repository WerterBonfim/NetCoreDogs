using System;
using System.Collections.Generic;
using System.Text;

namespace Werter.Dogs.Domain.Entities
{
    public class Usuario 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
