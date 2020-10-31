using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Samurai.Domain;

namespace Samurai.Data.Related_data_Crud
{
    public class RelatedCrud : IrelatedCrud
    {
        public static SamuraiContext _context =  new SamuraiContext();
        public void addRelatedData()
        {
            var samurai = new Samurais
            {
                Name = "Tanvir",
                Quotes = new List<Quote>
                {
                    new Quote {Text = "into the sky to win or die"},
                    new Quote {Text = "Live like a villain Die like a  Hero"}
                }
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
            Console.WriteLine("Added");
            
            // 

        }

        public void addDataDisconnectedSenario()
        {
            // first get the data
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Tanvir");
            samurai.Quotes.Add(
                new Quote
                        {
                            Text = "Hello how are you"
                        }
                );
            
            // adding disconnected instance
            using (var _newcontext = new SamuraiContext())
            {
                // now if the disconnected senario
                // then you will use attach
                // now update or add
                _newcontext.Samurais.Attach(samurai);
                _newcontext.SaveChanges();
                Console.WriteLine("Added disconnected");
            }
        }

        public void SamuraiEgarLoading()
        {
            // make a Egar Loding with Egar Loading
            // get samurai with battles
            
            var samuraiwithbattles = _context.Samurais.Include(s => s.SamuraisBattles).ThenInclude(sb => sb.Battle)
                .FirstOrDefault(samu => samu.Id == 2);
            
            /* EXPLANATION OF THE QUERY
                SO YOU SELECT THE SAMURAI TABLE
                THEN INCLUDE THE SAMURAI BATTLE THE JOINTABLE
                TO FIND ALL THE BATTLEID OF THE SAMURAI
                THEN YOU INCLUDE THE BATTLE TABLE AND FIND
                ALL THE BATTLE NAME IN RELATED WITH THE ID
                OF THE BATTLESAMURAI JOIN TABLE
             */
            
        }

        public void GetSamuraiwithHorse()
        {
            // you can do it easily with Egarloading
            var sam_horses = _context.Samurais.Include(s => s.Horse).ToList();
            foreach (var horse in sam_horses)
            {
                Console.WriteLine(horse.Horse);
            }
        }

        public void GetHorseWithSamurai()
        {
            // this is a reverse query
            // to query you need have to have a horse Id
            
            //var horsewithsamurai = _context.Samurais.Include(s => s.Horse).FirstOrDefault(s => s.Horse.Id == 1);
            
            //Console.WriteLine(horsewithsamurai.Name);
            
            /*EXPLANATION EGAR LOAD WITH THE SAMURAI
             THEN ADD THE HOURSE THEN GO WITH THE NAVIGATION
             FIRST SAMURAI THEN ITS HORSE THEN MATCH WITH THE
             ID OF THE HORSE WITH THE GIVEN horseID THEN SELECT*/
        }

        public void AddHorse()
        {
            var horse = new Horse
            {
                Name = "Scout",
                SamuraiId = 2
            };
            _context.Add(horse); // we dont make a dbset for horse
                                  // thats why we use the _context
                                  // to  directly add the horse
            _context.SaveChanges();

        }

        public void filterwithrelatedData()
        {
            var samurai1 = _context.Samurais.Where(s => s.Quotes.Any(q => q.Text.Contains("Die"))).ToList();
            
            
            /*FIND THE SAMURAI IF HE QUOTE ANYTHING IN THE QUOTE
             LIST THAT HAS DIE*/
            
            // find is there a samurai that has tanvir word in his name
            // remember any retuens a boolean
            
            var samurai2 = _context.Samurais.Any(s => s.Name.Contains("Tanvir"));
            
        }
    }
}