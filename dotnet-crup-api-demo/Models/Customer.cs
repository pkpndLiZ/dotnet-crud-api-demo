using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crup_api_demo.Models
{
	public class Customer
	{

		[Key]
		public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? Address { get; set; }
       
        public string? Notes { get; set; }

	}
}

