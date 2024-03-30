using ICI.ProvaCandidato.Web.Models;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> AddUserAsync(UserModel userModel);
    }
}