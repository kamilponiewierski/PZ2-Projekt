namespace lab11.Models;

public class StockPerformanceModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double StartPrice { get; set; }
    public double EndPrice { get; set; }
    public Stock Stock { get; set; }
    public decimal StockPerformancePercent { get => (decimal) (EndPrice / StartPrice - 1) * 100;}
}