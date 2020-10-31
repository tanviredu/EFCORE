using System;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}