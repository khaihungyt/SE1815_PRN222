using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public  class AccountDAO
    {
        private readonly FunewsManagementContext _context;
        public AccountDAO(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<SystemAccount> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                return null;
            }

            try
            {
                var account = _context.SystemAccounts.FirstOrDefault(a => a.AccountEmail == email && a.AccountPassword == password);
                return account;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Login Error: " + ex.Message);
                return null;
            }
        }
    }
}
