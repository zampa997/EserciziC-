using Esercizi.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Corso
    {
        #region Properties
        public long Id { get; set; }
        public string Titolo { get; set; }
        public int AmmontareOre { get; set; }
        public long CostoDiRiferimento { get; set; }
        public Livello Livello { get; set; }
        public long IdLivello { get; set; }
        public Progetto Progetto { get; set; }
        public long IdProgetto { get; set; }
        public Categoria Categoria { get; set; }
        public long IdCategoria { get; set; }
        #endregion
        #region Costructor        
        public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento, 
            Livello livello, Progetto progetto, Categoria categoria)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            Livello = livello;
            this.IdLivello = livello.Id;
            Progetto = progetto;
            this.IdProgetto = progetto.Id;
            Categoria = categoria;
            this.IdCategoria = categoria.Id;
        }
        public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
           long idLivello, Progetto progetto, Categoria categoria)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            this.IdLivello = idLivello;
            Progetto = progetto;
            Categoria = categoria;
        }
        public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
           Livello livello, long idProgetto, Categoria categoria)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            Livello = livello;
            this.IdProgetto = idProgetto;
            Categoria = categoria;
        }
        public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
           Livello livello, Progetto progetto, long idCategoria)
        {
            Id = id;
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            Livello = livello;
            Progetto = progetto;
            this.IdCategoria = idCategoria;
        }
        public Corso() { }
        #endregion
        //override equal MA hashcode
        public override string ToString()
        {
            return $@"Id:{Id}
                    Titolo:{Titolo}";
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
