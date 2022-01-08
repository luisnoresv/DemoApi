using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
   public class ApiContext : DbContext
   {
      public ApiContext(DbContextOptions options) : base(options) { }

      public DbSet<Product> Products { get; set; }
   }
}