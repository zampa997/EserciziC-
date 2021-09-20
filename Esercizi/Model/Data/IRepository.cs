using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model.Data
{
    public interface IRepository
    {
        IEnumerable<Corso> GetCourses();
        Corso AddCourse(Corso c);
        IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId);
        EdizioneCorso AddEdition(EdizioneCorso e);
        Corso FindById(long id);
        Report GenerateStatisticalReport(long idCorso);
        bool CourseExists(Corso c);
    }
}
