using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly DataBaseContext _context;

        public TagRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<TagEntity> AddTagAsync(TagEntity tagEntity)
        {
            var result = await _context.TagEntity.AddAsync(tagEntity);
            return result.Entity;
        }

        public async Task<List<TagEntity>> GetAllTagsAsync()
        {
            return _context.TagEntity.OrderBy(tag => tag.Description).Select(tag => new TagEntity
            {
                Id = tag.Id,
                Description = tag.Description
            }).ToList();
        }

        public TagEntity UpdateTag(TagEntity tagEntity)
        {
            var response = _context.TagEntity.Update(tagEntity);
            return response.Entity;
        }

        public TagEntity GetTagById(int id)
        {
            return _context.TagEntity.FirstOrDefault(tag => tag.Id == id);
        }

        public async Task<TagEntity> DeleteTagAsync(TagEntity tagToDelete)
        {
            if (tagToDelete != null)
            {
                _context.TagEntity.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }

            return tagToDelete;
        }
    }
}