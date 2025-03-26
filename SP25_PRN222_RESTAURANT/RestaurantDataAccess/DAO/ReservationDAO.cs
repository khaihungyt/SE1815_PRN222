using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.DAO
{
    public class ReservationDAO
    {
        private readonly Sp25Prn222RestaurantContext _context;
        public ReservationDAO(Sp25Prn222RestaurantContext context)
        {
            _context = context;
        }
        public async Task<bool> IsTableAvailableAsync(int TableId, DateTime time)
        {
            var table = await _context.Tables.FindAsync(TableId);
            if (table == null || table.Status != "Available")
            {
                return false;
            }
            var existingReservation = await _context.Reservations.Where(r => r.TableId == TableId && r.ReservationDate == time
            && (r.Status == "Confirm" || r.Status == "Pending")).AnyAsync();
            return !existingReservation;
        }
        public async Task<bool> HasExistingReservationAsync(int UserId, DateTime time)
        {
            return await _context.Reservations.Where(r => r.UserId == UserId && r.ReservationDate == time
            && (r.Status == "Confirm" || r.Status == "Pending")).AnyAsync();
        }
        public async Task AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        public async Task<List<Reservation>> GetReservationByUserAsync(int UserId)
        {
            return await _context.Reservations.Where(r => r.UserId == UserId).ToListAsync();
        }
    }
}
