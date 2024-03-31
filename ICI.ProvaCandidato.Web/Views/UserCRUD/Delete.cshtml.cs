using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Web.Views.NoticeCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ICI.ProvaCandidato.Dados.DataBaseContext _context;

        public DeleteModel(ICI.ProvaCandidato.Dados.DataBaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserEntity UserEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserEntity = await _context.UserModel.FirstOrDefaultAsync(m => m.Id == id);

            if (UserEntity == null)
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

            UserEntity = await _context.UserModel.FindAsync(id);

            if (UserEntity != null)
            {
                _context.UserModel.Remove(UserEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
