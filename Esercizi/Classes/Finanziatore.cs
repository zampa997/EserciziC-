using System;

namespace Esercizi.Classes
{
	public class Finanziatore
	{
		#region Properties    
		public int Id { get; set; }
		public String Descrizione { get; set; }
		public String Tipo { get; set; }
		#endregion
		public Finanziatore() { }
		public Finanziatore(int id, String descrizione, String tipo)
		{
			Id = id;
			Descrizione = descrizione;
			Tipo = tipo;
		}
	}
}