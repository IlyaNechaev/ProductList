using System.ComponentModel.DataAnnotations;

namespace PL.Web.Models;

public class User
{
    public Guid ObjectID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }

    public ICollection<Order>? Orders { get; set; }
}

public struct UserView
{
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? login { get; set; }
    public string? password { get; set; }

    public User ToUser()
    {
        var user = new User
        {
            ObjectID = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Login = login,
            PasswordHash = password,
            Orders = null
        };

        return user;
    }
}