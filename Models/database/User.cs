using Microsoft.EntityFrameworkCore;

namespace lab11.Models;

[PrimaryKey(nameof(Login))]
public class User
{
    public string Login { get; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName => FirstName != null && LastName != null ? $"{FirstName} {LastName}" : LastName ?? FirstName;
    public string? Description { get; set; }

    public User(string login)
    {
        Login = login;
    }

    public User(string login, string? firstName, string? lastName, string? description)
    {
        Login = login;
        FirstName = firstName;
        LastName = lastName;
        Description = description;
    }

}
