using lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace lab11.Data;

public class StockExchangeContext : DbContext
{
    public StockExchangeContext(DbContextOptions<StockExchangeContext> options) : base(options) { }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<FavouriteStocksEntry> FavouriteStocksEntries { get; set; }

    public DbSet<StockData> StockData { get; set; }

    public DbSet<SearchModel> FavouriteSearches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Stock>()
            .ToTable("Stocks");
        modelBuilder.Entity<User>()
            .ToTable("Users");
        modelBuilder.Entity<FavouriteStocksEntry>()
            .ToTable("FavouriteStocks");
        modelBuilder.Entity<StockData>()
            .ToTable("StockData");
        modelBuilder.Entity<SearchModel>()
            .ToTable("Searches");

        base.OnModelCreating(modelBuilder);
    }
}