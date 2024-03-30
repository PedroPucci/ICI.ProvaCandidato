using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface INoticeRepository
    {
        Task<NoticeEntity> AddNoticeAsync(NoticeEntity noticeEntity);
        Task<List<NoticeEntity>> GetAllNoticesAsync();
        NoticeEntity UpdateNotice(NoticeEntity noticeEntity);
        NoticeEntity GetNoticeById(int id);
        Task<NoticeEntity> DeleteNoticeAsync(NoticeEntity noticeToDelete);
    }
}