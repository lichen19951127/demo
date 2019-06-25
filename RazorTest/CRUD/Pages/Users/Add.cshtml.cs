using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Users
{
    public class AddModel : PageModel
    {
        private readonly EFDBContext _dbContext;
        [BindProperty]
        public CRUD.Data.Users Users { get; set; }
        public AddModel(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Users.Add(Users);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}