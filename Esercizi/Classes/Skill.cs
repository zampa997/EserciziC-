using Esercizi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Classes
{
    public class Skill
    {//checked
        #region Properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Categoria Categoria { get; set; }
        public long IdCategoria { get; set; }
        #endregion
        #region Costructor
        public Skill() { }
        public Skill(int id, string nome, string descrizione,
            Categoria categoria)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Categoria = categoria;
            this.IdCategoria = categoria.Id;
        }
        public Skill(int id, string nome, string descrizione,
           long idCategoria)
        {
            InDBRepository dbr = new InDBRepository();
            this.Id = id;
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.IdCategoria = idCategoria;
            this.Categoria = dbr.GetCategoriabyId(idCategoria);
        }
        public Skill(string nome, string descrizione,
          long idCategoria)
        {
            InDBRepository dbr = new InDBRepository();
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.IdCategoria = idCategoria;
            this.Categoria = dbr.GetCategoriabyId(idCategoria);
        }
        #endregion
    }
}
