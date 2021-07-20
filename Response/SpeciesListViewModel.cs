using System.Collections.Generic;

namespace zoo.Response
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
