using System;
using System.Collections.Generic;
using System.Linq;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace zoo.Request
{
    public class KeeperViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EnclosureViewModel> Enclosures { get; set; }

        public KeeperViewModel() { }

        public KeeperViewModel(Keeper keeper)
        {
            Id = keeper.Id;
            Name = keeper.Name;
            Enclosures = keeper.Enclosures.Select(e => new EnclosureViewModel(e)).ToList();
        }
    }
}
