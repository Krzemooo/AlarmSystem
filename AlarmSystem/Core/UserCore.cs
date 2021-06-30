using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Core
{
    public class UserCore
    {
        private DBContext _context;

        public UserCore(DBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int ID)
        {
            return await _context.Users.FirstAsync(s => s.ID == ID);
        }

        public async Task<List<User>> GetOnwersAsync()
        {
            return await _context.Users.Where(s => s.Role == "owner").ToListAsync();
        }

        public async Task InsertUserAsync(User insert)
        {
            _context.Users.Add(insert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User update)
        {
            _context.Users.Update(update);
            await _context.SaveChangesAsync();
        }

        public async Task<string> Login(string email, string passwordString)
        {
            string _hashedPassword = Helper.Crypto.Encrypt(passwordString);
            var _loggedUser = await _context.Users.FirstAsync(a => a.Email == email && a.Password == _hashedPassword);

            if (_loggedUser != null)
                return _loggedUser.Role;
            else
                return null;
        }
    }
}
