using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class EdizioneCorso
    {
        public long Id { get; set; }
        public string codiceEdizione { get; set; }
        public Corso Corso { get; set; }
        public LocalDate Start { get; set; }
        public LocalDate End { get; set; }
        public int NumStudents { get; set; }
        public decimal RealPrice { get; set; }
        public Report Report { get; set; }

        private Func<int> ad1; // input, void
        private Func<int, double> ad3; // input, output
        private Action<int> act1; // output
        private AddStudents ad;

        public EdizioneCorso(long id, Corso corso, LocalDate start, LocalDate end, int numStudents, decimal realPrice)
        {
            Id = id;
            Corso = corso;
            Start = start;
            End = end;
            NumStudents = numStudents;
            RealPrice = realPrice;
            ad += Iscrivi;
            Report = new Report();
        }

        public int Iscrivi()
        {
            return 10;
        }

        public void AggiornaEdizione()
        {
            NumStudents += ad();
        }
        public void ChangeAdder(AddStudents x)
        {
            ad = x;
        }
        public override string ToString()
        {
            return $"Id:{Id} | Titolo corso:{Corso.Titolo} | Data inizio:{Start} | Prezzo finale:{RealPrice}";
        }
    }

    public delegate int AddStudents(); // = func
    public delegate void EnrollStudents(int x);
}
