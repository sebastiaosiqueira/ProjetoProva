using AutoMapper;
using Transportes.Domain.Entities;
using Transportes.MVC.ViewModels;
namespace Transportes.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
           
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<TransportadoraViewModel, Transportadora>();
            Mapper.CreateMap<ClassificacaoViewModel, Classificacao>();
            
        }
    }
}