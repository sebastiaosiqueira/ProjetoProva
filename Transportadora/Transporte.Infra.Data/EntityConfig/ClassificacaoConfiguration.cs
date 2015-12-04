using Transportes.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
namespace Transporte.Infra.Data.EntityConfig
{
    public class ClassificacaoConfiguration: EntityTypeConfiguration<Classificacao>
    {
        public ClassificacaoConfiguration()
        {
            HasKey(c => c.ClassificacaoId);
            HasRequired(p => p.Usuario).WithMany().HasForeignKey(p => p.UsuarioId);
            HasRequired(p => p.Transportadora).WithMany().HasForeignKey(p => p.TransportadoraId);
            Property(p => p.preco).IsRequired();

        }
    }
}
