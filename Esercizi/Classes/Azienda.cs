using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Azienda
    { //checked
        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public string Cap { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string PartitaIva { get; set; }
        #endregion
        #region Costructor
        public Azienda(int id, string nome, string citta, string indirizzo, 
            string cap, string telefono, string email, string partitaIva)
        {
            Id = id;
            Nome = nome;
            Citta = citta;
            Indirizzo = indirizzo;
            Cap = cap;
            Telefono = telefono;
            Email = email;
            PartitaIva = partitaIva;
        }
        public Azienda(string nome, string citta, string indirizzo,
           string cap, string telefono, string email, string partitaIva)
        {
            Nome = nome;
            Citta = citta;
            Indirizzo = indirizzo;
            Cap = cap;
            Telefono = telefono;
            Email = email;
            PartitaIva = partitaIva;
        }
        #endregion
    }
}
