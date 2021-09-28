using Esercizi.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model.Data
{
    public interface IRepository
    {
        #region Corsi
        IEnumerable<Corso> GetCourses();
        Corso AddCourse(Corso c);
        Corso GetCourseById(long id);
        bool CourseExists(Corso c);
        #endregion
        #region Edizioni Corso
        IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId);
        EdizioneCorso AddEdition(EdizioneCorso e);
        Report GenerateStatisticalReport(long idCorso);
        #endregion
        #region Like a Virgin
        public Livello GetLivellobyId(long idLivello);
        public void SetLivello(Livello level);
        public Azienda GetAziendabyId(long idAzienda);
        public void SetAzienda(Azienda aziend);
        public Categoria GetCategoriabyId(long idCategoria);
        public void SetCategoria(Categoria categoria);
        public Aula GetAulabyId(long idAula);
        public void SetAula(Aula aula);
        public Finanziatore GetFinanziatorebyId(long idFinanziatore);
        public void SetFinanziatore(Finanziatore finanziatore);
        #endregion

    }
}
