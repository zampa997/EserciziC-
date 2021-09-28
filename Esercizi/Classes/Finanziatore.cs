using System;

public class Finanziatore
{
	public Finanziatore()
	{
		public int Id { get; set; }
		public String Descrizione { get; set; }
		public String Tipo { get; set; }

    public Finanziatore (int id, String descrizione, String tipo)
    {
		Id = id;
		Descrizione = descrizione;
		Tipo = tipo;
	}
}
