
using System.Collections.Generic;
namespace Transportes.Domain.Entities
{
    public class Transportadora
    {
        public int TransportadoraId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro{get;set;}

        public virtual IEnumerable<Classificacao> Classificacoes { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
