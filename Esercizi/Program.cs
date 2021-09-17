using Esercizi.Model;
using Esercizi.Model.Data;
using System;

namespace Esercizi
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new InMemoryRepository();
            CourseService cs = new CourseService(repo);
            UserInterface ui = new UserInterface(cs);
            //iniezione dipendenze
            ui.Start();
        }
    }
}
