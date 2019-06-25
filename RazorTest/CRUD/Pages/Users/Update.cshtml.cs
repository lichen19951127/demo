using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly EFDBContext _dbContext;
        [BindProperty]
        public CRUD.Data.Users Users { get; set; }
        public UpdateModel(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Users = await _dbContext.Users.FindAsync(id);

            if (Users == null)
            {
                return RedirectToPage("Users");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Attach(Users).State =EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}