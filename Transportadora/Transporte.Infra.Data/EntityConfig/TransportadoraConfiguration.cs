using System.Data.Entity.ModelConfiguration;
using Transportes.Domain.Entities;

namespace Transporte.Infra.Data.EntityConfig
{
    public class TransportadoraConfiguration: EntityTypeConfiguration<Transportadora>
    {
        public TransportadoraConfiguration()
        {
            HasKey(c => c.TransportadoraId);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);
            Property(c=> c.CNPJ).IsRequired().HasMaxLength(20);
            Property(c=> c.IE).IsRequired().HasMaxLength(14);
            Property(c => c.Email).IsRequired().HasMaxLength(150);
            Property(c=> c.Cep).HasMaxLength(10);
            Property(c=> c.UF).IsRequired().HasMaxLength(2);
            Property(c=> c.Cidade).IsRequired().HasMaxLength(150);
            Property(c=> c.Endereco).IsRequired().HasMaxLength(150);
            Property(c=> c.Numero).IsRequired().HasMaxLength(10);
            Property(c => c.Bairro).IsRequired().HasMaxLength(50);
        }
    }
}
