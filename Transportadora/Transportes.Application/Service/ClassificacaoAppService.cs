using Transportes.Application.Interface;
using Transportes.Domain.Entities;
using Transportes.Domain.Interfaces.Services;
namespace Transportes.Application.Service
{
    public class ClassificacaoAppService:AppServiceBase<Classificacao>, IClassificacaoAppService
    {
        private readonly IClassificacaoService _classificacaoService;
        public ClassificacaoAppService(IClassificacaoService classificacaoService)
            : base(classificacaoService)
        {
            _classificacaoService = classificacaoService;
        }
    }
}
