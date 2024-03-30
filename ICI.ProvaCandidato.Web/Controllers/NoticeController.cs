using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    [ApiController]
    [Route("api/v1/notice")]
    public class NoticeController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public NoticeController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNotice([FromBody] NoticeEntity noticeEntity)
        {
            var result = await _serviceUoW.NoticeService.AddNotice(noticeEntity);
            return Ok(result);
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoticeEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllNotices()
        {
            try
            {
                var tagEntities = await _serviceUoW.NoticeService.GetAllNotices();
                return Ok(tagEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading notices! " + ex + ""
                });
            }
        }
    }
}