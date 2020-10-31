﻿using System;
using System.Collections.Generic;

namespace Samurai.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SamuraisBattle>SamuraisBattles { get; set; }
        
        
        public Battle()
        {
            SamuraisBattles = new List<SamuraisBattle>();
        }
    }
}