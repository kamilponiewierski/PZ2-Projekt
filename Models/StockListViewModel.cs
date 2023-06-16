using lab11.Models;

class StockListViewModel {
    public List<Stock> AvailableStocks {get; set;}

    public List<Stock> FavouriteStocks {get; set;}

    public bool DisplayFavouritesOnly {get; set;} = false;

    public StockListViewModel(List<Stock> availableStocks, List<Stock> favouriteStocks) {
        this.AvailableStocks = availableStocks;
        this.FavouriteStocks = favouriteStocks;
    }
}