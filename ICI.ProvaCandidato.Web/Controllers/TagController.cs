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
    [Route("api/v1/tag")]
    public class TagController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public TagController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTag([FromBody] TagEntity tagEntity)
        {
            var result = await _serviceUoW.TagService.AddTag(tagEntity);
            return Ok(result);
        }

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        //public async Task<IActionResult> UpdateTag([FromBody] TagEntity tagEntity)
        //{
        //    try
        //    {
        //        TagEntity newTagEntity = await _serviceUoW.TagService.UpdateTag(tagEntity);
        //        return Ok(new
        //        {
        //            mensagem = $"Tag registration updated successfully."
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            mensagem = "An error occurred while updating the tag! " + ex + ""
        //        });
        //    }
        //}

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TagEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var tagEntities = await _serviceUoW.TagService.GetAllTags();
                return Ok(tagEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading tags! " + ex + ""
                });
            }
        }

        [HttpGet("SearchByDescription")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TagEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTagByDescription(string description)
        {
            try
            {
                var tagEntities = _serviceUoW.TagService.GetTagByDescription(description);
                return Ok(tagEntities);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading tags! " + ex + ""
                });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteTag(int id)
        {
            try
            {
                TagEntity tagEntity = await _serviceUoW.TagService.DeleteTag(id);
                return Ok(new
                {
                    mensagem = $"Tag deleted completed successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error deleting the Tag! " + ex + ""
                });
            }
        }
    }
}