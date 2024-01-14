using System.ComponentModel.DataAnnotations;

namespace CProduct.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Intereste_Product_Service { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
