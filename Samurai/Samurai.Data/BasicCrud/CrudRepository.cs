using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Samurai.Domain;

namespace Samurai.Data.BasicCrud
{
    
    public class CrudRepository:ICrudInterface
    {
        // use static so you can use in the every method
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

        public void insertVariousTypes()
        {
            // you can add difeent object
            // and multiple object
            // with direct db context
            // dont have to use the DB set
            // this is basically uses to Seed the table
            var samurai = new Samurais {Name = "Tasa"};
            var clan = new Clan {ClassName = "Imperial Classs"};
            context.AddRange(samurai,clan);
            context.SaveChanges();

        }

        public void Querywithfilters()
        {
            var samurais = context.Samurais.Where(s => s.Id == 1).ToList();
            foreach (var samurai in samurais)
            {
                Console.WriteLine($"Samurai Name {samurai.Name}");
                
            }
        }

        public void MyFirstOrDefault()
        {
            var samurai = context.Samurais.FirstOrDefault(s => s.Id == 1);
            Console.WriteLine(samurai.Name);
            
        }

        public void addBattle()
        {
            var newbattle = new Battle
            {
                Name = "Battle of the Dead",
                StartDate = new DateTime(1971,12,23),
                EndDate = new DateTime(2002,12,31)

            };
            context.Battles.Add(newbattle);
            context.SaveChanges();
            Console.WriteLine("Added");
        }

        public void Disconnectedupdate()
        {
            // this will update the data with 
            // the disconnected senario
            var battle = context.Battles.AsNoTracking().FirstOrDefault(s=>s.Name == "Battle of the Dead");
            battle.EndDate = new DateTime(2002,12,31);

            using (var _newcontext = new SamuraiContext())
            {
                // so the discontinues senario
                // is almost the same
                _newcontext.Battles.Update(battle);
                _newcontext.SaveChanges();
            }
        }
    }
}