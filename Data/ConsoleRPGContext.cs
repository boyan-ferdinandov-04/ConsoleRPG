using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRPG.Data
{
    internal class ConsoleRPGContext:DbContext
    {
        public DbSet<GameLog> GameLogs { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ConsoleRPG;Trusted_Connection=True;"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .HasOne(g => g.GameLog)
                .WithOne(gl => gl.Session)
                .HasForeignKey<Session>(g => g.GameLogId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
