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
    public class IndexModel : PageModel
    {
        private readonly EFDBContext _dbContext;
        public List<CRUD.Data.Users> Users { get; set; }
        public IndexModel(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            Users = await _dbContext.Users.ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var category = await _dbContext.Users.FindAsync(id);

            if (category != null)
            {
                _dbContext.Users.Remove(category);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}