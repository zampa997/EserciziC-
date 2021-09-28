using Esercizi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Lezione
    {//checked
        #region Properties
        public int Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Descrizione { get; set; }
        public Aula AulaLezione { get; set; }
        public long IdAula { get; set; }
        public Modulo ModuloLezione { get; set; }
        public long IdModulo { get; set; }
        #endregion
        #region Costructor
        public Lezione() { }
        public Lezione(int id, DateTime inizio, DateTime fine, string descrizione,
            Aula aula, Modulo modulo)
        {
            this.Id = id;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.AulaLezione = aula;
            this.IdAula = aula.Id;
            this.ModuloLezione = modulo;
            this.IdModulo = modulo.Id;
        }
        public Lezione(int id, DateTime inizio, DateTime fine, string descrizione,
           long idAula, Modulo modulo)
        {
            this.Id = id;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.IdAula = idAula;
            this.ModuloLezione = modulo;
            this.IdModulo = modulo.Id;
        }
        public Lezione(int id, DateTime inizio, DateTime fine, string descrizione,
           Aula aula, long idModulo)
        {
            this.Id = id;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.AulaLezione = aula;
            this.IdAula = aula.Id;
            this.IdModulo = idModulo;
        }
        #endregion
    }
}
