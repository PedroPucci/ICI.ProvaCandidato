using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface IRepositoryUoW
    {
        IUserRepository UserRepository { get; }
        ITagRepository TagRepository { get; }
        INoticeRepository NoticeRepository { get; }
        INoticeTagRepository NoticeTagRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}