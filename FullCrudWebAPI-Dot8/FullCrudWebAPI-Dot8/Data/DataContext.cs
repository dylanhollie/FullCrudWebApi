using FullCrudWebAPI_Dot8.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullCrudWebAPI_Dot8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
