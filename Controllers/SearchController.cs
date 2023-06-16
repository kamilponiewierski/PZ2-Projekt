using lab11.Data;
using lab11.Models;
using Microsoft.AspNetCore.Mvc;

public class SearchController : Controller
{
    private readonly StockExchangeContext _context;
    public SearchController(StockExchangeContext context)
    {
        _context = context;
    }

    // GET: SearchController/Search
    public ActionResult Search()
    {
        List<SearchModel> favouriteSearches = _context.FavouriteSearches.ToList();
        var model = new SearchViewModel()
        {
            SearchModel = new SearchModel(),
            FavouriteSearches = favouriteSearches,
        };
        return View(model);
    }

    // POST: SearchController/Search
    [HttpPost]
    public ActionResult Search(Dictionary<String, String> searchParams)
    {
        DateTime startDate;
        DateTime endDate;

        decimal soughtChange;

        try
        {
            startDate = DateTime.Parse(searchParams["StartDate"]);
            endDate = DateTime.Parse(searchParams["EndDate"]);
            soughtChange = decimal.Parse(searchParams["ValueChangePercent"]);
        }
        catch
        {
            return Search();
        }


        var firstStartDate = startDate;
        // Handle holidays and weekends
        while (true)
        {

            if (startDate.AddDays(-10) > firstStartDate)
            {
                // out of range of records
                return Search();
            }
            try
            {
                _context.StockData.First(s => s.Date.Equals(startDate));
                break;
            }
            catch
            {
                startDate = startDate.AddDays(-1);
            }
        }

        while (true)
        {
            if (DateTime.Now < endDate)
            {
                return Search();
            }
            try
            {
                _context.StockData.First(s => s.Date.Equals(endDate));
                break;
            }
            catch
            {
                endDate = endDate.AddDays(1);
            }
        }

        if (startDate.CompareTo(endDate) >= 0)
        {
            this.ModelState.AddModelError(
                "Dates",
                "End date cannot be set before start date"
                );
        }



        var stockPerformances = _context.StockData
            .Where(s => s.Date >= startDate && s.Date <= endDate)
            .GroupBy(s => s.Ticker)
            .Select(g => new StockPerformanceModel
            {
                StartDate = startDate,
                EndDate = endDate,
                StartPrice = g.First((e) => e.Date.Equals(startDate)).Open,
                EndPrice = g.First((e) => e.Date.Equals(endDate)).Close,
                Stock = _context.Stocks.First(stock => stock.Ticker == g.Key),
            })
            .ToList();

        var matchingStocks = stockPerformances
            .Where(
                (e) => soughtChange == 0
                ? true
                : soughtChange > 0
                    ? e.StockPerformancePercent > soughtChange
                    : e.StockPerformancePercent < soughtChange
                ).ToList();

        bool? isFavourite = null;
        if (searchParams.ContainsKey("Favourite"))
        {
            isFavourite = searchParams["Favourite"] == "true/";
        }
        var resultModel = new SearchResultViewModel
        {
            MatchingStocks = matchingStocks,
            StartDate = startDate,
            EndDate = endDate,
            isFavorite = isFavourite ?? false,
            ValueChangePercent = soughtChange,
        };

        return SearchResults(resultModel);
    }

    // GET: SearchController/SearchResults
    public ActionResult SearchResults(SearchResultViewModel model)
    {
        return View("SearchResults", model);
    }

    [HttpPost]
    public ActionResult Favourite(Dictionary<String, String> map)
    {
        SearchModel savedSearch = new SearchModel()
        {
            StartDate = DateTime.Parse(map["startDate"]),
            EndDate = DateTime.Parse(map["endDate"]),
            ValueChangePercent = decimal.Parse(map["change"])
        };

        if (_context.FavouriteSearches.Contains(savedSearch))
        {
            _context.FavouriteSearches.Remove(savedSearch);
        }
        else
        {
            _context.FavouriteSearches.Add(savedSearch);
        }
        _context.SaveChanges();

        return Redirect("Search");
    }

    private Stock GetStock(string ticker)
    {
        var stock = _context.Stocks.Where((e) => e.Ticker == ticker).First();
        return stock;
    }
}
