
using System.ComponentModel.DataAnnotations;

namespace StevenMovies.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Genre { get; set; } = string.Empty;

    [Range(0.01, 100)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(10)]
    public string Rating { get; set; } = string.Empty;
}
