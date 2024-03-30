using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository
{
    public class NoticeTagRepository : INoticeTagRepository
    {
        private readonly DataBaseContext _context;

        public NoticeTagRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<NoticeTagEntity> AddNoticeTagAsync(NoticeTagEntity noticeTagEntity)
        {
            var result = await _context.NoticeTagEntity.AddAsync(noticeTagEntity);
            return result.Entity;
        }

        public async Task<List<NoticeTagEntity>> GetAllNoticeTagsAsync()
        {
            return _context.NoticeTagEntity.OrderBy(notice => notice.Id).Select(notice => new NoticeTagEntity
            {
                Id = notice.Id,
                NoticeModel = notice.NoticeModel,
                TagEntity = notice.TagEntity
            }).ToList();
        }

        public NoticeTagEntity UpdateNoticeTag(NoticeTagEntity noticeTagEntity)
        {
            var response = _context.NoticeTagEntity.Update(noticeTagEntity);
            return response.Entity;
        }

        public NoticeTagEntity GetNoticeTagById(int id)
        {
            return _context.NoticeTagEntity.FirstOrDefault(notice => notice.Id == id);
        }

        public async Task<NoticeTagEntity> DeleteNoticeTagAsync(NoticeTagEntity noticeTagEntity)
        {
            if (noticeTagEntity != null)
            {
                _context.NoticeTagEntity.Remove(noticeTagEntity);
                await _context.SaveChangesAsync();
            }

            return noticeTagEntity;
        }
    }
}