using Transportes.Application.Interface;
using Transportes.Domain.Entities;
using Transportes.Domain.Interfaces.Services;
namespace Transportes.Application.Service
{
   public  class UsuarioAppService:AppServiceBase<Usuario>, IUsuarioAppService
    {
       private readonly IUsuarioService _usuarioService;

       public UsuarioAppService(IUsuarioService usuarioService)
           : base(usuarioService)
       {
           _usuarioService = usuarioService;
       }
    }
}
