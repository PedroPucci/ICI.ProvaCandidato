using ICI.ProvaCandidato.Web.Models;
using ICI.ProvaCandidato.Web.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUser(UserModelDto userModelDto);
        Task<UserEntity> UpdateUser(UserModelDto userModelDto);
        Task<List<UserEntity>> GetAllUsers();
    }
}