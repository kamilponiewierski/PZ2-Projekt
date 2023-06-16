using lab11.Models;

public class TableViewModel
{
    public List<StockTableEntry> StockTableEntries;

    public TableViewModel(List<StockTableEntry> stockTableEntries)
    {
        StockTableEntries = stockTableEntries;
    }
}

public class StockTableEntry
{
    public string Ticker;
    public string FullName;
    public string Market;
    public DateTime Date;
    public double Highest;
    public double Lowest;
    public double Open;
    public double Close;

    public StockTableEntry(
        Stock stock,
        StockData stockData
    )
    {
        Ticker = stock.Ticker;
        FullName = stock.FullName;
        Market = stock.Market;
        Date = stockData.Date;
        Highest = stockData.Highest;
        Lowest = stockData.Lowest;
        Open = stockData.Open;
        Close = stockData.Close;

    }
    public StockTableEntry(
        string ticker,
        string fullName,
        string market,
        DateTime date,
        double highest,
        double lowest,
        double open,
        double close
    )
    {
        Ticker = ticker;
        FullName = fullName;
        Market = market;
        Date = date;
        Highest = highest;
        Lowest = lowest;
        Open = open;
        Close = close;
    }

}