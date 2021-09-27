using Esercizi.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Corso
    {
        public long Id { get; set; }
        public string Titolo { get; set; }
        public int AmmontareOre { get; set; }
        public long CostoDiRiferimento { get; set; }
        public Livello Livello { get; set; }
        public Progetto Progetto { get; set; }
        public Categoria Categoria { get; set; }
        public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento, Livello livello, Progetto progetto, Categoria categoria)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            Livello = livello;
            Progetto = progetto;
            Categoria = categoria;
        }

        //override equal MA hashcode

        public override string ToString()
        {
            return $"Id:{Id} | Titolo:{Titolo}";
        }

        public override bool Equals(object obj)
        {
            return obj is Corso corso && Id == corso.Id;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }

    }
}
