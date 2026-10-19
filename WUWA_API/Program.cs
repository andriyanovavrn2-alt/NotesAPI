
using Microsoft.EntityFrameworkCore;
using WUWA_API.Contracts;
using WUWA_API.DataAccess;
using WUWA_API.Models;

namespace WUWA_API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            builder.Services.AddScoped<NotesDbContext>();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
            await dbContext.Database.EnsureCreatedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
