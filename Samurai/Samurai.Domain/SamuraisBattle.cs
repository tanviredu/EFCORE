namespace Samurai.Domain
{
    public class SamuraisBattle
    {
        // this is a joined Entity
        // this wil become the foreign key
        // pointing back to the samurai class id
        // and the battle class Id
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        
        // optional
        public Samurais Samurais;
        public Battle Battle;
    }
}