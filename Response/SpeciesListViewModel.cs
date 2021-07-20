using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoo.DBModels.Enums;
using Zoo.DBModels;

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
