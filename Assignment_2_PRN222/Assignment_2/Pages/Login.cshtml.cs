using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepository;
using Repositories.Repository;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        public LoginModel(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _configuration = configuration;
        }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Email == _configuration["DefaultAccount:email"] && Password == _configuration["DefaultAccount:password"])
            {

                return RedirectToPage("/AdminDashBoard");
            }
            else
            {
                var user = await _accountRepository.Login(Email, Password);
                if (user == null)
                {
                    ErrorMessage = "Invalid email or password.";
                    return Page();
                }
                else
                {
                    if (user.AccountRole == 1)
                    {
                        Console.WriteLine(user.AccountEmail);
                        HttpContext.Session.SetString("UserEmail", user.AccountEmail);
                        HttpContext.Session.SetString("UserFullName", user.AccountName);
                        HttpContext.Session.SetInt32("UserRole", (int)user.AccountRole);
                        HttpContext.Session.SetInt32("UserId", user.AccountId);
                        return RedirectToPage("/StaffDashBoard");
                    }
                    else if (user.AccountRole == 2)
                    {
                        return RedirectToPage("/Index");
                    }
                }
                return Page();
            }
        }
    }
}
