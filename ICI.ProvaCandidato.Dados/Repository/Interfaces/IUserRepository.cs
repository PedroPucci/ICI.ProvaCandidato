using ICI.ProvaCandidato.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity userModel);
        UserEntity UpdateUser(UserEntity userEntity);
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> GetUserByNameAsync(string name);
    }
}