using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class AlarmObjectCore
    {
        private DBContext _context;

        public AlarmObjectCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<AlarmObject>> GetAlarmObjectsAsync()
        {
            return await _context.AlarmObjects
                .Include(s => s.ObjectOwner)
                .ToListAsync();
        }

        public async Task<AlarmObject> GetAlarmObjectAsync(int ID)
        {
            return await _context.AlarmObjects
                .Include(s => s.ObjectOwner)
                .FirstAsync(f => f.ID == ID);
        }

        public async Task InsertAlarmObjectAsync(AlarmObject insert)
        {
            _context.AlarmObjects.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlarmObjectAsync(AlarmObject update)
        {
            _context.AlarmObjects.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
