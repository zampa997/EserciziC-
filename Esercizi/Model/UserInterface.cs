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
        public CourseService CourseService { get; set; }
        const string DIVISORE = "==============================================================";
        const string MAIN_MENU = "Operazioni disponibili: inserisci\na per vedere tutti i corsi\nc per aggiungere un corso\ne per cercare le edizioni di un corso\nb per inserire un edizione di un corso\nr per creare un report\nq per terminare il programma";
        const string BASE_PROMPT = "=>";

        public UserInterface(CourseService service)
        {
            CourseService = service;
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
                    case 'r':
                        GenerateReport();
                        break;
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

        private void GenerateReport()
        {
            long id = ReadLong("Inserire Id corso per generare un report =>");
            Report r = CourseService.GenerateStatisticalReport(id);
            WriteLine(DIVISORE);
            WriteLine($"Numero edizioni: {r.NumEditions} \nSomma dei prezzi: {r.SumPrices} \nMedia dei prezzi: {r.AveragePrice} \nMediana dei prezzi: {r.MedianPrice} \nModa dei prezzi: {r.ModaPrice} \nNumero massimo studenti: {r.NumeroMaxStudents} \nNumero minimo studenti: {r.NumeroMinStudents}");
        }

        private void CreateCourseEdition()
        {
            long id = ReadLong("Inserire Id edizione corso =>");
            long idCorso = ReadLong("Inserire Id del corso =>");
            LocalDate start = ReadLocalDate("Inserire data di inizio corso (yyyy-mm-dd) =>");
            LocalDate end = ReadLocalDate("Inserire data di fine corso (yyyy-mm-dd) =>");
            int numStudents = (int)ReadLong("Inserire numero studenti =>");
            decimal realPrice = ReadDecimal("Inserire prezzo finale edizione corso =>");
            var edition = new EdizioneCorso(id, null, start, end, numStudents, realPrice);
            if (CourseService.CreateCourseEdition(edition, idCorso) == null)
            {
                WriteLine(DIVISORE);
                WriteLine("Impossibile aggiungere Edizioni con lo stesso ID");
            }
            else
            {
                CourseService.CreateCourseEdition(edition, idCorso);
                Console.Clear();
                WriteLine("Edizione inserita con successo");
            }          
        }

        private void ShowCourseEditionsByCourse()
        {
            long id = ReadLong("Inserire Id corso =>");
            IEnumerable<EdizioneCorso> editions = CourseService.GetCourseEditions(id);
            WriteLine(DIVISORE);
            foreach (var c in editions)
            {
                WriteLine(c.ToString());
            }
        }

        private void CreateCourse()
        {
            long id = ReadLong("Inserire ID =>");
            string titolo = ReadString("Inserire Titolo =>");
            string descrizione = ReadString("Inserire Descrizione =>");
            ExperienceLevel level;
            bool ExpIsGood = false;
            do
            {
                string livelloString = ReadString("Inserire Livello del corso: PRINCIPIANTE | MEDIO | ESPERTO | GURU =>");
               
                ExpIsGood = Enum.TryParse(livelloString, out level);
                if (!ExpIsGood)
                {
                    WriteLine("Inserisci un livello valido");
                }
            }
            while (!ExpIsGood);
            int durataCorso = (int)ReadLong("Inserire Durata del corso =>");
            decimal prezzoCorso = ReadDecimal("Inserire Prezzo corso =>");

            Corso c = new Corso(id, titolo, durataCorso, level, descrizione, prezzoCorso);
            CourseService.CreateCourse(c);
            WriteLine("Corso inserito con successo");
        }

        private void ShowCourses()
        {
            IEnumerable<Corso> courses = CourseService.GetAllCourses();
            WriteLine(DIVISORE);
            foreach(var c in courses)
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
