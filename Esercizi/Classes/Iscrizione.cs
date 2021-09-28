using Esercizi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Iscrizione
    {
        #region Properties
        public int Id { get; set; }
        public DateTime DataIscrizione { get; set; }
        public string ValutazioneCorso { get; set; }
        public int VotoCorso { get; set; }
        public bool Pagata { get; set; }
        public Persona Persona { get; set; }
        public EdizioneCorso Edizione { get; set; }
        #endregion
        public Iscrizione() { }
        public Iscrizione(int id, DateTime dataIscrizione, string valutazione, int voto, bool pagata,
            Persona persona, EdizioneCorso edizione)
        {
            this.Id = id;
            this.DataIscrizione = dataIscrizione;
            this.ValutazioneCorso = valutazione;
            this.VotoCorso = voto;
            this.Pagata = pagata;
            this.Persona = persona;
            this.Edizione = edizione;
        }
    }
}
