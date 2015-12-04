using Transportes.Application.Interface;
using Transportes.Domain.Entities;
using Transportes.Domain.Interfaces.Services;
namespace Transportes.Application.Service
{
    public class TransportadoraAppService:AppServiceBase<Transportadora>, ITransportadoraAppService
    {
        private readonly ITransportadoraService _transportadoraService;

        public TransportadoraAppService(ITransportadoraService transportadoraService)
            : base(transportadoraService)
        {
            _transportadoraService = transportadoraService;
        }
    }
}
