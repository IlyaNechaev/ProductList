using System.ComponentModel.DataAnnotations;

namespace PL.Web.Models;

public class Product
{
    [Required]
    public Guid ObjectID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public float Price { get; set; }

    [Required]
    public int Count { get; set; }

    public ICollection<Order> Orders { get; set; }
}
