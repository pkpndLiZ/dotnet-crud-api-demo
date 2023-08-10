using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crup_api_demo.Dtos.CustomerDto
{
	public class UpdateCustomerDto
	{
        public class CreateCustomerDto
        {
           
            [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use letters in the name. Digits are not allowed.")]
            [StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Name must have at least 2 characters")]
            public string Name { get; set; }            
            [EmailAddress]
            public string Email { get; set; }
            //[Required(AllowEmptyStrings = true)]
            public string? Address { get; set; } = string.Empty;
            //[Required(AllowEmptyStrings = true)]
            [StringLength(1000)]
            public string? Notes { get; set; } = string.Empty;
        }
    }
}

