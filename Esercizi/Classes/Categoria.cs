using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Categoria
    { //checked
        #region Properties
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Argomento { get; set; }
        #endregion
        #region Costructor
        public Categoria(int id, string descrizione, string argomento)
        {
            Id = id;
            Descrizione = descrizione;
            Argomento=argomento;
        }
        public Categoria(string descrizione, string argomento)
        {
            Descrizione = descrizione;
            Argomento = argomento;
        }
        public Categoria() { }
        #endregion
    }
}
