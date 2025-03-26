using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Business.Models;

namespace Assignment_2.Pages.Category
{
    public class DetailsModel : PageModel
    {
        private readonly Business.Models.FunewsManagementContext _context;

        public DetailsModel(Business.Models.FunewsManagementContext context)
        {
            _context = context;
        }

        public Business.Models.Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
