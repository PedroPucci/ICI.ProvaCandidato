using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface INoticeService
    {
        Task<NoticeEntity> AddNotice(NoticeEntity noticeEntity);
        Task<List<NoticeEntity>> GetAllNotices();
        Task<NoticeEntity> UpdateNotice(NoticeEntity noticeEntity);
        Task<NoticeEntity> DeleteNotice(int id);
    }
}