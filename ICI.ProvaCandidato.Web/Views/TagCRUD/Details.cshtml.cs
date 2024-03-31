using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Web.Views.TagCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly ICI.ProvaCandidato.Dados.DataBaseContext _context;

        public DetailsModel(ICI.ProvaCandidato.Dados.DataBaseContext context)
        {
            _context = context;
        }

        public TagEntity TagEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TagEntity = await _context.TagEntity.FirstOrDefaultAsync(m => m.Id == id);

            if (TagEntity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
