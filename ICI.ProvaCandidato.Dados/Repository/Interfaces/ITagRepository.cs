﻿using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<TagEntity> AddTagAsync(TagEntity tagEntity);
        TagEntity UpdateTag(TagEntity tagEntity);
        Task<List<TagEntity>> GetAllTagsAsync();
        TagEntity GetTagByDescription(string description);
        TagEntity GetTagById(int id);
        Task<TagEntity> DeleteTagAsync(TagEntity tagByDescription);
    }
}