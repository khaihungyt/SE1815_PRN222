using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProductEditModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string Name { get; set; }
        public string Password {  get; set; }
    }
}
