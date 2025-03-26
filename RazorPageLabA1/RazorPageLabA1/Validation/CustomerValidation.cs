namespace RazorPageLabA1.Validation;
using System;
using System.ComponentModel.DataAnnotations;

public class CustomerValidation : ValidationAttribute
{
    public CustomerValidation()
    {
        ErrorMessage = "The year of birth cannot greater than current year (2021).";
    }

    public override bool IsValid(object value)
    {
        if (value == null)
            return false;

        int number = int.Parse(value.ToString());

        return (number < 2021);
    }
}

