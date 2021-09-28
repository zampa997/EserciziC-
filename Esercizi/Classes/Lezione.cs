using Esercizi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Lezione
    {
        #region Properties
        public int Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Descrizione { get; set; }
        public Aula AulaLezione { get; set; }
        public EdizioneCorso Edizione { get; set; }
        public Modulo ModuloLezione { get; set; }
        public Presenza Presenza { get; set; }
        #endregion

        public Lezione() { }
        public Lezione(int id, DateTime inizio, DateTime fine, string descrizione,
            Aula aula, EdizioneCorso edizione, Modulo modulo, Presenza presenza)
        {
            this.Id = id;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.AulaLezione = aula;
            this.Edizione = edizione;
            this.ModuloLezione = modulo;
            this.Presenza = presenza;
        }
    }
}
