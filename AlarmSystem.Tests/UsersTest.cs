using AlarmSystem.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace AlarmSystem.Tests
{
    public class UsersTest
    {
        private DBContext _context;

        [Fact]
        public void InsertUser()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                  .UseSqlServer(new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlarmSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                  .Options;
            _context = new DBContext(options);

            Core.Models.User user = new Core.Models.User()
            {
                Email = "test1",
                Password = "test2",
                Role = "test3"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var _result = _context.Users.First(f => f.Email == "test1");

            _context.Users.Remove(user);
            _context.SaveChanges();

            Assert.Same(user, _result);
        }
    }
}
