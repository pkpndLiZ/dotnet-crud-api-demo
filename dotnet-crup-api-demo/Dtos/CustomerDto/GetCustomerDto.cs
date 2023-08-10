using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crup_api_demo.Dtos.CustomerDto
{
	public class GetCustomerDto
	{

       
        public int ID { get; set; }
       
        public string Name { get; set; }
      
        public string Email { get; set; }

        //public string Address { get; set; }

        //public string Notes { get; set; }
    }
}

