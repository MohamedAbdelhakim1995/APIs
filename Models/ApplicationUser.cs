using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApis.Models
{
    public class ApplicationUser :IdentityUser
    {

        public virtual List<Order> orders { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual ICollection<Product> products { get; set; }


    }
}
