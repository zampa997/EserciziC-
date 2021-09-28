using Esercizi.Classes;
using Esercizi.Model.Data;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class EdizioneCorso
    {
        #region Properties
        static long LastId = 0;
        public long Id { get; set; }        
        public string CodiceEdizione { get; set; }
        public LocalDate Start { get; set; }
        public LocalDate End { get; set; }
        public int NumStudents { get; set; }
        public decimal RealPrice { get; set; }
        public Aula Aula { get; set; }
        public long IdAula { get; set; }
        public Finanziatore Finanziatore { get; set; }
        public long IdFinanziatore { get; set; }
        public Corso Corso { get; set; }
        public long IdCorso { get; set; }
        #endregion
        #region Query

        #endregion
        #region Costructor

        public EdizioneCorso(string codice, Corso corso, LocalDate start, LocalDate end, 
            int numStudents, decimal realPrice, Aula aula, Finanziatore finanziatore)
        {
            this.Id = ++LastId; 
            this.CodiceEdizione = codice;
            this.Corso = corso;
            this.IdCorso = corso.Id;
            this.Start = start;
            this.End = end;
            this.NumStudents = numStudents;
            this.RealPrice = realPrice;
            this.Aula = aula;
            this.IdAula = aula.Id;
            this.Finanziatore = finanziatore;
            this.IdFinanziatore = finanziatore.Id;
        }
        public EdizioneCorso(string codice, Corso corso, LocalDate start, LocalDate end,
           int numStudents, decimal realPrice, long idAula, Finanziatore finanziatore)
        {
            this.Id = LastId++;
            this.CodiceEdizione = codice;
            this.Corso = corso;
            this.IdCorso = corso.Id;
            this.Start = start;
            this.End = end;
            this.NumStudents = numStudents;
            this.RealPrice = realPrice;
            this.IdAula = idAula;
            this.Finanziatore = finanziatore;
            this.IdFinanziatore = finanziatore.Id;
        }
        public EdizioneCorso(string codice, long idCorso, LocalDate start, LocalDate end,
           int numStudents, decimal realPrice, Aula aula, Finanziatore finanziatore)
        {
            this.Id = LastId++;
            this.CodiceEdizione = codice;
            this.IdCorso = idCorso;
            this.Start = start;
            this.End = end;
            this.NumStudents = numStudents;
            this.RealPrice = realPrice;
            this.Aula = aula;
            this.IdAula = aula.Id;
            this.Finanziatore = finanziatore;
            this.IdFinanziatore = finanziatore.Id;
        }
        public EdizioneCorso(string codice, Corso corso, LocalDate start, LocalDate end,
           int numStudents, decimal realPrice, Aula aula, long idFinanziatore)
        {
            this.Id = LastId++;
            this.CodiceEdizione = codice;
            this.Corso = corso;
            this.IdCorso = corso.Id;
            this.Start = start;
            this.End = end;
            this.NumStudents = numStudents;
            this.RealPrice = realPrice;
            this.Aula = aula;
            this.IdAula = aula.Id;
            this.IdFinanziatore = idFinanziatore;
        }
        public EdizioneCorso(string codice, long idCorso, LocalDate start, LocalDate end,
          int numStudents, decimal realPrice, long idAula, long idFinanziatore)
        {
            InDBRepository dbr = new InDBRepository();
            this.Id = LastId++;
            this.CodiceEdizione = codice;
            this.Start = start;
            this.End = end;
            this.NumStudents = numStudents;
            this.RealPrice = realPrice;
            this.Aula = dbr.GetAulabyId(idAula);
            this.IdAula = idAula;
            this.Finanziatore = dbr.GetFinanziatorebyId(idFinanziatore);
            this.IdFinanziatore = idFinanziatore;
            this.Corso = dbr.GetCourseById(idCorso);
            this.IdCorso = idCorso;
        }
        public EdizioneCorso() { }
        #endregion

        public override string ToString()
        {
            return $@"Id:{Id}
                    Titolo corso:{Corso.Titolo}
                    Data inizio:{Start}
                    Prezzo finale:{RealPrice}";
        }
        public static long GetLastId() 
        {
            return 0;
        }
    }
}
