using System.Collections.Generic;
using System.Linq;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace Zoo.Data
{
    public class SampleSpecies
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Lion", "0" },
            new List<string> { "Dog", "0" },
            new List<string> { "Worm", "5" },
            new List<string> { "Horse", "0" },
            new List<string> { "Jellyfish", "4" },
            new List<string> { "Fish", "4" },
            new List<string> { "Spider", "5" },
            new List<string> { "Zebra", "0" },
            new List<string> { "Lama", "0" },
            new List<string> { "Cricket", "3" },
            new List<string> { "Pig", "0" },
            new List<string> { "Eagle", "2" },
            new List<string> { "Owl", "2" },
            new List<string> { "Alligator", "1" },
            new List<string> { "Iguana", "1" },
            new List<string> { "Hyena", "0" },
            new List<string> { "Hippo", "0" },
            new List<string> { "Flamingo", "2" },
        };

        public static IEnumerable<Species> GetSpecies() => Enumerable.Range(0, 18).Select(CreateRandomSpecies);

        private static Species CreateRandomSpecies(int index)
        {
            return new Species
            {
                Name = _data[index][0],
                Classification = (Classification)int.Parse(_data[index][1])
            };
        }
    }
}
