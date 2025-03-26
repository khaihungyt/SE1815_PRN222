using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repositories.IRepository;
using Repositories.Repository;

namespace Assignment_2.Pages
{
    public class ManageArticlesModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IHubContext<ArticleHub> _hubContext;
        public ManageArticlesModel(IStaffRepository staffRepository, IHubContext<ArticleHub> hubContext)
        {
            _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
            _hubContext = hubContext;
        }
        public List<NewsArticle> ListArticle { get; set; } = new List<NewsArticle>();
        public async Task OnGet()
        {
            ListArticle = await _staffRepository.GetAllArticles();

        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            await _staffRepository.DeleteArticle(id);
            await _hubContext.Clients.All.SendAsync("ReceiveUpdate");
            return Page();
        }
    }
}
