using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApis.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Discription { get; set; }

        public string Img { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Seller")]

        public string SellerId { get; set; }


        public virtual ApplicationUser Seller { get; set; }

        public virtual Category Category { get; set; }
    }
}
