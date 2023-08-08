using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_crup_api_demo.Models
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext()
		{
           

        }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DevDb");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

