using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface ITagService
    {
        Task<TagEntity> AddTag(TagEntity tagEntity);
        Task<TagEntity> UpdateTag(TagEntity tagEntity);
        Task<List<TagEntity>> GetAllTags();
        Task<TagEntity> DeleteTag(int id);
    }
}