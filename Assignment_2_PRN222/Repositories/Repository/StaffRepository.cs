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
    public class StaffRepository : IStaffRepository
    {
        private readonly StaffDAO _staffDAO;
        public  StaffRepository(StaffDAO staffDAO)
        {
            _staffDAO = staffDAO;
        }
        public async Task AddCategory(Category category)
        {
            await _staffDAO.AddCategory(category);
        }

        public async Task DeleteArticle(string articleID)
        {
            await _staffDAO.DeleteArticle(articleID);
        }

        public async Task<bool> DeleteCategory(int categoryID)
        {
           return await _staffDAO.DeleteCategory(categoryID);
        }

        public async Task EditArticle(string articleID, NewsArticle NewArticle)
        {
           await _staffDAO.EditArticle(articleID, NewArticle);
        }

        public async Task EditCategory(int categoryID, Category newCategory)
        {
            await _staffDAO.EditCategory(categoryID, newCategory);
        }

        public async Task<List<NewsArticle>> GetAllArticles()
        {
            return await _staffDAO.GetAllArticles();
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _staffDAO.GetAllCategory();
        }

        public async Task UpdateAccount(int accountId, SystemAccount newaccount)
        {
             await _staffDAO.UpdateAccount(accountId, newaccount);
        }

        public async Task<List<NewsArticle>> ViewHistory(int accountID)
        {
          return await _staffDAO.ViewHistory(accountID);
        }
        public async Task<List<Tag>> GetAllTag()
        {
           return await _staffDAO.GetAllTag();
        }
    }
}
