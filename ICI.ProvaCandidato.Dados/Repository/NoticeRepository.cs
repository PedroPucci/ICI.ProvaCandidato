using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository
{
    public class NoticeRepository : INoticeRepository
    {
        private readonly DataBaseContext _context;

        public NoticeRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<NoticeEntity> AddNoticeAsync(NoticeEntity noticeEntity)
        {
            var result = await _context.NoticeEntity.AddAsync(noticeEntity);
            return result.Entity;
        }
    }
}