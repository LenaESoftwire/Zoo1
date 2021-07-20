using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace zoo.Response
{
    public class AnimalListViewModel
    {
        public IEnumerable<AnimalViewModel> Animals { get; set; }

        public AnimalListViewModel(IEnumerable<AnimalViewModel> animals)
        {
            Animals = animals;
             
        }
       
    }
}
