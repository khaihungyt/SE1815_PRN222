
using System.ComponentModel.DataAnnotations;

namespace SignalRHub.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; } 
        public string productName {  get; set; }
        public string category {  get; set; }
        public int unitPrice {  get; set; }
        public int stockQuantity {  get; set; }
    }
}
