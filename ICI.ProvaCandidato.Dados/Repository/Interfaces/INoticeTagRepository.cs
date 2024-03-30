using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface INoticeTagRepository
    {
        Task<NoticeTagEntity> AddNoticeTagAsync(NoticeTagEntity noticeTagEntity);
        Task<List<NoticeTagEntity>> GetAllNoticeTagsAsync();
        NoticeTagEntity UpdateNoticeTag(NoticeTagEntity noticeTagEntity);
        NoticeTagEntity GetNoticeTagById(int id);
        Task<NoticeTagEntity> DeleteNoticeTagAsync(NoticeTagEntity noticeTagEntity);
    }
}