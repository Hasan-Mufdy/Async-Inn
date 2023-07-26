using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddTransient<IHotel, HotelService>();
            builder.Services.AddTransient<IRoom, RoomService>();
            builder.Services.AddTransient<IAmenity, AmenityService>();
            builder.Services.AddTransient<IRoom, RoomService>();

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson(
                option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
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