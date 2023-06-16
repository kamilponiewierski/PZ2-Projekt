using System.ComponentModel.DataAnnotations;

namespace lab11.Models;

public class SearchResultViewModel {
    [Required]
    public List<StockPerformanceModel> MatchingStocks {get; set;}
    public decimal ValueChangePercent { get; set; }
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public bool isFavorite {get; set;} = false;
}