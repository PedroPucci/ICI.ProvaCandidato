using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio
{
    public class TagService : ITagService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public TagService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<TagEntity> AddTag(TagEntity tagEntity)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var result = await _repositoryUoW.TagRepository.AddTagAsync(tagEntity);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<List<TagEntity>> GetAllTags()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<TagEntity> tagEntities = await _repositoryUoW.TagRepository.GetAllTagsAsync();
                _repositoryUoW.Commit();
                return tagEntities;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public Task<TagEntity> UpdateTag(TagEntity tagEntity)
        {
            throw new NotImplementedException();
        }        
    }
}