using Esercizi.Model;
using Esercizi.Model.Data;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Iscrizione
    {//checked
        #region Properties
        public int Id { get; set; }
        public LocalDate DataIscrizione { get; set; }
        public string ValutazioneCorso { get; set; }
        public int VotoCorso { get; set; }
        public bool Pagata { get; set; }
        public Persona Persona { get; set; }
        public long IdPersona { get; set; }
        public EdizioneCorso Edizione { get; set; }
        public long IdEdizione { get; set; }
        #endregion
        #region costructor
        public Iscrizione() { }
        //public Iscrizione(int id, LocalDate dataIscrizione, string valutazione, int voto, bool pagata,
        //    Persona persona, EdizioneCorso edizione)
        //{
        //    this.Id = id;
        //    this.DataIscrizione = dataIscrizione;
        //    this.ValutazioneCorso = valutazione;
        //    this.VotoCorso = voto;
        //    this.Pagata = pagata;
        //    this.Persona = persona;
        //    this.IdPersona = persona.Id;
        //    this.Edizione = edizione;
        //    this.IdEdizione = edizione.Id;
        //}
        //public Iscrizione(int id, LocalDate dataIscrizione, string valutazione, int voto, bool pagata,
        //   long idPersona, EdizioneCorso edizione)
        //{
        //    this.Id = id;
        //    this.DataIscrizione = dataIscrizione;
        //    this.ValutazioneCorso = valutazione;
        //    this.VotoCorso = voto;
        //    this.Pagata = pagata;
        //    this.IdPersona = idPersona;
        //    this.Edizione = edizione;
        //    this.IdEdizione = edizione.Id;
        //}
        //public Iscrizione(int id, LocalDate dataIscrizione, string valutazione, int voto, bool pagata,
        //   Persona persona, long idEdizione)
        //{
        //    this.Id = id;
        //    this.DataIscrizione = dataIscrizione;
        //    this.ValutazioneCorso = valutazione;
        //    this.VotoCorso = voto;
        //    this.Pagata = pagata;
        //    this.Persona = persona;
        //    this.IdPersona = persona.Id;
        //    this.IdEdizione = idEdizione;
        //}
        public Iscrizione(int id, LocalDate dataIscrizione, string valutazione, int voto, bool pagata,
           long idPersona, long idEdizione)
        {
            InDBRepository dbr = new InDBRepository();
            this.Id = id;
            this.DataIscrizione = dataIscrizione;
            this.ValutazioneCorso = valutazione;
            this.VotoCorso = voto;
            this.Pagata = pagata;
            this.IdPersona = idPersona;
            //this.Persona = dbr.getPersonabyId(idPersona);
            this.IdEdizione = idEdizione;
            //this.Edizione = dbr.getEditionbyId(idEdizione);
        }
        public Iscrizione(LocalDate dataIscrizione, string valutazione, int voto, bool pagata,
          long idPersona, long idEdizione)
        {
            InDBRepository dbr = new InDBRepository();
            this.DataIscrizione = dataIscrizione;
            this.ValutazioneCorso = valutazione;
            this.VotoCorso = voto;
            this.Pagata = pagata;
            this.IdPersona = idPersona;
            //this.Persona = dbr.getPersonabyId(idPersona);
            this.IdEdizione = idEdizione;
            //this.Edizione = dbr.getEditionbyId(idEdizione);
        }
        #endregion
    }
}
