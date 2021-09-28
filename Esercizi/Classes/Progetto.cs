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
        public string Tipo { get; set; }
        public Azienda Azienda { get; set; }
        #endregion

        public Progetto(int id, string descrizione, string tipo, 
            Azienda azienda)
        {
            Id = id;
            Descrizione = descrizione;
            Azienda = azienda;
        }
        public Progetto() { }
    }
}
