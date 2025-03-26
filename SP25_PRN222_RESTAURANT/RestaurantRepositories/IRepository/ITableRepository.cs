using RestaurantBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRepositories.IRepository
{
    public interface ITableRepository
    {
        Task<List<Table>> SearchTableBySeatsAsync(int seats);
        Task AddTableAsync(Table table);
     
    }
}
