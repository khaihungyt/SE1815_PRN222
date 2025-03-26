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
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO _accountDAO;
        public AccountRepository(AccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }
        public Task<SystemAccount> Login(string email, string password)
        {
           return _accountDAO.Login(email, password);
        }
    }
}
