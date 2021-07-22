using System;
using System.Collections.Generic;
using System.Linq;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace zoo.Request
{
    public class EnclosureViewModel
    {
        public EnclosureName Name { get; set; }
        public List<AnimalViewModel> Animals { get; set; }

        public EnclosureViewModel() { }

        public EnclosureViewModel(Enclosure enclosure)
        {
            Name = enclosure.Name;
            Animals = enclosure.Animals.Select(a => new AnimalViewModel(a)).ToList();
        }
    }
}
