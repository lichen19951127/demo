using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class AddModel : PageModel
    {
        public void OnGet()
        {

        }
        [TempData]
        public string Message { get; set; }


        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //todo create a new customer
            Message = $"Customer {Customer.Name} added";
            return RedirectToPage("./Index");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}