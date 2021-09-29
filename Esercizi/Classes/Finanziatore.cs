using System;

namespace Esercizi.Classes
{
	public class Finanziatore
	{//checked
		#region Properties    
		public long Id { get; set; }
		public String Descrizione { get; set; }
        #endregion
        #region Costructor

        public Finanziatore() { }
		public Finanziatore(String descrizione)
		{
			Descrizione = descrizione;
		}
		public Finanziatore(long id, String descrizione)
		{
			this.Id = id;
			Descrizione = descrizione;
		}
		#endregion
	}
}