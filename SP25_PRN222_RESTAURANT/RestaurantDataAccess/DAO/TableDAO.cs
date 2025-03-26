using Microsoft.EntityFrameworkCore;
using RestaurantBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.DAO
{
    public class TableDAO
    {
        private readonly Sp25Prn222RestaurantContext _context;
        public TableDAO(Sp25Prn222RestaurantContext context)
        {
            _context=context;
        }
        public async Task<List<RestaurantBusiness.Table>> SearchTablesBySeat(int seat)
        {
            var tables = await _context.Tables.Where(t => t.Seats == seat).ToListAsync();
            if (tables.Count ==0 && tables ==null )
            {
                tables =  await _context.Tables.ToListAsync();
            }
            return tables;
        }
        public async Task UpdateTablesStatusAsync(int tableId, string Status)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                table.Status = Status;
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> 
    }
}
