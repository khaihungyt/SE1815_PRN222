using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business.Models;
using System.Text.Json;

namespace Assignment_2.Pages.Profiles
{
    public class AdminEditModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly string _appSettingsPath;

        public AdminEditModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        }

        [BindProperty]
        public AdminAccount AdminAccount { get; set; } = new();

        public void OnGet()
        {
            // Đọc thông tin tài khoản từ appsettings.json
            AdminAccount.Email = _configuration["DefaultAccount:email"] ?? "";
            AdminAccount.Password = _configuration["DefaultAccount:password"] ?? "";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Đọc toàn bộ nội dung appsettings.json
            var json = System.IO.File.ReadAllText(_appSettingsPath);
            var jsonDoc = JsonDocument.Parse(json);
            var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;

            // Cập nhật thông tin tài khoản admin
            if (jsonObject.ContainsKey("DefaultAccount"))
            {
                jsonObject["DefaultAccount"] = new
                {
                    email = AdminAccount.Email,
                    password = AdminAccount.Password
                };
            }

            // Ghi lại dữ liệu mới vào appsettings.json
            var updatedJson = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_appSettingsPath, updatedJson);

            TempData["Message"] = "Admin account updated successfully.";
            return RedirectToPage("/AdminDashBoard");
        }
    }

}
