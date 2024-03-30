using ICI.ProvaCandidato.Web.Models;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity userModel);
    }
}