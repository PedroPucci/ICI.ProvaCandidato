using AutoMapper;
using ICI.ProvaCandidato.Web.Models;
using ICI.ProvaCandidato.Web.Models.Dto;

namespace ICI.ProvaCandidato.Dados
{
    class Mappers : Profile
    {
        public Mappers() { }

        public MapperConfiguration Configuration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserModelDto>();
                cfg.CreateMap<UserModelDto, UserModel>();
            });
        }
    }
}