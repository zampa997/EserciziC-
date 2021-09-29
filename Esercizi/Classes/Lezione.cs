using Esercizi.Model;
using Esercizi.Model.Data;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Lezione
    {//checked but no checked
        #region Properties
        public int Id { get; set; }
        public LocalDate Inizio { get; set; }
        public LocalDate Fine { get; set; }
        public string Descrizione { get; set; }
        public Aula AulaLezione { get; set; }
        public long IdAula { get; set; }
        public Modulo ModuloLezione { get; set; }
        public long IdModulo { get; set; }
        #endregion
        #region Costructor
        public Lezione() { }
        //public Lezione(int id, LocalDate inizio, LocalDate fine, string descrizione,
        //    Aula aula, Modulo modulo)
        //{
        //    this.Id = id;
        //    this.Inizio = inizio;
        //    this.Fine = fine;
        //    this.Descrizione = descrizione;
        //    this.AulaLezione = aula;
        //    this.IdAula = aula.Id;
        //    this.ModuloLezione = modulo;
        //    this.IdModulo = modulo.Id;
        //}
        //public Lezione(int id, LocalDate inizio, LocalDate fine, string descrizione,
        //   long idAula, Modulo modulo)
        //{
        //    this.Id = id;
        //    this.Inizio = inizio;
        //    this.Fine = fine;
        //    this.Descrizione = descrizione;
        //    this.IdAula = idAula;
        //    this.ModuloLezione = modulo;
        //    this.IdModulo = modulo.Id;
        //}
        //public Lezione(int id, LocalDate inizio, LocalDate fine, string descrizione,
        //   Aula aula, long idModulo)
        //{
        //    this.Id = id;
        //    this.Inizio = inizio;
        //    this.Fine = fine;
        //    this.Descrizione = descrizione;
        //    this.AulaLezione = aula;
        //    this.IdAula = aula.Id;
        //    this.IdModulo = idModulo;
        //}
        public Lezione(int id, LocalDate inizio, LocalDate fine, string descrizione,
           long idAula, long idModulo)
        {
            InDBRepository dbr = new InDBRepository();
            this.Id = id;
            this.Inizio = inizio;
            this.Fine = fine;
            this.Descrizione = descrizione;
            this.IdAula = idAula;
            this.AulaLezione = dbr.GetAulabyId(idAula);
            this.IdModulo = idModulo;
            //this.ModuloLezione = dbr.GetModulobyId(idModulo);
        }

        #endregion
    }
}
