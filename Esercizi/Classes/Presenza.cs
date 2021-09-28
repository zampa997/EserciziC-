using System;

namespace Esercizi.Classes
{
    public class Presenza
    {//checked
        #region Properties
        public int Id { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Nota { get; set; }
        public Persona Persona { get; set; }
        public long IdPersona { get; set; }
        public Lezione Lezione { get; set; }
        public long IdLezione { get; set; }
        #endregion
        #region Costructor
        public Presenza() { }
        public Presenza(int id, DateTime inzio, DateTime fine, String nota,
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
        public Presenza(int id, DateTime inzio, DateTime fine, String nota,
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
        public Presenza(int id, DateTime inzio, DateTime fine, String nota,
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
        #endregion
    }
}