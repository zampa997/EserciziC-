using Esercizi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Esercizi.Model
{
    public class CourseService
    {
        public IRepository Repository { get; set; }

        public CourseService(IRepository repo)
        {
            Repository = repo;
        }

        public IEnumerable<Corso> GetAllCourses()
        {
            return Repository.GetCourses();
        }
        public Corso CreateCourse(Corso c)
        {
            return Repository.AddCourse(c);
        }
        public IEnumerable<EdizioneCorso> GetCourseEditions(long id)
        {
            return Repository.FindEditionsByCourses(id);
        }
        public EdizioneCorso CreateCourseEdition(EdizioneCorso e, long idCorso)
        {
            Corso found = Repository.FindById(idCorso);
            if (found == null)
            {
                return null;
            }
            e.Corso = found;
            Repository.AddEdition(e);
            return e;
        }
        public Report GenerateStatisticalReport(long idCorso)
        {
            Corso found = Repository.FindById(idCorso);
            Report report = new Report();
            if (found == null)
            {
                return null;
            }
            IEnumerable <EdizioneCorso> editions = Repository.FindEditionsByCourses(idCorso);
            report.NumEditions = editions.Count();
            report.SumPrices = editions.Sum(e => e.RealPrice);
            report.AveragePrice = report.SumPrices/report.NumEditions;
            report.MedianPrice = CalculateMedianPrice(editions);
            //report.ModaPrice => usa Dictionary!
        }

        private decimal CalculateMedianPrice(IEnumerable<EdizioneCorso> editions)
        {
            var prices = editions.Select(e => e.RealPrice).OrderBy(r => r).ToList();
            if(prices.Count % 2!=0)
            {
               return prices[(prices.Count / 2)];
            }
            return (prices[prices.Count/2]+prices[prices.Count/2-1]) / 2;
        }
    }
}
