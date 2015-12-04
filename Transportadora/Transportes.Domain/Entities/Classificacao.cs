using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.Domain.Entities
{
    public class Classificacao
    {
        public int ClassificacaoId { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int TransportadoraId { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        public decimal preco { get; set; }
    }
}
