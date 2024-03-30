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
    [Route("api/v1/noticeTag")]
    public class NoticeTagController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public NoticeTagController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNoticeTag([FromBody] NoticeTagEntity noticeTagEntity)
        {
            var result = await _serviceUoW.NoticeTagService.AddNoticeTag(noticeTagEntity);
            return Ok(result);
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoticeTagEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllNoticeTags()
        {
            try
            {
                var noticeTagEntities = await _serviceUoW.NoticeTagService.GetAllNoticeTags();
                return Ok(noticeTagEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading notices tags! " + ex + ""
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateNoticeTag([FromBody] NoticeTagEntity noticeTagEntity)
        {
            try
            {
                NoticeTagEntity newNoticeTagEntity = await _serviceUoW.NoticeTagService.UpdateNoticeTag(noticeTagEntity);
                return Ok(new
                {
                    mensagem = $"Notice tag registration updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "An error occurred while updating the Notice tag! " + ex + ""
                });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteNoticeTag(int id)
        {
            try
            {
                NoticeTagEntity noticeTagEntity = await _serviceUoW.NoticeTagService.DeleteNoticeTag(id);
                return Ok(new
                {
                    mensagem = $"Notice tag deleted completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error deleting the Notice tag! " + ex + ""
                });
            }
        }
    }
}