using System.ComponentModel.DataAnnotations;

namespace lab11.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
