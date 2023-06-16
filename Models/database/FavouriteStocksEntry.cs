using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace lab11.Models;

[PrimaryKey(nameof(UserId))]
public class FavouriteStocksEntry
{
    [ForeignKey("User")]
    public string UserId { get; set; }

    public List<Stock> Favourites { get; set; } = new List<Stock>();
}