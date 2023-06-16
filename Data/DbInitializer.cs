using lab11.Models;

namespace lab11.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StockExchangeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Stocks.Any())
            {
                return;
            }

            var stocksManager = new StocksManager();
            
            context.Stocks.AddRange(stocksManager.stocks);
            context.SaveChanges();

            context.StockData.AddRange(stocksManager.stockData);
            context.SaveChanges();

            context.Users.AddRange(new List<User> {new User("admin")});
            context.SaveChanges();
        }
    }
}