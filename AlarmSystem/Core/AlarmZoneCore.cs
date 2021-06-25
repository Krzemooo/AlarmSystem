using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class AlarmZoneCore
    {
        private DBContext _context;

        public AlarmZoneCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<AlarmZone>> GetAlarmZonesAsync()
        {
            return await _context.AlarmZones
                .Include(s=>s.AlarmSystem)
                .ToListAsync();
        }

        public async Task InsertAlarmZoneAsync(AlarmZone insert)
        {
            _context.AlarmZones.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlarmZoneAsync(AlarmZone update)
        {
            _context.AlarmZones.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
