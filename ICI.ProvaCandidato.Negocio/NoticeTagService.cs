using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class NoticeTagService : INoticeTagService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public NoticeTagService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<NoticeTagEntity> AddNoticeTag(NoticeTagEntity noticeTagEntity)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var result = await _repositoryUoW.NoticeTagRepository.AddNoticeTagAsync(noticeTagEntity);

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

        public async Task<List<NoticeTagEntity>> GetAllNoticeTags()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<NoticeTagEntity> noticeTags = await _repositoryUoW.NoticeTagRepository.GetAllNoticeTagsAsync();
                _repositoryUoW.Commit();
                return noticeTags;
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

        public async Task<NoticeTagEntity> DeleteNoticeTag(int id)
        {
            NoticeTagEntity noticeTagById = _repositoryUoW.NoticeTagRepository.GetNoticeTagById(id);

            if (noticeTagById == null)
                throw new InvalidOperationException("Notice tag does not found!");

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var result = await _repositoryUoW.NoticeTagRepository.DeleteNoticeTagAsync(noticeTagById);
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

        public async Task<NoticeTagEntity> UpdateNoticeTag(NoticeTagEntity noticeTagEntity)
        {
            NoticeTagEntity noticeTagById = _repositoryUoW.NoticeTagRepository.GetNoticeTagById(noticeTagEntity.Id);

            if (noticeTagById == null)
                throw new InvalidOperationException("Notice does not found!");

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                noticeTagById.NoticeModel = noticeTagEntity.NoticeModel;
                noticeTagById.TagEntity = noticeTagEntity.TagEntity;


                var result = _repositoryUoW.NoticeTagRepository.UpdateNoticeTag(noticeTagById);
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