using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public  class StaffDAO
    {
        private readonly FunewsManagementContext _context;
        public StaffDAO(FunewsManagementContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategory()
        {
           return await _context.Categories.ToListAsync();
        }
        public async Task AddCategory(Category category)
        {
           await Task.Delay(1);
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public async Task EditCategory(int categoryID, Category newCategory)
        {
           var category = await _context.Categories.FirstOrDefaultAsync(opt => opt.CategoryId == categoryID);
            category = newCategory;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteCategory(int categoryID)
        {
            var IsexistCategory = await _context.NewsArticles.AnyAsync(c => c.CategoryId == categoryID);
            if (IsexistCategory)
            {
                return false;
            }
            else
            {
                var category =  _context.Categories.FirstOrDefault(c => c.CategoryId == categoryID);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
        }
        public async Task<List<NewsArticle>> GetAllArticles()
        {
            try
            {
                // Kiểm tra nếu DbContext đã bị disposed hoặc null
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is null");
                }

                // Kiểm tra trạng thái kết nối trước khi truy vấn
                var connection = _context.Database.GetDbConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                return await _context.NewsArticles.Include(n =>n.Category).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy bài viết: {ex.Message}");
                throw;
            }
        }
        public async Task AddArticles(NewsArticle article)
        {
           _context.NewsArticles.Add(article);
            await _context.SaveChangesAsync();
        }
        public async Task EditArticle(string articleID, NewsArticle NewArticle)
        {
            var article = _context.NewsArticles.FirstOrDefault(c => c.NewsArticleId == articleID);
            article = NewArticle;
            _context.NewsArticles.Update(article);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteArticle(string articleID)
        {
            var article = await _context.NewsArticles
        .Include(n => n.Tags)
        .FirstOrDefaultAsync(c => c.NewsArticleId == articleID);

            if (article != null)
            {
                if (article.Tags != null && article.Tags.Any())
                {
                    article.Tags.Clear(); // Xóa các liên kết với Tag
                }

                _context.NewsArticles.Remove(article); // Xóa Article
                await _context.SaveChangesAsync(); // Chỉ gọi SaveChangesAsync một lần
            }
        }

        public async Task UpdateAccount(int accountId, SystemAccount newaccount)
        {
            var account = await _context.SystemAccounts.FirstOrDefaultAsync(opt => opt.AccountId == accountId);
            account = newaccount;
            _context.SystemAccounts.Update(account);
            _context.SaveChanges();
        }

        public async Task<List<NewsArticle>> ViewHistory(int accountID)
        {
           return _context.NewsArticles.Where(n => n.CreatedById == accountID).Include(n => n.Category).ToList();
        }


        public async Task<List<Tag>> GetAllTag()
        {
            var ListTag = await _context.Tags.ToListAsync();
            return ListTag;
        }
    }
}
