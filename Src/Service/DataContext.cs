using Microsoft.EntityFrameworkCore;
using ServerTest.Models;

namespace ServerTest.Service
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> _Options) : base(_Options)
        {
        }

        //                       \/ table name
        public DbSet<Superhero> Superheros { get; set; }
    }
}