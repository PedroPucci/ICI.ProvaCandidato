using ICI.ProvaCandidato.Dados.Repository.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity userModel)
        {
            var result = await _context.UserModel.AddAsync(userModel);
            return result.Entity;
        }
    }
}