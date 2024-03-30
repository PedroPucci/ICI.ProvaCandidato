using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUser(UserEntity userEntity);
        Task<UserEntity> UpdateUser(UserEntity userEntity);
        Task<List<UserEntity>> GetAllUsers();
    }
}