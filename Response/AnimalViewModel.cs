using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace zoo.Response
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public Classification Classification { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DateAcquired { get; set; }

        public AnimalViewModel(Animal animal)
        {
            Id = animal.Id;
            Species = animal.Species;
            Classification = animal.Classification;
            Name = animal.Name;
            Sex = animal.Sex;
            Dob = animal.Dob;
            DateAcquired = animal.DateAcquired;
        }
    }
}
