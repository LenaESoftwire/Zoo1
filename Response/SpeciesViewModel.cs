using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace zoo.Request
{
    public class SpeciesViewModel
    {
        public string SpeciesName { get; set; }
        public Classification Classification { get; set; }
        public int Number { get; set; }


        public SpeciesViewModel(Species species)
        {
            SpeciesName = species.SpeciesName;
            Classification = species.Classification;
            Number = species.Animals.Count;
        }
    }
}
