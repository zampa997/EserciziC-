using System;

{
    public class Aula
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long MaxCapacity { get; set; }
        public bool IsPhysical { get; set; }
        public bool? IsComputerized { get; set; }
        public bool? HasProjector { get; set; }
        public Aula() { }
        public Aula(long id, string name, long maxCapacity, bool isPhysical, bool? isComputerized, bool? hasProjector)
        {
            Id = id;
            Name = name;
            MaxCapacity = maxCapacity;
            IsPhysical = isPhysical;
            IsComputerized = isComputerized;
            HasProjector = hasProjector;
        }
    }


}

