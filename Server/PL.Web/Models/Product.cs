using System.ComponentModel.DataAnnotations;

namespace PL.Web.Models;

public class Product
{
    public Guid ObjectID { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }

    public ICollection<Order> Orders { get; set; }
}
