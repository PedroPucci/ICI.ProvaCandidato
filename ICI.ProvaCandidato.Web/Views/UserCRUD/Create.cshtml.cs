using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Web.Views.NoticeCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ICI.ProvaCandidato.Dados.DataBaseContext _context;

        public CreateModel(ICI.ProvaCandidato.Dados.DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserEntity UserEntity { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserModel.Add(UserEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
