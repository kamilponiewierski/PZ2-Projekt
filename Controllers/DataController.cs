using lab11.Data;
using lab11.Models;
using Microsoft.AspNetCore.Mvc;

public class DataController : Controller
{
    private readonly StockExchangeContext _context;

    private List<StockTableEntry> _stockEntries;

    public DataController(StockExchangeContext context)
    {
        _context = context;
        _stockEntries = new List<StockTableEntry>();
    }

    public IActionResult SingleStockDataView(Stock stock)
    {
        if (_stockEntries.Count() == 0)
        {
            var query = from stockData in _context.StockData 
                        where stockData.Ticker == stock.Ticker 
                        orderby stockData.Date descending
                        select new StockTableEntry(stock, stockData);

            _stockEntries = query.ToList();
        }
        var model = new TableViewModel(_stockEntries);

        return View(model);
    }
}
