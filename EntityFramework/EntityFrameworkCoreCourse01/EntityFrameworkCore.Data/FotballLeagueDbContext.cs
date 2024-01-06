using EntityFrameworkCore.Data.Configurations;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EntityFrameworkCore.Data;

public class FotballLeagueDbContext : DbContext
{
    /*public FotballLeagueDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "FootballLeage_EfCore.db");

    }*/

    public FotballLeagueDbContext(DbContextOptions<FotballLeagueDbContext> options) : base(options)
    {
                
    }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<TeamsAndLeaguesView> TeamsAndLeaguesView { get; set; }
    public string DbPath { get;  }

/*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    optionsBuilder.UseSqlite($"Data Source={DbPath}")
            .LogTo(Console.WriteLine, (Microsoft.Extensions.Logging.LogLevel)LogLevel.Info)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
            //.LogTo(Console.WriteLine, LogLevel.Info.ToString());
    }*/

    public void PrintX()
    {
        Console.WriteLine(DbPath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<TeamsAndLeaguesView>().HasNoKey().ToView("vw_TeamsAndLeagues");
    }
}

public class FootballLeagueDbContextFactory : IDesignTimeDbContextFactory<FotballLeagueDbContext>
{
    public FotballLeagueDbContext CreateDbContext(string[] args)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var dbPath = Path.Combine(path, configuration.GetConnectionString
            ("SqliteDatabaseConnectionString"));

        var optionsBuilder = new DbContextOptionsBuilder<FotballLeagueDbContext>();
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        return new FotballLeagueDbContext(optionsBuilder.Options);

    }
}