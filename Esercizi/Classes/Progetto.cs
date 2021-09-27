using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Progetto
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Tipo { get; set; }
        public Azienda Azienda { get; set; }

        public Progetto(int id, string descrizione, string tipo, Azienda azienda)
        {
            Id = id;
            Descrizione = descrizione;
            Azienda = azienda;
        }
    }
}
