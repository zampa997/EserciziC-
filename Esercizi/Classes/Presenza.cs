using System;

public class Presenza
{
	public Presenza()
	{
	    public int Id { get; set; }
	    public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public String Nota  { get; set; }
        public Persona Persona { get; set; }
        public Lezione Lezione { get; set; }

        public Presenza (int id, DateTime inzio, DateTime fine , String nota , Persona persona , Lezione lezione)
        {
            Id = id;
            Inizio = inzio;
            Fine = fine;
            Nota = nota;
            Persona = persona;
            Lezione = lezione;
        }

    }
}
