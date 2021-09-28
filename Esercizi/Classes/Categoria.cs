using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Categoria
    { // checked
        #region Properties
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Tipo { get; set; }
        #endregion
        public Categoria(int id, string descrizione, string tipo)
        {
            Id = id;
            Descrizione = descrizione;
            Tipo = tipo;
        }
        public Categoria() { }
    }
}
