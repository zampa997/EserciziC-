using Esercizi.Model;
using Esercizi.Model.Data;
using NodaTime;
using System;

namespace Esercizi
{
    class Program
    {
        static void Main(string[] args)
        {
            //IRepository repo = new InMemoryRepository();
            //CourseService cs = new CourseService(repo);
            //UserInterface ui = new UserInterface(cs);
            ////iniezione dipendenze
            //ui.Start();
            //EdizioneCorso ed = new EdizioneCorso(3, null, new LocalDate(2021, 9, 20), new LocalDate(2021, 9, 30), 12, 50);
            //Console.WriteLine(ed.NumStudents);
            //ed.AggiornaEdizione();
            //Console.WriteLine(ed.NumStudents);
            //ed.ChangeAdder(Enroll); // new AddStudents(Enroll)
            //ed.ChangeAdder(() => 200);
            //ed.AggiornaEdizione();
            //Console.WriteLine(ed.NumStudents);

            //Func<int> myFunc = Enroll;
            //Func<int> myFunc2 = new Func<int>(Enroll);           
            //AddStudents ads = new AddStudents(Enroll);

            //int x = 4;
            //G(29);
            //G(x);
            //Func<EdizioneCorso, decimal> FF = e => e.RealPrice;
            //GG(Extract);
            //GG(e => e.RealPrice);
        }
        static void G(int y)
        {

        }
        static void GG(Func<EdizioneCorso, decimal> f)
        {

        }
        static decimal Extract(EdizioneCorso e)
        {
            return e.RealPrice;
        }
        static int Enroll()
        {
            return 20;
        }
    }
}


