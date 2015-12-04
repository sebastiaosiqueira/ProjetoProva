using Transportes.Domain.Entities;
using Transportes.Domain.Interfaces.Repositories;
using Transportes.Domain.Interfaces.Services;
namespace Transportes.Domain.Services
{
    public class ClassificacaoService:ServiceBase<Classificacao>, IClassificacaoService
    {
        private readonly IClassificacaoRepository _classificacaoRepository;
        public ClassificacaoService(IClassificacaoRepository classificacaoRepository)
            : base(classificacaoRepository)
        {
            _classificacaoRepository = classificacaoRepository;
        }
    }
}
