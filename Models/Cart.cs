using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceApis.Models
{
    public class Cart
    {

        public int Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public virtual List<CartItem> CartItems { get; set; }
        [JsonIgnore]

        public virtual ApplicationUser Customer { get; set; }
    }
}
