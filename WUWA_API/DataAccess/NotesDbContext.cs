using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WUWA_API.Contracts;
using WUWA_API.DataAccess;
using WUWA_API.Models;

namespace WUWA_API.DataAccess
{
    public class NotesDbContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public NotesDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Note> Notes => Set<Note>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }
    }
}
