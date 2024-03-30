using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public UserController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddUserEntity([FromBody] UserModelDto userDto)
        {   
            var result = await _serviceUoW.UserService.AddUser(userDto);
            return Ok(result);
        }
    }
}