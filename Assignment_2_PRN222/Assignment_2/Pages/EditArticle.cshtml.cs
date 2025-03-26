using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SignalR;

namespace Assignment_2.Pages
{
    public class EditArticleModel : PageModel
    {
        private readonly Business.Models.FunewsManagementContext _context;
        private readonly IHubContext<ArticleHub> _hubContext;
        public EditArticleModel(Business.Models.FunewsManagementContext context, IHubContext<ArticleHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsarticle =  await _context.NewsArticles.FirstOrDefaultAsync(m => m.NewsArticleId == id);
            if (newsarticle == null)
            {
                return NotFound();
            }
            NewsArticle = newsarticle;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryDesciption");
           ViewData["CreatedById"] = new SelectList(_context.SystemAccounts, "AccountId", "AccountId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Lấy UpdatedById từ session
            var updatedById = HttpContext.Session.GetInt32("UserId");

            if (updatedById.HasValue)
            {
                NewsArticle.UpdatedById = (short)updatedById.Value;
            }
            _context.Attach(NewsArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsArticleExists(NewsArticle.NewsArticleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate");

            return RedirectToPage("/ManageArticles");
        }

        private bool NewsArticleExists(string id)
        {
            return _context.NewsArticles.Any(e => e.NewsArticleId == id);
        }
    }
}
