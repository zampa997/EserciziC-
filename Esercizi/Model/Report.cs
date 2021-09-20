using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Report
    {
        public int NumEditions { get; set; }
        public decimal SumPrices { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MedianPrice { get; set; }
        public decimal ModaPrice { get; set; }
        public int NumeroMaxStudents { get; set; }
        public int NumeroMinStudents { get; set; }
        public List<decimal> prices { get; set; }

        public Report(int numEditions, decimal sumPrices, decimal averagePrice, decimal medianPrice, decimal modaPrice, int numeroMaxStudents, int numeroMinStudents)
        {
            NumEditions = numEditions;
            SumPrices = sumPrices;
            AveragePrice = averagePrice;
            MedianPrice = medianPrice;
            ModaPrice = modaPrice;
            NumeroMaxStudents = numeroMaxStudents;
            NumeroMinStudents = numeroMinStudents;

        }
        public Report()
        {

        }
    }
}
