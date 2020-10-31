using System.Collections.Generic;

namespace Samurai.Domain
{
    public class Samurais
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        public Clan Clan { get; set; }
        
        // object are the navigation property
        // so we can go one table to another
        public Horse Horse { get; set; }

        // this joined Entity
        public List<SamuraisBattle> SamuraisBattles { get; set; }


        public Samurais()
        {
            Quotes = new List<Quote>();
            SamuraisBattles = new List<SamuraisBattle>();

        }

        
    }
}