using System;
using System.Data.SqlClient;

namespace Esercizi.Classes
{
    public class Aula
    { //checked
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public long MaxCapacity { get; set; }
        public bool IsPhysical { get; set; }
        public bool? IsComputerized { get; set; }
        public bool? HasProjector { get; set; }
        private static int LastId = 0;
        #endregion
        #region Costructor
        public Aula() { }
        public Aula(long id, string name, long maxCapacity, bool isPhysical, 
            bool? isComputerized, bool? hasProjector)
        {
            LastId += 1;
            Id = LastId;
            Name = name;
            MaxCapacity = maxCapacity;
            IsPhysical = isPhysical;
            IsComputerized = isComputerized;
            HasProjector = hasProjector;
        }
        #endregion
        }
    }

}


