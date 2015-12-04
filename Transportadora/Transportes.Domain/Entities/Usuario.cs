﻿using System.Collections.Generic;
namespace Transportes.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }

        public virtual IEnumerable<Transportadora> Transportadoras { get; set; }

        public virtual IEnumerable<Classificacao> Classificacoes { get; set; }
    }
}
