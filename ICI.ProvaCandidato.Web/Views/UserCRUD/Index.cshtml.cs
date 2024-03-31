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
    public class IndexModel : PageModel
    {
        private readonly ICI.ProvaCandidato.Dados.DataBaseContext _context;

        public IndexModel(ICI.ProvaCandidato.Dados.DataBaseContext context)
        {
            _context = context;
        }

        public IList<UserEntity> UserEntity { get;set; }

        public async Task OnGetAsync()
        {
            UserEntity = await _context.UserModel.ToListAsync();
        }
    }
}
