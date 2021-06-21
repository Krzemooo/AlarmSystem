using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class AlarmScenerioCore
    {
        private DBContext _context;

        public AlarmScenerioCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<AlarmScenerio>> GetAlarmSceneriosAsync()
        {
            return await _context.AlarmScenerios.ToListAsync();
        }

        public async Task InsertAlarmScenerioAsync(AlarmScenerio insert)
        {
            _context.AlarmScenerios.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlarmScenerioAsync(AlarmScenerio update)
        {
            _context.AlarmScenerios.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
