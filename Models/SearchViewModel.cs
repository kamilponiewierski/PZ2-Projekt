namespace lab11.Models;

public class SearchViewModel {
    public SearchModel SearchModel {get; set;}

    public List<SearchModel> FavouriteSearches {get; set;} = new List<SearchModel>();
}