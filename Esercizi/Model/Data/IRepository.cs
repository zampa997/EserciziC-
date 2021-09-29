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
        Corso SetCourse(Corso c);
        Corso GetCourseById(long id);
        bool CourseExists(Corso c);
        #endregion
        #region Edizioni Corso
        IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId);
        EdizioneCorso SetEdition(EdizioneCorso e);
        EdizioneCorso GetEditionbyId(long id);
        Report GenerateStatisticalReport(long idCorso);
        #endregion
        #region Like a Virgin
        public Livello GetLivellobyId(long idLivello);
        public Livello SetLivello(Livello level);
        public Azienda GetAziendabyId(long idAzienda);
        public Azienda SetAzienda(Azienda aziend);
        public Categoria GetCategoriabyId(long idCategoria);
        public Categoria SetCategoria(Categoria categoria);
        public Aula GetAulabyId(long idAula);
        public Aula SetAula(Aula aula);
        public Finanziatore GetFinanziatorebyId(long idFinanziatore);
        public Finanziatore SetFinanziatore(Finanziatore finanziatore);
        public Progetto GetProgettobyId(long idProgetto);
        public Progetto SetProgetto(Progetto progetto);
        #endregion

    }
}
