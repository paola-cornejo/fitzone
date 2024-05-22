using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Login.Oauth;
using Login.Oauth.Areas.Socio.Data;

namespace Login.Oauth.Areas.Socios.Pages
{
    public class CrearModel : PageModel
    {
        private readonly Login.Oauth.ContextoBaseDatos _context;

        public CrearModel(Login.Oauth.ContextoBaseDatos context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Login.Oauth.Areas.Socio.Data.Socio Socio { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.socio.Add(Socio);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
