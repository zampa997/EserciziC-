using Esercizi.Classes;
using Esercizi.Model.Data;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Esercizi.Model
{
    public class UserInterface
    {
        public Service Service { get; set; }
        private InDBRepository dbr = new InDBRepository();

        const string DIVISORE = "==============================================================";
        const string MAIN_MENU = @"Operazioni disponibili, inserisci:
                                    a per vedere tutti i corsi
                                    c per aggiungere un corso
                                    e per cercare le edizioni di un corso
                                    b per inserire un edizione di un corso
                                    r per creare un report
                                    q per terminare il programma";
        const string BASE_PROMPT = "=>";

        public UserInterface(Service service)
        {
            this.Service = service;
        }

        public void Start()
        {

            //Nuovo caso: l'utente inserisce l'id di un corso e il programma risponde mostrando il numero di edizioni che esistono del corso, la somma dei prezzi delle edizioni, il valore medio del prezzo odelle edizioni
            //la mediana del prezzo delle edizioni, la moda dei prezzi delle edizioni, numero max studenti e numero min studenti
            //OUTPUT => n-edizioni | somma prezzi | media prezzi | mediana prezzi | moda prezzi | n-max studenti | n-min studenti           
            bool quit = false;
            do
            {
                WriteLine(DIVISORE);
                WriteLine(MAIN_MENU);
                char c = ReadChar(BASE_PROMPT);
                switch (c)
                {
                    case 'a':
                        ShowCourses();
                        break;
                    case 'c':
                        CreateCourse();
                        break;
                    case 'b':
                        CreateCourseEdition();
                        break;
                    //case 'r':
                    //    GenerateReport();
                    //    break;
                    case 'e':
                        ShowCourseEditionsByCourse();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        WriteLine("Comando non riconoscuto");
                        break;
                }
            }
            while (!quit);
        }

        //private void GenerateReport()
        //{
        //    long id = ReadLong("Inserire Id corso per generare un report =>");
        //    Report r = CourseService.GenerateStatisticalReport(id);
        //    WriteLine(DIVISORE);
        //    WriteLine($"Numero edizioni: {r.NumEditions} \nSomma dei prezzi: {r.SumPrices} \nMedia dei prezzi: {r.AveragePrice} \nMediana dei prezzi: {r.MedianPrice} \nModa dei prezzi: {r.ModaPrice} \nNumero massimo studenti: {r.NumeroMaxStudents} \nNumero minimo studenti: {r.NumeroMinStudents}");
        //}

        private EdizioneCorso CreateCourseEdition()
        {
            EdizioneCorso output;
            long idCorso = 0;
            long idAula = 0;
            long idFinanziatore = 0;
            do
            {
                idCorso = ReadLong("Inserire Id del corso =>");
            } while (dbr.GetCourseById(idCorso) == null);
            string code = ReadString("Inserire codice Edizione =>");
            LocalDate start = ReadLocalDate("Inserire data di inizio corso (yyyy-mm-dd) =>");
            LocalDate end = ReadLocalDate("Inserire data di fine corso (yyyy-mm-dd) =>");
            int numStudents = (int)ReadLong("Inserire numero studenti =>");
            decimal realPrice = ReadDecimal("Inserire prezzo finale edizione corso =>");
            do
            {
                idAula = ReadLong("Inserire Id dell'aula =>");
            } while (dbr.GetAulabyId(idAula) == null);
            do
            {
                idFinanziatore = ReadLong("Inserire Id del finanziatore =>");
            } while (dbr.GetFinanziatorebyId(idFinanziatore) == null);
            // var edition = new EdizioneCorso(id, null, start, end, numStudents, realPrice);            
            output=new EdizioneCorso(code, idCorso, start, end, numStudents, realPrice, idAula, idFinanziatore);
            Service.CreateCourseEdition(output, idCorso);
            return output;
        }

        private void ShowCourseEditionsByCourse()
        {
            long id = ReadLong("Inserire Id corso =>");
            IEnumerable<EdizioneCorso> editions = Service.GetCourseEditionsbyCourse(id);
            WriteLine(DIVISORE);
            foreach (var c in editions)
            {
                WriteLine(c.ToString());
            }
        }

        private Corso CreateCourse()
        {
            Corso c = null ;
            long idLivello = 0;
            string titolo = ReadString("Inserire Titolo =>");
            string descrizione = ReadString("Inserire Descrizione =>");
            do
            {
                idLivello = ReadLong(@"Inserire Livello del corso: 1.PRINCIPIANTE
                                                                   2.MEDIO
                                                                   3.ESPERTO
                                                                   4.GURU =>");
            } while (idLivello > 5 || idLivello < 1);

            long idProgetto=0;
            long idCategoria;
            do
            {                
                idProgetto = ReadLong("Inserire l'Id del progetto =>");
            } while (dbr.GetProgettobyId(idProgetto) == null);
            do
            {
                idCategoria = ReadLong("Inserire l'Id della Categoria =>");
            } while (dbr.GetCategoriabyId(idCategoria) == null);
            int durataCorso = (int)ReadLong("Inserire Durata del corso =>");
            decimal prezzoCorso = ReadDecimal("Inserire Prezzo corso =>");
            c = new Corso(titolo, durataCorso, prezzoCorso,
                    idLivello, idProgetto, idCategoria, descrizione);
            WriteLine(DIVISORE);

            return Service.CreateCourse(c);
        
        }

        private void ShowCourses()
        {
            IEnumerable<Corso> courses = Service.GetAllCourses();
            WriteLine(DIVISORE);
            foreach (var c in courses)
            {
                WriteLine(c.ToString());
            }
        }

        private LocalDate ReadLocalDate(string prompt)
        {
            bool success = false;
            LocalDate date = new LocalDate(2021, 01, 01);
            do
            {
                string answer = ReadString(prompt);
                try
                {
                    success = TryParse(answer, out date);
                }
                catch(UnparsableValueException ex)
                {
                    success = false;
                    WriteLine("Formato errato, inserire una data nel formato yyyy-MM-dd");
                }
                
            }
            while (!success);
            return date;
        }

        private bool TryParse(string input, out LocalDate date)
        {            
            var pattern = LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd"); // => DA GESTIRE
            var parseResult = pattern.Parse(input);
            date = parseResult.GetValueOrThrow();                   
            return true;           
        }

        private string ReadString(string prompt)
        {
            string answer = null;
            do
            {
                Write(prompt);
                answer = ReadLine().Trim();
                if (string.IsNullOrEmpty(answer))
                {
                    WriteLine("Devi inserire almeno un carattere");
                }
            }
            while (string.IsNullOrEmpty(answer));
            return answer;
        }

        private char ReadChar(string prompt)
        {
            return ReadString(prompt)[0];
        }

        private long ReadLong(string prompt)
        {
            bool isNumber = false;
            long num;
            do
            {
                string answer = ReadString(prompt);
                isNumber = long.TryParse(answer, out num);
                if(!isNumber)
                {
                    WriteLine("Devi inserire un numero =>");
                }
            }
            while (!isNumber);
            return num;
        }

        private decimal ReadDecimal(string prompt)
        {
            bool isNumber = false;
            decimal num;
            do
            {
                string answer = ReadString(prompt);
                isNumber = decimal.TryParse(answer, out num);
                if (!isNumber)
                {
                    WriteLine("Devi inserire un numero =>");
                }
            }
            while (!isNumber);
            return num;
        }
    }
}
