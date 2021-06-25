using System;
using System.Collections.Generic;
using AlarmSystem.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlarmSystem.Core
{
    public class AlarmSystemCore
    {
        private DBContext _context;

        public AlarmSystemCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Models.AlarmSystem>> GetAlarmSystemsAsync()
        {
            return await _context.AlarmSystems
                .Include(s=>s.AlarmObject)
                .ToListAsync();
        }

        public async Task InsertAlarmSystemAsync(Models.AlarmSystem insert)
        {
            _context.AlarmSystems.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlarmSystemAsync(Models.AlarmSystem update)
        {
            _context.AlarmSystems.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
