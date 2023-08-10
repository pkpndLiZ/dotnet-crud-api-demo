
using dotnet_crup_api_demo.Models;
using dotnet_crup_api_demo.Services.CustomerService;

namespace dotnet_crup_api_demo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<ApiDbContext>();
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

