using System.Collections.Generic;

namespace zoo.Request
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
