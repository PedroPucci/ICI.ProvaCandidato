using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface INoticeTagService
    {
        Task<NoticeTagEntity> AddNoticeTag(NoticeTagEntity noticeTagEntity);
        Task<List<NoticeTagEntity>> GetAllNoticeTags();
        Task<NoticeTagEntity> UpdateNoticeTag(NoticeTagEntity noticeTagEntity);
        Task<NoticeTagEntity> DeleteNoticeTag(int id);
    }
}