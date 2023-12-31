using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAppTwo.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public double Price {  get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
