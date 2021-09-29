using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizi.Model
{
    public class Livello
    {//checked 
        #region Properties
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public tipo Tipo { get; set; }
        #endregion
        #region Costructor
        public Livello() { }
        public Livello(int id, string descrizione)
        {
            Id = id;
            Descrizione = descrizione;
            switch (id)
            {
                case 1:
                    Tipo = Livello.tipo.PRINCIPIANTE;
                    break;
                case 2:
                    Tipo = Livello.tipo.MEDIO;
                    break;
                case 3:
                    Tipo = Livello.tipo.ESPERTO;
                    break;
                case 4:
                    Tipo = Livello.tipo.GURU;
                    break;
                default:
                    Console.WriteLine(@"Pippo pippa il pippa che pippa
                    Che palle samu e' pignolo, senti vai a Livello riga 34/35");
                    break;
            }
        }
        public enum tipo
        {
            PRINCIPIANTE,
            MEDIO,
            ESPERTO,
            GURU
        }
        public Livello(string descrizione)
        {
            Descrizione = descrizione;
            switch (Id)
            {
                case 1:
                    Tipo = Livello.tipo.PRINCIPIANTE;
                    break;
                case 2:
                    Tipo = Livello.tipo.MEDIO;
                    break;
                case 3:
                    Tipo = Livello.tipo.ESPERTO;
                    break;
                case 4:
                    Tipo = Livello.tipo.GURU;
                    break;
                default:
                    Console.WriteLine(@"Pippo pippa il pippa che pippa
                    Che palle samu e' pignolo, senti vai a Livello riga 34/35");
                    break;
            }
        }
        #endregion
    }

}
