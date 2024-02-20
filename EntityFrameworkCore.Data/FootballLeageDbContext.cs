using System.Reflection;

using EntityFrameworkCore.Data.Configurations;
using EntityFrameworkCore.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
    public class FootballLeageDbContext : DbContext
    {
        public FootballLeageDbContext(DbContextOptions<FootballLeageDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams
        {
            get;
            set;
        }

        public DbSet<Coach> Coaches
        {
            get;
            set;
        }

        public DbSet<League> Leagues
        {
            get;
            set;
        }

        public DbSet<Match> Matches
        {
            get;
            set;
        }

        public DbSet<TeamsAndLeaguesView> TeamsAndLeaguesViews { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<TeamsAndLeaguesView>()
                        .HasNoKey()
                        .ToView("vw_TeamsAndLeagues");
            modelBuilder.HasDbFunction(typeof(FootballLeageDbContext).GetMethod(nameof(GetEarliestTeamMatch), new[] { typeof(int) }))
                        .HasName("GetEarliestMatch");
        }

//        [DbFunction("GetEarliestMatch", "dbo")]
        public DateTime GetEarliestTeamMatch(int teamId) => throw new NotImplementedException();
    }
}
