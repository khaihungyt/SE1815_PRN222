using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RazorPageLabA1.Validation;
using RazorPagesLabA1.Binding;

namespace RazorPagesLabA1.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from 3 to 20 characters.")]
        [Display(Name = "Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer email is required!")]
        [EmailAddress]
        [Display(Name = "Customer email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Year of birth is required!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "Year of birth must be between 1960 and 2000.")]
        [CustomerValidation]
        public int? YearOfBirth { get; set; }
    }
}