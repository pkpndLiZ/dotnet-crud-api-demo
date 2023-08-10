using System;
using AutoMapper;
using dotnet_crup_api_demo.Dtos.CustomerDto;
using dotnet_crup_api_demo.Models;

namespace dotnet_crup_api_demo.Configurations
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetCustomerDto>();
        }
	}
}

