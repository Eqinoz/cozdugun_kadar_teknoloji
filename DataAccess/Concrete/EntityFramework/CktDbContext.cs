using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CktDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=YOSHI\YOSHI;Database=CKT;Trusted_Connection=true;TrustServerCertificate=true"
            );
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionType> MissionTypes { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<TestMission> TestMissions { get; set; }
        public DbSet<PhotoMission> PhotoMissions { get; set; }
    }
}
