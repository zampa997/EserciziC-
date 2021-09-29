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
            IRepository repo = new InDBRepository();
            Service cs = new Service(repo);
            UserInterface ui = new UserInterface(cs);
            //iniezione dipendenze
            ui.Start();
            
        }
        static decimal Extract(EdizioneCorso e)
        {
            return e.RealPrice;
        }
    }
}


