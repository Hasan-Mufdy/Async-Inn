using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<HotelDbContext>
                (opions => opions.UseSqlServer(connString));



            var app = builder.Build();

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/Test/PrintHelo", () => "Hello From Test!");

            app.Run();
        }
    }
}