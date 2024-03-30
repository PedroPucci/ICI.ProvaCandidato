using AutoMapper;
using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using ICI.ProvaCandidato.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio
{
    public class UserService : IUserService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public UserService(IRepositoryUoW repositoryUoW,IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
        }

        public async Task<UserEntity> AddUser(UserModelDto userDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var userEntity = _mapper.Map<UserModelDto, UserEntity>(userDto);
                var result = await _repositoryUoW.UserRepository.AddUserAsync(userEntity);

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

        public async Task<List<UserEntity>> GetAllUsers()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<UserEntity> userList = await _repositoryUoW.UserRepository.GetAllUsersAsync();
                _repositoryUoW.Commit();
                return userList;
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

        public async Task<UserEntity> UpdateUser(UserModelDto userModelDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var userName = userModelDto.Name;

                UserEntity userByName = await _repositoryUoW.UserRepository.GetUserByNameAsync(userName);

                if (userName == null)
                    throw new InvalidOperationException("User does not found!");

                userByName.Password = userModelDto.Password;

                var result = _repositoryUoW.UserRepository.UpdateUser(userByName);

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