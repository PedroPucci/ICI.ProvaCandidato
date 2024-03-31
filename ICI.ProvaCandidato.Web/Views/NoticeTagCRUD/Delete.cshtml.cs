using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Web.Views.NoticeTagCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ICI.ProvaCandidato.Dados.DataBaseContext _context;

        public DeleteModel(ICI.ProvaCandidato.Dados.DataBaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NoticeTagEntity NoticeTagEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoticeTagEntity = await _context.NoticeTagEntity.FirstOrDefaultAsync(m => m.Id == id);

            if (NoticeTagEntity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoticeTagEntity = await _context.NoticeTagEntity.FindAsync(id);

            if (NoticeTagEntity != null)
            {
                _context.NoticeTagEntity.Remove(NoticeTagEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
