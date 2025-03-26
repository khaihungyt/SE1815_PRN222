using RestaurantBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.DAO
{
    public class UserDAO
    {
        private readonly Sp25Prn222RestaurantContext _context;
        public UserDAO(Sp25Prn222RestaurantContext context)
        {
            _context = context;
        }
    }

}
