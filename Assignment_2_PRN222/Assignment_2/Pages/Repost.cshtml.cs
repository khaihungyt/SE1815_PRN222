using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Pages
{
    public class RepostModel : PageModel
    {
        private readonly Business.Models.FunewsManagementContext _context;

        public RepostModel(Business.Models.FunewsManagementContext context)
        {
            _context = context;
        }

        public List<NewsArticle> NewsArticles { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Fetch news articles with optional filtering and sorting
            var query = _context.NewsArticles.Include(n => n.Category)  // Include related Category
                .AsQueryable();

            if (StartDate.HasValue)
            {
                query = query.Where(n => n.CreatedDate >= StartDate);
            }

            if (EndDate.HasValue)
            {
                query = query.Where(n => n.CreatedDate <= EndDate);
            }

            NewsArticles = await query
                .OrderByDescending(n => n.CreatedDate) // Sort by descending CreatedDate
                .ToListAsync();

            return Page();
        }
    }
}
