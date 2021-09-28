using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Progetto
    {
        #region Properties
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public Azienda Azienda { get; set; }
        public long IdAzienda { get; set; }
        #endregion
        #region Costructor
        public Progetto(int id, string descrizione, 
            Azienda azienda)
        {
            Id = id;
            Descrizione = descrizione;
            Azienda = azienda;
            this.IdAzienda = azienda.Id;
        }
        public Progetto(int id, string descrizione,
           long idAzienda)
        {
            Id = id;
            Descrizione = descrizione;
            this.IdAzienda = idAzienda;
        }
        public Progetto() {}
        #endregion
    }
}
