using System.ComponentModel.DataAnnotations;

namespace PL.Web.Models;

public class User
{
    public Guid ObjectID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<Order>? Orders { get; set; }
}