using Esercizi.Model;

namespace Esercizi.Classes
{
    public class Modulo
    {
        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Ore { get; set; }
        public string  Descrizione { get; set; }
        public Persona Docente { get; set; }
        public EdizioneCorso Edizione { get; set; }
        #endregion

        public Modulo() { }
        public Modulo(int id, string nome, decimal ore, string descrizione,
            Persona docente, EdizioneCorso edizione)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ore = ore;
            this.Descrizione = descrizione;
            this.Docente = docente;
            this.Edizione = edizione;
        }

    }
}