using System.Collections.Generic;
using System.Linq;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace Zoo.Data
{
    public class SampleKeepers
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Kaitlyn", "Filshin", "kfilshino", "kfilshino@so-net.ne.jp" },
            new List<string> { "Aube", "Goneau", "agoneaup", "agoneaup@barnesandnoble.com" },
            new List<string> { "Natala", "Mackrill", "nmackrillq", "nmackrillq@google.es" },
            new List<string> { "Ev", "Wadly", "ewadlyr", "ewadlyr@adobe.com" },
            new List<string> { "Aurora", "Feedham", "afeedhams", "afeedhams@house.gov" },
            new List<string> { "Farly", "Chestney", "fchestneyt", "fchestneyt@usda.gov" },
            new List<string> { "Chico", "Guilloux", "cguillouxu", "cguillouxu@senate.gov" },
            new List<string> { "Julianna", "Huckstepp", "jhucksteppv", "jhucksteppv@ycombinator.com" },
            new List<string> { "Bev", "Sancto", "bsanctow", "bsanctow@spiegel.de" },
            new List<string> { "Shara", "Jeeves", "sjeevesx", "sjeevesx@behance.net" },
            new List<string> { "Legra", "Jereatt", "ljereatty", "ljereatty@prnewswire.com" },
        };

        public static IEnumerable<Keeper> GetKeeper() => Enumerable.Range(0, 10).Select(CreateRandomKeeper);

        private static Keeper CreateRandomKeeper(int index)
        {
            return new Keeper
            {
                Name = _data[index][0],
                Enclosures = new List<Enclosure>(),
                Animals = new List<Animal>()
            };
        }
    }
}
