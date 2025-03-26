using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Business.Models;
using Repositories.IRepository;
namespace Assignment_2.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly IStaffRepository _staffRepository;

        public IndexModel(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public List<Business.Models.Category> Category { get;set; } = new List<Business.Models.Category>();

        public async Task OnGetAsync()
        {
            Category = await _staffRepository.GetAllCategory();
        }
    }
}
