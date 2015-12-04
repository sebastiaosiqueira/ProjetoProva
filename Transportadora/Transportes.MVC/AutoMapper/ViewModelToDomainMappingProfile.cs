using AutoMapper;
using Transportes.Domain.Entities;
using Transportes.MVC.ViewModels;

namespace Transportes.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Transportadora, TransportadoraViewModel>();
            Mapper.CreateMap<Classificacao, ClassificacaoViewModel>();
            
        }
    }
}