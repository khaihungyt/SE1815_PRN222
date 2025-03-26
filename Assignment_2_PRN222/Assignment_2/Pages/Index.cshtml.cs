
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepository;

namespace Assignment_2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;
        public IndexModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository)); 
        }
        public List<NewsArticle> ListArticle { get; set; } = new List<NewsArticle>();
        public async Task OnGet()
        {
            ListArticle = await _staffRepository.GetAllArticles();

        }
    }
}


