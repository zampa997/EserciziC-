using Esercizi.Model;
using Esercizi.Model.Data;

namespace Esercizi.Classes
{
    public class Competenza
    { //checked
        #region Properties
        public int Id { get; set; }
        public string Note { get; set; }
        public Persona Persona { get; set; }
        public long IdPersona { get; set; }
        public Skill Skill { get; set; }
        public long IdSkill { get; set; }
        public Livello Livello { get; set; }
        public long IdLivello { get; set; }
        #endregion
        #region Costructor

        public Competenza() { }
        //public Competenza(int id, string note,
        //    Persona persona, Skill skill, Livello livello)
        //{
        //    this.Id = id;
        //    this.Note = note;
        //    this.Persona = persona;
        //    this.IdPersona = persona.Id;
        //    this.Skill = skill;
        //    this.IdSkill = skill.Id;
        //    this.Livello = livello;
        //    this.IdLivello = livello.Id;
        //}
        //public Competenza(int id, string note,
        //   long idPersona, Skill skill, Livello livello)
        //{
        //    this.Id = id;
        //    this.Note = note;
        //    this.IdPersona = idPersona;
        //    this.Skill = skill;
        //    this.IdSkill = skill.Id;
        //    this.Livello = livello;
        //    this.IdLivello = livello.Id;
        //}
        //public Competenza(int id, string note,
        //   Persona persona, long idSkill, Livello livello)
        //{
        //    this.Id = id;
        //    this.Note = note;
        //    this.Persona = persona;
        //    this.IdPersona = persona.Id;
        //    this.IdSkill = idSkill;
        //    this.Livello = livello;
        //    this.IdLivello = livello.Id;
        //}
        //public Competenza(int id, string note,
        //    Persona persona, Skill skill, long idLivello)
        //{
        //    this.Id = id;
        //    this.Note = note;
        //    this.Persona = persona;
        //    this.IdPersona = persona.Id;
        //    this.Skill = skill;
        //    this.IdSkill = skill.Id;
        //    this.IdLivello = idLivello;
        //}
        public Competenza(int id, string note,
            long idPersona, long idSkill, long idLivello)
        {
            InDBRepository dbr = new InDBRepository();
            this.Id = id;
            this.Note = note;
            this.IdPersona = idPersona;
            this.IdSkill = idSkill;
            this.IdLivello = idLivello;
            //this.Persona = dbr.getPersonabyid;
            //this.Skill = dbr.getSkillbyId;
            //this.Livello = dbr.getLivellobyId;
        }
        #endregion
    }
}