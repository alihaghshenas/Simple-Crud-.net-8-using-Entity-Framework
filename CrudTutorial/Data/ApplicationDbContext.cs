using CrudTutorial.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CrudTutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Products> Product {  get; set; }
    }
}
