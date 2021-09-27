using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Esercizi.Model.Data
{
    public class InMemoryRepository : IRepository
    {
        private List<Corso> courses = new List<Corso>();
        private List<EdizioneCorso> courseEditions = new List<EdizioneCorso>();
        private ISet<Corso> courseSet = new HashSet<Corso>(); // => rifiuta duplicati | efficace in contains

        public InMemoryRepository()
        {
            Corso c = new Corso(345, "Matematica", 50, ExperienceLevel.PRINCIPIANTE, "molto bello", 19.99m);
            EdizioneCorso e = new EdizioneCorso(1, c, new LocalDate(2021,9,20), new LocalDate(2021, 9, 30), 12, 100);
            EdizioneCorso h = new EdizioneCorso(2, c, new LocalDate(2021, 9, 20), new LocalDate(2021, 9, 30), 12, 50);
            EdizioneCorso r = new EdizioneCorso(3, c, new LocalDate(2021, 9, 20), new LocalDate(2021, 9, 30), 12, 50);
            EdizioneCorso p = new EdizioneCorso(4, c, new LocalDate(2021, 9, 20), new LocalDate(2021, 9, 30), 12, 20);
            courseSet.Add(c);
            courseEditions.Add(e);
            courseEditions.Add(p);
            courseEditions.Add(h);
            courseEditions.Add(r);
        }

        public Corso AddCourse(Corso c)
        {
            bool added = courseSet.Add(c);
            return added ? c : null;
        }
        public EdizioneCorso AddEdition(EdizioneCorso e)
        {
            bool added = courseEditions.Any(x => x.Id == e.Id)?true:false;
            return added ? e : null;
        }

        public Corso FindById(long id)
        {
            return courseSet.Any(x => x.Id == id) ? courseSet.Single(x => x.Id == id) : null;
        }

        public Corso BetterFindById(long id)
        {
            //input => output
            return courseSet.Single(x => x.Id == id);
        }

        public IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId)
        {
            List<EdizioneCorso> editions = new List<EdizioneCorso>();
            return editions = (List<EdizioneCorso>)courseEditions.Where(x => x.Corso.Id == courseId);            
        }

        public IEnumerable<Corso> GetCourses()
        {
            return courseSet;
        }

        public Report GenerateStatisticalReport(long idCorso)
        {
            throw new NotImplementedException();
        }

        public bool CourseExists(Corso c)
        {
            throw new NotImplementedException();
        }
    }
}
