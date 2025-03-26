using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Business.Models;

namespace Assignment_2.Pages
{
    public class ViewHistoryModel : PageModel
    {
        private readonly Business.Models.FunewsManagementContext _context;

        public ViewHistoryModel(Business.Models.FunewsManagementContext context)
        {
            _context = context;
        }

        public IList<NewsArticle> NewsArticle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var updatedById = HttpContext.Session.GetInt32("UserId");
            NewsArticle = await _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.CreatedBy).Where(n => n.CreatedById== updatedById).ToListAsync();
        }
    }
}
