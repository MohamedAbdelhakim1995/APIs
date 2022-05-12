using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApis.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int TotalPayment { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public virtual ApplicationUser Customer { get; set; } 

    }
}
