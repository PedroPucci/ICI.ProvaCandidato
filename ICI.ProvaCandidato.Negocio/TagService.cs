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

        public Task<TagEntity> UpdateTag(TagEntity tagEntity)
        {
            throw new NotImplementedException();
        }

        //public async Task<TagEntity> UpdateTag(TagEntity tagEntity)
        //{
        //    using var transaction = _repositoryUoW.BeginTransaction();
        //    try
        //    {   
        //        int id = tagEntity.Id;
        //        string description = tagEntity.Description;

        //        TagEntity newTagEntity = await _repositoryUoW.TagRepository.GetTagByIdAsync(description);

        //        if (newTagEntity == null)
        //            throw new InvalidOperationException("Collaborator does not found!");

        //        newTagEntity.Description = tagEntity.Description;

        //        var result = _repositoryUoW.TagRepository.UpdateTag(newTagEntity);

        //        await _repositoryUoW.SaveAsync();
        //        await transaction.CommitAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        throw new InvalidOperationException("Unexpected error " + ex + "!");
        //    }
        //    finally
        //    {
        //        transaction.Dispose();
        //    }
        //}        
    }
}