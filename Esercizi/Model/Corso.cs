using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Corso
    {
        public long Id { get; set; }
        public string Titolo { get; set; }
        public int DurataInOre { get; set; }
        public ExperienceLevel EntryLevel { get; set; }
        public string Description { get; set; }
        public decimal StrandardPrice { get; set; }

        public Corso(long id, string titolo, int durataOre, ExperienceLevel entryLevel, string description, decimal strandardPrice)
        {
            Id = id;
            Titolo = titolo;
            DurataInOre = durataOre;
            EntryLevel = entryLevel;
            Description = description;
            StrandardPrice = strandardPrice;
        }

        //override equal MA hashcode

        public override string ToString()
        {
            return $"Id:{Id} | Titolo:{Titolo} | Livello:{EntryLevel}";
        }
    }

    public enum ExperienceLevel
    {
        PRINCIPIANTE,
        MEDIO,
        ESPERTO,
        GURU
    }
}
