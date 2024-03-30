using ICI.ProvaCandidato.Web.Models;
using ICI.ProvaCandidato.Web.Models.Dto;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddUser(UserModelDto userModelDto);
    }
}