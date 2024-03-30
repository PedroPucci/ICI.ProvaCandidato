using AutoMapper;
using ICI.ProvaCandidato.Dados.Repository.Interfaces;

namespace ICI.ProvaCandidato.Negocio
{
    public class UserService
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

        //public async Task<GenericResult<UserEntity>> AddUser(UserDto userDto)
        //{
        //    throw
        //}
    }
}