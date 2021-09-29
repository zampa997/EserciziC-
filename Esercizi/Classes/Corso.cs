using Esercizi.Classes;
using Esercizi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Corso
    {//checked
        #region Properties
        public long Id { get; set; }
        public string Titolo { get; set; }
        public int AmmontareOre { get; set; }
        public string Descrizione { get; set; }
        public decimal CostoDiRiferimento { get; set; }
        public Livello Livello { get; set; }
        public long IdLivello { get; set; }
        public Progetto Progetto { get; set; }
        public long IdProgetto { get; set; }
        public Categoria Categoria { get; set; }
        public long IdCategoria { get; set; }
        #endregion
        #region Costructor        
        public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
            Livello livello, Progetto progetto, Categoria categoria, string descrizione)
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
            Descrizione = descrizione;
        }
        public Corso(string titolo, int ammontareOre, decimal costoDiRiferimento,
         long idLivello, long idProgetto, long idCategoria, string descrizione)
        {
            Titolo = titolo;
            AmmontareOre = ammontareOre;
            CostoDiRiferimento = costoDiRiferimento;
            this.IdProgetto = idProgetto;
            this.IdLivello = idLivello;
            this.IdCategoria = idCategoria;
            Descrizione = descrizione;
        }

        //public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
        //   long idLivello, Progetto progetto, Categoria categoria, string descrizione)
        //{
        //    Id = id;
        //    Titolo = titolo;
        //    AmmontareOre = ammontareOre;
        //    CostoDiRiferimento = costoDiRiferimento;
        //    this.IdLivello = idLivello;
        //    Progetto = progetto;
        //    Categoria = categoria;
        //    Descrizione = descrizione;
        //}
        //public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
        //   Livello livello, long idProgetto, Categoria categoria, string descrizione)
        //{
        //    Id = id;
        //    Titolo = titolo;
        //    AmmontareOre = ammontareOre;
        //    CostoDiRiferimento = costoDiRiferimento;
        //    Livello = livello;
        //    this.IdProgetto = idProgetto;
        //    Categoria = categoria;
        //    Descrizione = descrizione;
        //}
        //public Corso(long id, string titolo, int ammontareOre, long costoDiRiferimento,
        //   Livello livello, Progetto progetto, long idCategoria, string descrizione)
        //{
        //    Id = id;
        //    Titolo = titolo;
        //    AmmontareOre = ammontareOre;
        //    CostoDiRiferimento = costoDiRiferimento;
        //    Livello = livello;
        //    Progetto = progetto;
        //    this.IdCategoria = idCategoria;
        //    Descrizione = descrizione;
        //}
        //public Corso(string titolo, int ammontareOre, decimal costoDiRiferimento,
        //   long idLivello, long idProgetto, long idCategoria, string descrizione)
        //{            
        //    Titolo = titolo;
        //    AmmontareOre = ammontareOre;
        //    CostoDiRiferimento = costoDiRiferimento;
        //    this.IdProgetto = idProgetto;
        //    this.IdLivello = idLivello;
        //    this.IdCategoria = idCategoria;
        //    InDBRepository dbr = new InDBRepository();
        //    Progetto = dbr.GetProgettobyId(idProgetto);
        //    Livello = dbr.GetLivellobyId(idLivello);
        //    Categoria = dbr.GetCategoriabyId(idCategoria);
        //    Descrizione = descrizione;
        //}

        //public Corso(int id, string titolo, int ammontareOre, decimal costoDiRiferimento,
        //   long idLivello, long idProgetto, long idCategoria, string descrizione)
        //{
        //    Id = Id;
        //    Titolo = titolo;
        //    AmmontareOre = ammontareOre;
        //    CostoDiRiferimento = costoDiRiferimento;
        //    this.IdProgetto = idProgetto;
        //    this.IdLivello = idLivello;
        //    this.IdCategoria = idCategoria;
        //    InDBRepository dbr = new InDBRepository();
        //    Progetto = dbr.GetProgettobyId(idProgetto);
        //    Livello = dbr.GetLivellobyId(idLivello);
        //    Categoria = dbr.GetCategoriabyId(idCategoria);
        //    Descrizione = descrizione;
        //}
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
