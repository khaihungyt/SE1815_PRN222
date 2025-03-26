using Business.Models;
using DataAccess.DAO;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminDAO _adminDAO;
        public  AdminRepository(AdminDAO adminDAO)
        {
            _adminDAO = adminDAO;
        }
        public async Task AddAccount(SystemAccount account)
        {
             _adminDAO.AddAccount(account);
        }

        public async Task<List<NewsArticle>> CreateReport(DateTime startDate, DateTime endDate)
        {
            return await _adminDAO.CreateReport(startDate, endDate);
        }

        public async Task DeleteAccount(int accountId)
        {
             _adminDAO.DeleteAccount(accountId);
        }

        public async Task<List<SystemAccount>> GetAllAccount()
        {
          return await _adminDAO.GetAllAccount();
        }

        public async Task UpdateAccount(int accountId, SystemAccount newaccount)
        {
           _adminDAO.UpdateAccount(accountId, newaccount);
        }
    }
}
