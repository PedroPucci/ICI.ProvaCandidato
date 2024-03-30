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
                List<TagEntity> tags = await _repositoryUoW.TagRepository.GetAllTagsAsync();
                _repositoryUoW.Commit();
                return tags;
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

        public TagEntity GetTagByDescription(string description)
        {
            if (String.IsNullOrEmpty(description))
                throw new InvalidOperationException("Description is null or Empty!");

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                TagEntity tagEntity = _repositoryUoW.TagRepository.GetTagByDescription(description);
                _repositoryUoW.Commit();
                return tagEntity;
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

        public async Task<TagEntity> DeleteTag(int id)
        {
            TagEntity tagByDescription = _repositoryUoW.TagRepository.GetTagById(id);

            if (tagByDescription == null)
                throw new InvalidOperationException("Tag does not found!");

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var result = await _repositoryUoW.TagRepository.DeleteTagAsync(tagByDescription);
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

        public async Task<TagEntity> UpdateTag(TagEntity tagEntity)
        {
            TagEntity tagByDescription = _repositoryUoW.TagRepository.GetTagById(tagEntity.Id);

            if (tagByDescription == null)
                throw new InvalidOperationException("Tag does not found!");

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                tagByDescription.Description = tagEntity.Description;
                var result = _repositoryUoW.TagRepository.UpdateTag(tagByDescription);
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
    }
}