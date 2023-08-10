using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_crup_api_demo.Dtos.CustomerDto
{
	public class CreateCustomerDto
	{
		[Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please, use letters in the name. Digits are not allowed.")]
        [StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Name must have at least 2 characters")]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        //[Required(AllowEmptyStrings = true)]
        public string? Address { get; set; } = string.Empty;
        //[Required(AllowEmptyStrings = true)]
        [StringLength(1000)]
        public string? Notes { get; set; } = string.Empty;
    }
}

