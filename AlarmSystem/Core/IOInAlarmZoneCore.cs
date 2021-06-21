using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class IOInAlarmZoneCore
    {
        private DBContext _context;

        public IOInAlarmZoneCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<IOInAlarmZone>> GetIOInAlarmZonesAsync()
        {
            return await _context.IOInAlarmZones.ToListAsync();
        }

        public async Task InsertIOInAlarmZoneAsync(IOInAlarmZone insert)
        {
            _context.IOInAlarmZones.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIOInAlarmZoneAsync(IOInAlarmZone update)
        {
            _context.IOInAlarmZones.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
