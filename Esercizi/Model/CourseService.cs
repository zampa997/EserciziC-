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
            Corso found = Repository.FindById(idCorso); //=> entitynonfoundexp
            if (found == null)
            {
                return null;
            }
            e.Corso = found;
            if (Repository.AddEdition(e) == null)
            {
                return null;
            }
            Repository.AddEdition(e);
            return e;
        }
        public Report GenerateStatisticalReport(long idCorso) //=> in un solo giro linq
        {
            Corso found = Repository.FindById(idCorso);
            if (found == null)
            {
                return null;
            }
            IEnumerable <EdizioneCorso> editions = Repository.FindEditionsByCourses(idCorso);
            //report.NumEditions = editions.Count();
            //report.SumPrices = editions.Sum(e => e.RealPrice);
            //report.AveragePrice = report.SumPrices/report.NumEditions;
            //report.MedianPrice = CalculateMedianPrice(editions);
            //report.ModaPrice = editions.GroupBy(g => g.RealPrice).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            ////e100 e50 e50 e25 //100(1) 50(2) 25(1) //50(2) 100(1) 25(1) // 50 100 25 // => 50
            ////controllare se editions == null
            //report.NumeroMaxStudents = editions.Max(e => e.NumStudents);
            //report.NumeroMinStudents = editions.Min(e => e.NumStudents);
            EdizioneCorso r = editions.Aggregate((a, b) => 
            {
                a.Report.NumEditions = editions.Count();
                a.Report.SumPrices = editions.Sum(e => e.RealPrice);
                a.Report.AveragePrice = a.Report.SumPrices/a.Report.NumEditions;
                a.Report.MedianPrice = CalculateMedianPrice(editions);
                a.Report.ModaPrice = editions.GroupBy(g => g.RealPrice).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
                a.Report.NumeroMaxStudents = editions.Max(e => e.NumStudents);
                a.Report.NumeroMinStudents = editions.Min(e => e.NumStudents);
                return a;
            });
            //List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
            //var result = nums.Aggregate((a, b) => a + b);
            //var max = nums.Aggregate((a, b) => a > b? a: b);
            //var r = editions.Aggregate(new EditionsData(), (a, e) =>
            //{
            //    a.NumElements++;
            //    a.TotalPrice += e.RealPrice;
            //    return a;
            //});
            //var avg1 = r.TotalPrice / r.NumElements;
            //var avg2 = editions.Aggregate(new EditionsData(), (a, e) =>
            //{
            //    a.NumElements++;
            //    a.TotalPrice += e.RealPrice;
            //    return a;
            //}, a => a.TotalPrice/a.NumElements);
            return r.Report;
        }

        private decimal TempFunc(EdizioneCorso e)
        {
            return e.RealPrice;
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

    public class EditionsData
    {
        public decimal TotalPrice { get; set; }
        public int NumElements { get; set; }
    }

}
