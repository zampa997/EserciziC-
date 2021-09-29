using Esercizi.Model;
using Esercizi.Model.Data;

namespace Esercizi.Classes
{
    public class Modulo
    {//checked
        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Ore { get; set; }
        public string  Descrizione { get; set; }
        public Persona Docente { get; set; }
        public long IdDocente { get; set; }
        public EdizioneCorso Edizione { get; set; }
        public long IdEdizione { get; set; }
        #endregion
        #region Costructor
        public Modulo() { }
        //public Modulo(int id, string nome, decimal ore, string descrizione,
        //    Persona docente, EdizioneCorso edizione)
        //{
        //    this.Id = id;
        //    this.Nome = nome;
        //    this.Ore = ore;
        //    this.Descrizione = descrizione;
        //    this.Docente = docente;
        //    this.IdDocente = docente.Id;
        //    this.Edizione = edizione;
        //    this.IdEdizione = edizione.Id;
        //}
        //public Modulo(int id, string nome, decimal ore, string descrizione,
        //   long idDocente, EdizioneCorso edizione)
        //{
        //    this.Id = id;
        //    this.Nome = nome;
        //    this.Ore = ore;
        //    this.Descrizione = descrizione;
        //    this.IdDocente = idDocente;
        //    this.Edizione = edizione;
        //    this.IdEdizione = edizione.Id;
        //}
        //public Modulo(int id, string nome, decimal ore, string descrizione,
        //   Persona docente, long idEdizione)
        //{
        //    this.Id = id;
        //    this.Nome = nome;
        //    this.Ore = ore;
        //    this.Descrizione = descrizione;
        //    this.Docente = docente;
        //    this.IdDocente = docente.Id;
        //    this.IdEdizione = idEdizione;
        //}
        public Modulo(int id, string nome, decimal ore, string descrizione,
          long idDocente, long idEdizione)
        {
            InDBRepository dbr = new InDBRepository();
            this.Id = id;
            this.Nome = nome;
            this.Ore = ore;
            this.Descrizione = descrizione;
            this.IdDocente = idDocente;
            //this.Docente = dbr.getPersonabyId(idDocente);
            this.IdEdizione = idEdizione;
            this.Edizione = dbr.GetEditionbyId(idEdizione);
        }
        public Modulo(string nome, decimal ore, string descrizione,
         long idDocente, long idEdizione)
        {
            InDBRepository dbr = new InDBRepository();
            this.Nome = nome;
            this.Ore = ore;
            this.Descrizione = descrizione;
            this.IdDocente = idDocente;
            //this.Docente = dbr.getPersonabyId(idDocente);
            this.IdEdizione = idEdizione;
            this.Edizione = dbr.GetEditionbyId(idEdizione);
        }
        #endregion

    }
}