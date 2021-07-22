using System.Collections.Generic;
using System.Linq;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace Zoo.Data
{
    public class SampleEnclosures
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "0", "10" },
            new List<string> { "1", "50" },
            new List<string> { "2", "40" },
            new List<string> { "3", "6" },
            new List<string> { "4", "10" },
         };

        public static IEnumerable<Enclosure> GetEnclosures() => Enumerable.Range(0, 5).Select(CreateRandomEnclosures);

        private static Enclosure CreateRandomEnclosures(int index)
        {
            return new Enclosure
            {
                Name = (EnclosureName)int.Parse(_data[index][0]),
                Capacity = int.Parse(_data[index][1])
            };
        }
    }
}
