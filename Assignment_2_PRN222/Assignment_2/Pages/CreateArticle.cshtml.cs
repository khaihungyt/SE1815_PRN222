using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using Repositories.Repository;
using System.Linq;

namespace Assignment_2.Pages
{
    public class CreateArticleModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;
        private readonly FunewsManagementContext _context;
        private readonly IHubContext<ArticleHub> _hubContext;
        public CreateArticleModel(IStaffRepository staffRepository, FunewsManagementContext context, IHubContext<ArticleHub> hubContext)
        {
            _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; }

        [BindProperty]
        public List<int> SelectedTags { get; set; } = new List<int>();

        [BindProperty]
        public bool IsNewsActive { get; set; }

        public List<Tag> TagList { get; set; }

        public List<Business.Models.Category> CategoryList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["Title"] = "Create News Article";
            NewsArticle = new NewsArticle();

            CategoryList = await _staffRepository.GetAllCategory();
            TagList = await _staffRepository.GetAllTag();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var newId = _context.NewsArticles
                      .Select(n => n.NewsArticleId) 
                      .Max();
            if(newId == null)
            {
                newId = "0";
            }
            NewsArticle.NewsArticleId = (Int32.Parse(newId) + 1).ToString();
            NewsArticle.CreatedDate = DateTime.Now;
            NewsArticle.Category= _context.Categories.FirstOrDefault(n => n.CategoryId == NewsArticle.CategoryId);
            NewsArticle.CreatedBy= _context.SystemAccounts.FirstOrDefault(n => n.AccountId == HttpContext.Session.GetInt32("UserId"));
            NewsArticle.UpdatedById=null;
            NewsArticle.NewsStatus = IsNewsActive;
            NewsArticle.ModifiedDate = null;
            NewsArticle.Tags = _context.Tags
                                 .Where(tag => SelectedTags.Contains(tag.TagId))
                                 .ToList();
            _context.NewsArticles.Add(NewsArticle);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate");
            return RedirectToPage("/ManageArticles");
        }
    }
}
