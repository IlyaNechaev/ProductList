using System.ComponentModel.DataAnnotations;

namespace PL.Web.Models;

public class User
{
    [Required]
    public Guid ObjectID { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Login { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public ICollection<Order> Orders { get; set; }
}