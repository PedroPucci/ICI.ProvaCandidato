using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Web.Views.NoticeCRED
{
    public class DetailsModel : PageModel
    {
        private readonly ICI.ProvaCandidato.Dados.DataBaseContext _context;

        public DetailsModel(ICI.ProvaCandidato.Dados.DataBaseContext context)
        {
            _context = context;
        }

        public NoticeEntity NoticeEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoticeEntity = await _context.NoticeEntity.FirstOrDefaultAsync(m => m.Id == id);

            if (NoticeEntity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
