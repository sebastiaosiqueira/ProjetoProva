using Transportes.Domain.Entities;
using Transportes.Domain.Interfaces.Repositories;
using Transportes.Domain.Interfaces.Services;
namespace Transportes.Domain.Services
{
   public class TransportadoraService:ServiceBase<Transportadora>, ITransportadoraService
    {
       private readonly ITransportadoraRepository _transportadoraRepository;
       public TransportadoraService(ITransportadoraRepository transportadoraRepository)
           : base(transportadoraRepository)
       {
           _transportadoraRepository = transportadoraRepository;
       }
    }
}
