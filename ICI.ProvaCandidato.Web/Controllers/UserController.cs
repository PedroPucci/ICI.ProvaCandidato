using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public UserController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserModelDto userDto)
        {   
            var result = await _serviceUoW.UserService.AddUser(userDto);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateUser([FromBody] UserModelDto userModelDto)
        {
            try
            {
                //UserEntity? userEntity = await _serviceUoW.UserService.UpdateUser(userDto);
                return Ok(new
                {
                    mensagem = $"User registration updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "An error occurred while updating the user! " + ex + ""
                });
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserModelDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                //var userEntities = await _serviceUoW.UserService.GetAllUsers();
                //return Ok(userEntities);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading users! " + ex + ""
                });
            }
        }
    }
}