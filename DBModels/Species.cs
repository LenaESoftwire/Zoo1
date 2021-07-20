using System;
using System.Collections.Generic;
using zoo.DBModels.Enums;

namespace Zoo.DBModels
{
    public class Species
    {
        public int Id { get; set; }
        public string SpeciesName { get; set; }
        public Classification Classification { get; set; }
        public List<Animal> Animals { get; set; }

    }
}