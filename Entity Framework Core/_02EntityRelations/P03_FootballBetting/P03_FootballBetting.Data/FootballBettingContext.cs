using System;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        private const string CONNECTION_STRING = 
            @"Server=TEDOFF\SQLEXPRESS;
              Database=FootballBetting;
              Integrated Security=True";
        
        public FootballBettingContext()
        {
            
        }

        public FootballBettingContext(DbContextOptions options)
        :base(options)
        {
            
        }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<User> Users { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerStatistic>(ps =>
            {
                ps.HasKey(pk => new {pk.GameId, pk.PlayerId});
            });
        }
    }
}