using System;
using System.Linq;
using Samurai.Domain;

namespace Samurai.Data.BasicCrud
{
    
    public class CrudRepository:ICrudInterface
    {
        private static SamuraiContext context = new SamuraiContext();
        
        public void GetSamuraies()
        {
            var samurai = new Samurais {Name = "Tanvir"};
            context.Samurais.Add(samurai);
            context.SaveChanges();
            
        }

        public void AddSamurai()
        {
            var samuries = context.Samurais.ToList();
            foreach (var samurai in samuries)
            {
                Console.WriteLine($"Samurai Name {samurai.Name}");
                
            }
        }
    }
}