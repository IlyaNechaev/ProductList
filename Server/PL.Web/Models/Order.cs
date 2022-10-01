using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PL.Web.Models;

public class Order
{
    public Guid ObjectID { get; set; }
    public long? Number { get; set; }

    public Guid OwnerID { get; set; }
    public User Owner { get; set; }

    public ICollection<Product> Products { get; set; }
}