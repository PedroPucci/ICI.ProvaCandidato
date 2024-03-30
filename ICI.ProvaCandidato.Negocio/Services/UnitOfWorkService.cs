using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private UserService userService;
        private TagService tagService;
        private NoticeService noticeService;
        private NoticeTagService noticeTagService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(_repositoryUoW);
                }
                return userService;
            }
        }

        public TagService TagService
        {
            get
            {
                if (tagService == null)
                {
                    tagService = new TagService(_repositoryUoW);
                }
                return tagService;
            }
        }

        public NoticeService NoticeService
        {
            get
            {
                if (noticeService == null)
                {
                    noticeService = new NoticeService(_repositoryUoW);
                }
                return noticeService;
            }
        }

        public NoticeTagService NoticeTagService
        {
            get
            {
                if (noticeTagService == null)
                {
                    noticeTagService = new NoticeTagService(_repositoryUoW);
                }
                return noticeTagService;
            }
        }
    }
}