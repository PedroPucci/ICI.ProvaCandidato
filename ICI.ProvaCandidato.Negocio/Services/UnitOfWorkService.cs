using AutoMapper;
using ICI.ProvaCandidato.Dados.Repository.Interfaces;

namespace ICI.ProvaCandidato.Negocio.Services
{
    class UnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private UserService? userService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW, IMapper mapper, IConfiguration config)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _config = config;
        }

        public UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(_repositoryUoW, _mapper);
                }
                return userService;
            }
        }
    }
}