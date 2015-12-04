using Transportes.Domain.Entities;
using Transportes.Domain.Interfaces.Repositories;
using Transportes.Domain.Interfaces.Services;
namespace Transportes.Domain.Services
{
   public class UsuarioService:ServiceBase<Usuario>, IUsuarioService
    {
       private readonly IUsuarioRepository _usuarioRepository;

       public UsuarioService(IUsuarioRepository usuarioRepository):base(usuarioRepository)
       {
           _usuarioRepository = usuarioRepository;

       }
    }
}
