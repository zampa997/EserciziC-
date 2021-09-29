using Esercizi.Model.Data;
using NodaTime;
using System;

namespace Esercizi.Classes
{
    public class Presenza
    {//checked
        #region Properties
        public int Id { get; set; }
        public LocalDate Inizio { get; set; }
        public LocalDate Fine { get; set; }
        public string Nota { get; set; }
        public Persona Persona { get; set; }
        public long IdPersona { get; set; }
        public Lezione Lezione { get; set; }
        public long IdLezione { get; set; }
        #endregion
        #region Costructor
        public Presenza() { }
        public Presenza(int id, LocalDate inzio, LocalDate fine, String nota,
            Persona persona, Lezione lezione)
        {
            Id = id;
            Inizio = inzio;
            Fine = fine;
            Nota = nota;
            Persona = persona;
            this.IdPersona = persona.Id;
            Lezione = lezione;
            this.IdLezione = lezione.Id;
        }
        public Presenza(int id, LocalDate inzio, LocalDate fine, String nota,
           long idPersona, Lezione lezione)
        {
            Id = id;
            Inizio = inzio;
            Fine = fine;
            Nota = nota;
            this.IdPersona = idPersona;
            Lezione = lezione;
            this.IdLezione = lezione.Id;
        }
        public Presenza(int id, LocalDate inzio, LocalDate fine, String nota,
           Persona persona, long idLezione)
        {
            Id = id;
            Inizio = inzio;
            Fine = fine;
            Nota = nota;
            Persona = persona;
            this.IdPersona = persona.Id;
            this.IdLezione = idLezione;
        }
        public Presenza(int id, LocalDate inzio, LocalDate fine, String nota,
          long idPersona, long idLezione)
        {
            InDBRepository dbr = new InDBRepository();
            Id = id;
            Inizio = inzio;
            Fine = fine;
            Nota = nota;
            this.IdPersona = idPersona;
            //this.Persona = dbr.getPersonabyId(idPersona);
            this.IdLezione = idLezione;
            //this.Lezione = dbr.getLezionebyId(idLezione);
        }
        public Presenza(LocalDate inzio, LocalDate fine, String nota,
         long idPersona, long idLezione)
        {
            InDBRepository dbr = new InDBRepository();
            Inizio = inzio;
            Fine = fine;
            Nota = nota;
            this.IdPersona = idPersona;
            //this.Persona = dbr.getPersonabyId(idPersona);
            this.IdLezione = idLezione;
            //this.Lezione = dbr.getLezionebyId(idLezione);
        }
        #endregion
    }
}