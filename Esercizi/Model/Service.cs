using Esercizi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Service
    {
        public IRepository Repository { get; set; }

        public Service(IRepository repo)
        {
            Repository = repo;
        }
        public IEnumerable<Corso> GetAllCourses()
        {
            return Repository.GetCourses();
        }
        public IEnumerable<EdizioneCorso> GetCourseEditionsbyCourse(long id)
        {
            return Repository.FindEditionsByCourses(id);
        }
        public Corso CreateCourse(Corso c)
        {
            return Repository.SetCourse(c);
        }
        public EdizioneCorso CreateCourseEdition(EdizioneCorso e, long idCorso)
        {
            Corso found = Repository.GetCourseById(idCorso);
            EdizioneCorso editionFond = Repository.SetEdition(e);
            return found == null | editionFond == null ? null : e;
        }

    }
}
