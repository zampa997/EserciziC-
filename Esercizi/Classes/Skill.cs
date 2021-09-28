using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Skill
    {
        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Categoria Categoria { get; set; }
        #endregion

        public Skill() { }
        public Skill(int id, string nome, string descrizione, 
            Categoria categoria)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Categoria = categoria;
        }
    }
}
