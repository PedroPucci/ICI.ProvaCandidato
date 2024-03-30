using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<NoticeEntity>> GetAllNoticesAsync()
        {
            return _context.NoticeEntity.OrderBy(notice => notice.Id).Select(notice => new NoticeEntity
            {
                Id = notice.Id,
                Text = notice.Text,
                Title = notice.Title,
                UserModel = notice.UserModel                
            }).ToList();
        }

        public NoticeEntity UpdateNotice(NoticeEntity noticeEntity)
        {
            var response = _context.NoticeEntity.Update(noticeEntity);
            return response.Entity;
        }

        public NoticeEntity GetNoticeById(int id)
        {
            return _context.NoticeEntity.FirstOrDefault(notice => notice.Id == id);
        }
    }
}