using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Livello
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public tipo Tipo { get; set; }

        public Livello(int id, string descrizione, string tipo)
        {
            Id = id;
            Descrizione = descrizione;
            Tipo = Tipo;
        }
        public enum tipo
        {
            PRINCIPIANTE,
            MEDIO,
            ESPERTO,
            GURU
        }
    }
}
