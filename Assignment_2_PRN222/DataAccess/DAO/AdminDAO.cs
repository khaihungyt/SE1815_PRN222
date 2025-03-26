using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AdminDAO
    {
        private readonly FunewsManagementContext _context;
        public AdminDAO(FunewsManagementContext context)
        {
            _context = context;
        }
        public async Task<List<SystemAccount>> GetAllAccount()
        {
            var AccountList = await _context.SystemAccounts.ToListAsync();
            return AccountList;
        }
        public async Task AddAccount(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            _context.SaveChanges();
        }
        public async Task DeleteAccount(int accountId)
        {
            var account = await _context.SystemAccounts.FirstOrDefaultAsync(opt => opt.AccountId == accountId);
            _context.SystemAccounts.Remove(account);
            _context.SaveChanges();
        }
        public async Task UpdateAccount(int accountId, SystemAccount newaccount)
        {
            var account = await _context.SystemAccounts.FirstOrDefaultAsync(opt => opt.AccountId == accountId);
            account= newaccount;
            _context.SystemAccounts.Update(account);
            _context.SaveChanges();
        }


        public async Task<List<NewsArticle>> CreateReport(DateTime startDate, DateTime endDate)
        {
            var reportData = _context.NewsArticles
                .Where(n => n.CreatedDate >= startDate && n.CreatedDate <= endDate)
                .OrderByDescending(n => n.CreatedDate)
                .ToList();
            return reportData;
        }
    }
}
