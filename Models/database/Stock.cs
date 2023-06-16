using Microsoft.EntityFrameworkCore;

namespace lab11.Models;
[PrimaryKey(nameof(Ticker))]
public class Stock
{
    public string Ticker { get; set;}
    public string FullName { get; set;}
    public string Market { get; set;}

    public Stock(string ticker, string fullName, string market)
    {
        Ticker = ticker;
        FullName = fullName;
        Market = market;
    }

    public Stock() {}
}
