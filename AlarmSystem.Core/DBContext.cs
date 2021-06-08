using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Core
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
        {

        }
    }
}
