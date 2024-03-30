using ICI.ProvaCandidato.Web.Models;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface INoticeService
    {
        Task<NoticeEntity> AddNotice(NoticeEntity noticeEntity);
    }
}