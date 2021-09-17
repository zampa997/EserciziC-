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

        public InMemoryRepository()
        {
            Corso c = new Corso(345, "Matematica", 50, ExperienceLevel.PRINCIPIANTE, "molto bello", 19.99m);
            EdizioneCorso e = new EdizioneCorso(1, c, new LocalDate(2021,9,20), new LocalDate(2021, 9, 30), 12, 100);
            courses.Add(c);
            courseEditions.Add(e);
        }

        public Corso AddCourse(Corso c)
        {
            if (courses.Contains(c))
            {
                return null;
            }
            courses.Add(c);
            return c;
       
        }
        public EdizioneCorso AddEdition(EdizioneCorso e)
        {
            courseEditions.Add(e);
            return e;
        }

        public Corso FindById(long id)
        {
            foreach(var c in courses)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public Corso BetterFindById(long id)
        {
                                                //input => output
            return courses.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<EdizioneCorso> FindEditionsByCourses(long courseId)
        {
            List<EdizioneCorso> editions = new List<EdizioneCorso>();

            foreach (var ed in courseEditions)
            {
                if (ed.Corso.Id == courseId)
                {
                    editions.Add(ed);
                }
            }

            return editions;
        }

        public IEnumerable<Corso> GetCourses()
        {
            return courses;
        }
    }
}
