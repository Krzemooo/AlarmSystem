using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class InputOutputCore
    {
        private DBContext _context;

        public InputOutputCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<InputOutput>> GetInputOutputsAsync()
        {
            return await _context.InputOutputs
                .Include(s=>s.AlarmSystem)
                .ToListAsync();
        }

        public async Task InsertInputOutputAsync(InputOutput insert)
        {
            _context.InputOutputs.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInputOutputAsync(InputOutput update)
        {
            _context.InputOutputs.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
