using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Persona
    {
        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Gender { get; set; }
        public string CittaResidenza { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string PIva { get; set; }
        public string Ruolo { get; set; }
        public Azienda Azienda { get; set; }
        public long IdAzienda { get; set; }
        #endregion
        #region Costructor
        public Persona() { }
        public Persona(int id, DateTime dataNascita, string codiceFiscale, string gender,
            string cittaResidenza, string email, string telefono, string pIva, string ruolo, 
            Azienda azienda)
        {
            this.Id = id;
            this.DataNascita = dataNascita;
            this.CodiceFiscale = codiceFiscale;
            this.Gender = gender;
            this.CittaResidenza = cittaResidenza;
            this.Email = email;
            this.Telefono = telefono;
            this.PIva = pIva;
            this.Ruolo = ruolo;
            this.Azienda = azienda;
            this.IdAzienda = azienda.Id;
        }
        public Persona(int id, DateTime dataNascita, string codiceFiscale, string gender,
            string cittaResidenza, string email, string telefono, string pIva, string ruolo,
            long idAzienda)
        {
            this.Id = id;
            this.DataNascita = dataNascita;
            this.CodiceFiscale = codiceFiscale;
            this.Gender = gender;
            this.CittaResidenza = cittaResidenza;
            this.Email = email;
            this.Telefono = telefono;
            this.PIva = pIva;
            this.Ruolo = ruolo;
            this.IdAzienda = idAzienda;
        }
        #endregion

    }
}
