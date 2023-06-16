using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab11.Models;

[PrimaryKey(nameof(Ticker), nameof(Date))]
public class StockData
{

    [ForeignKey("Stock")]
    public string Ticker { get; set; }

    // TODO add market to key

    public DateTime Date { get; set; }

    public double Open { get; set; }

    public double Highest { get; set; }

    public double Lowest { get; set; }

    public double Close { get; set; }

    public double Volume { get; set; }


    public StockData(string ticker, StockDataCsv data)
    {
        Ticker = ticker;
        Date = data.Date;
        Open = data.Open;
        Highest = data.Highest;
        Lowest = data.Lowest;
        Close = data.Close;
        Volume = data.Volume;
    }

    public StockData() { }
}