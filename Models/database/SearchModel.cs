using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lab11.Models;

[PrimaryKey(nameof(StartDate), nameof(EndDate), nameof(ValueChangePercent))]
public class SearchModel
{
    [Required(ErrorMessage = "Start date must not be null")]
    public DateTime? StartDate { get; set; }

    [Required(ErrorMessage = "End date must not be null")]
    public DateTime? EndDate { get; set; }

    public decimal ValueChangePercent { get; set; }
}
