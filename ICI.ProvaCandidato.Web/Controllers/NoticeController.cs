using ICI.ProvaCandidato.Negocio.Services.Interfaces;
using ICI.ProvaCandidato.Web.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}