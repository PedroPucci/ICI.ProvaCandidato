using AutoMapper;
using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using ICI.ProvaCandidato.Web.Models.Dto;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio
{
    public class UserService : IUserService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public UserService(IRepositoryUoW repositoryUoW,IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
        }

        public UserService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<UserEntity> AddUser(UserModelDto userModelDto)
        {
            throw new System.NotImplementedException();
        }
    }
}