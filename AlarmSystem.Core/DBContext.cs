using AlarmSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Core
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<AlarmAction> AlarmAction { get; set; }
        public DbSet<AlarmObject> AlarmObjects { get; set; }
        public DbSet<AlarmScenerio> AlarmScenerios { get; set; }
        public DbSet<Models.AlarmSystem> AlarmSystems { get; set; }
        public DbSet<AlarmZone> AlarmZones { get; set; }
        public DbSet<InputOutput> InputOutputs { get; set; }
        public DbSet<IOInAlarmZone> IOInAlarmZones { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
