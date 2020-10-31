using Samurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace Samurai.Data
{
    public class SamuraiContext : DbContext
    {
        // adding wrappers in the class
        public DbSet<Samurais> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }
        
        // we dont create separated Entity
        // for horses you can only access with the 
        // Samurai Entity but to create a table we need 
        // a db set so to do that we use the fluent API
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\EFCORE\\Samurai\\samurai.db");
            
        }
        
        // formany to many relationship 
        // you need the fluent Api
        // and you have to use it inside a OnModelCreating
        // method
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // you have to tell the fluent API that
            // it actually has the key
            
            modelBuilder.Entity<SamuraisBattle>().HasKey(s =>
                new
                {
                    s.SamuraiId, s.BattleId
                });
            
            // this will tell the Efcore to create tha table
            // but it has no separate Entity
            modelBuilder.Entity<Horse>().ToTable("Horses");

        }
    }
}
//https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-example.html