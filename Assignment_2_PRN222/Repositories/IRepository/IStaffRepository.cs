using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IStaffRepository
    {
        Task<List<Category>> GetAllCategory();
        Task AddCategory(Category category);
        Task EditCategory(int categoryID, Category newCategory);
        Task<bool> DeleteCategory(int categoryID);
        Task<List<NewsArticle>> GetAllArticles();

        Task EditArticle(string articleID, NewsArticle NewArticle);

        Task DeleteArticle(string articleID);

        Task UpdateAccount(int accountId, SystemAccount newaccount);

        Task<List<NewsArticle>> ViewHistory(int accountID);
        Task<List<Tag>> GetAllTag();

    }
}
