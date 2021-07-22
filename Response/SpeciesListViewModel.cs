using System.Collections.Generic;

namespace zoo.Request
{
    public class SpeciesListViewModel
    {
        public IEnumerable<SpeciesViewModel> Species { get; set; }

        public SpeciesListViewModel(IEnumerable<SpeciesViewModel> species)
        {
            Species = species;

        }

    }
}
