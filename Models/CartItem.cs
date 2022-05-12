using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApis.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Img { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }



        [ForeignKey("Cart")]
        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }

    }
}
