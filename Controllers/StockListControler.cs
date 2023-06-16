using lab11.Data;
using lab11.Models;
using Microsoft.AspNetCore.Mvc;

public class StockListController : Controller
{
    private readonly StockExchangeContext _context;

    private List<Stock> _stockEntries;

    public StockListController(StockExchangeContext context)
    {
        _context = context;
        _stockEntries = new List<Stock>();
    }

    public IActionResult StockList()
    {
        if (_stockEntries.Count() == 0)
        {
            var query = _context.Stocks;
            _stockEntries = query.ToList();
        }

        List<Stock>? favouriteStocks = null;
        try
        {
            favouriteStocks = _context.FavouriteStocksEntries
                .First(e => e.UserId.Equals("0"))
                .Favourites ?? new List<Stock>();
        }
        catch
        {
            favouriteStocks = new List<Stock>();
        }

        _stockEntries.Sort(
            (a, b) =>
            favouriteStocks.Contains(a)
                ? favouriteStocks.Contains(b)
                    ? a.Ticker.CompareTo(b.Ticker)
                    : -1
                : 1);

        var model = new StockListViewModel(
            _stockEntries,
            favouriteStocks
         );

        return View(model);
    }

    public IActionResult StockPage(Dictionary<String, String> map)
    {
        var ticker = map["ticker"];
        var stock = GetStock(ticker);

        return RedirectToAction(
            "SingleStockDataView",
            "Data",
            stock
            );
    }

    [HttpPost]
    public IActionResult Toggle(string ticker)
    {
        var favouriteStocksEntry = GetFavouriteStocks();
        var stock = GetStock(ticker);

        if (favouriteStocksEntry != null)
        {
            bool isFavorite = favouriteStocksEntry.Favourites.Contains(stock);
            if (isFavorite)
            {
                favouriteStocksEntry.Favourites.Remove(stock);
                ViewBag.Message = "Stock removed from favorites!";
            }
            else
            {
                favouriteStocksEntry.Favourites.Add(stock);
                ViewBag.Message = "Stock added to favorites!";
            }
            _context.FavouriteStocksEntries.Update(favouriteStocksEntry);
        }
        else
        {
            var newFavourites = new List<Stock>();
            newFavourites.Add(stock);
            _context.FavouriteStocksEntries.Add(
                new FavouriteStocksEntry()
                {
                    UserId = "0",
                    Favourites = newFavourites
                }
                    );
        }

        _context.SaveChanges();

        return Redirect("StockList/StockList");
    }

    // TODO inject user id
    private FavouriteStocksEntry? GetFavouriteStocks()
    {
        try
        {
            var currentFavourites = _context.FavouriteStocksEntries.First(
                (e) => e.UserId == "0"
            );
            return currentFavourites;
        }
        catch
        {
            return null;
        }

    }

    private Stock GetStock(string ticker)
    {
        var stock = _context.Stocks.Where((e) => e.Ticker == ticker).First();
        return stock;
    }
}
