using ICI.ProvaCandidato.Web.Models;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface INoticeRepository
    {
        Task<NoticeEntity> AddNoticeAsync(NoticeEntity noticeEntity);
    }
}