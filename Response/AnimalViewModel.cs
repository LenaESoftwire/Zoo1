using System;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace zoo.Request
{
    public class AnimalViewModel
    {
        public string Species { get; set; }
        public Classification Classification { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DateAcquired { get; set; }
        public EnclosureName Enclosure { get; set; }
        public string Keeper { get; set; }

        public AnimalViewModel() { }

        public AnimalViewModel(Animal animal)
        {
            Species = animal.Species.Name;
            Classification = animal.Species.Classification;
            Name = animal.Name;
            Sex = animal.Sex;
            Dob = animal.Dob;
            DateAcquired = animal.DateAcquired;
            Enclosure = animal.Enclosure.Name;
            Keeper = animal.Keeper.Name;
        }
    }
}
