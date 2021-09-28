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
        public Presenza Presenza { get; set; }
        public  Aula Aula { get; set; }
        public Corso Corso { get; set; }
        public Finanziatore Finanziatore { get; set; }

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
