using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
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

        public Task<TagEntity> AddTagAsync(TagEntity tagEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TagEntity>> GetAllTagsAsync()
        {
            throw new System.NotImplementedException();
        }

        public TagEntity UpdateTag(TagEntity tagEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}