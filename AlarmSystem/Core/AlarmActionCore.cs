using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class AlarmActionCore
    {
        private DBContext _context;

        public AlarmActionCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<AlarmAction>> GetAlarmActionsAsync()
        {
            return await _context.AlarmAction.ToListAsync();
        }

        public async Task InsertAlarmActionAsync(AlarmAction insert)
        {
            _context.AlarmAction.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlarmActionAsync(AlarmAction update)
        {
            _context.AlarmAction.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
