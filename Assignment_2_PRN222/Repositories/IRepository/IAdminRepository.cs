using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IAdminRepository
    {
        Task<List<SystemAccount>> GetAllAccount();
         Task AddAccount(SystemAccount account);
         Task DeleteAccount(int accountId);
         Task UpdateAccount(int accountId, SystemAccount newaccount);

         Task<List<NewsArticle>> CreateReport(DateTime startDate, DateTime endDate);
    }
}
