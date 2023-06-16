using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace lab11.Models;

public class StockDataCsv
{

    [Name("Data")]
    public DateTime Date { get; set; }

    [Name("Otwarcie")]
    public double Open { get; set; }

    [Name("Najwyzszy")]
    public double Highest { get; set; }

    [Name("Najnizszy")]
    public double Lowest { get; set; }

    [Name("Zamkniecie")]
    public double Close { get; set; }

    [Name("Wolumen")]
    public double Volume { get; set; }

}
