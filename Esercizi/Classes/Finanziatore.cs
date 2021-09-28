using System;

namespace Esercizi.Classes
{
	public class Finanziatore
	{//checked
		#region Properties    
		public int Id { get; set; }
		public String Descrizione { get; set; }
		#endregion
		public Finanziatore() { }
		public Finanziatore(int id, String descrizione)
		{
			Id = id;
			Descrizione = descrizione;
		}
	}
}