// See https://aka.ms/new-console-template for more information
using EntityFrameworkCore.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

//First you need an intance of context
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Combine(path, "FootballLeage_EfCore.db");
var optionsBuilder = new DbContextOptionsBuilder<FotballLeagueDbContext>();
optionsBuilder.UseSqlite($"Data Source={dbPath}");
using var context = new FotballLeagueDbContext(optionsBuilder.Options);

var teams = await context.Teams.ToListAsync();
foreach (var team in teams)
Console.WriteLine(team.Name);



/*
FotballLeagueDbContext x = new FotballLeagueDbContext();
x.PrintX();*/