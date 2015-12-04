
using System.Data.Entity.ModelConfiguration;
using Transportes.Domain.Entities;
namespace Transporte.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration: EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.UsuarioId);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            Property(c => c.Email).IsRequired().HasMaxLength(150);

            Property(c => c.CPF).IsRequired().HasMaxLength(11);

            Property(c => c.Endereco).IsRequired().HasMaxLength(150);

            Property(c => c.Numero).HasMaxLength(10);

            Property(c => c.Bairro).IsRequired().HasMaxLength(50);

            Property(c => c.UF).IsRequired().HasMaxLength(2);

            Property(c => c.Cidade).IsRequired().HasMaxLength(150);
        }
    }
}
