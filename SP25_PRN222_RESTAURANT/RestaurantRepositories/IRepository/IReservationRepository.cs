using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRepositories.IRepository
{
    internal interface IReservationRepository
    {
        Task<bool> IstableAvailableAsync(int tableId, DateTime time);
        Task<bool> HasExistingReservationAsync(int userId, DateTime time);
    }
}
