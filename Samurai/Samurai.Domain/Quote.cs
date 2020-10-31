namespace Samurai.Domain
{
    public class Quote
    {
        public int Id {get; set; }
        public string Text { get; set; }
        
        // one to many relationship
        public int SamuraiId { get; set; } // this will contain the Id property calue
        public Samurais Samurai { get; set; }


    }
}