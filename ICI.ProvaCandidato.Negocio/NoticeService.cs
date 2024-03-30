using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio
{
    public class NoticeService : INoticeService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public NoticeService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<NoticeEntity> AddNotice(NoticeEntity noticeEntity)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var result = await _repositoryUoW.NoticeRepository.AddNoticeAsync(noticeEntity);

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

        public async Task<List<NoticeEntity>> GetAllNotices()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<NoticeEntity> notices = await _repositoryUoW.NoticeRepository.GetAllNoticesAsync();
                _repositoryUoW.Commit();
                return notices;
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

        public async Task<NoticeEntity> UpdateNotice(NoticeEntity noticeEntity)
        {
            NoticeEntity noticeById = _repositoryUoW.NoticeRepository.GetNoticeById(noticeEntity.Id);

            if (noticeById == null)
                throw new InvalidOperationException("Notice does not found!");

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                noticeById.Title = noticeEntity.Title;
                noticeById.Text = noticeEntity.Text;


                var result = _repositoryUoW.NoticeRepository.UpdateNotice(noticeById);
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