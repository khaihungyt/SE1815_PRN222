using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IAccountRepository
    {
        Task<SystemAccount> Login(string email, string password);
    }
}
