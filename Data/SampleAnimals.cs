using System;
using System.Collections.Generic;
using System.Linq;
using zoo.DBModels.Enums;
using Zoo.DBModels;

namespace Zoo.Data
{
    public class SampleAnimals
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Cat", "Placido" },
            new List<string> { "Dog", "Gariff"},
            new List<string> { "Cat", "Burgiss" },
            new List<string> { "Worm", "Percival" },
            new List<string> { "Horse", "Narraway"},
            new List<string> { "Jellyfish", "Sakins" },
            new List<string> { "Dog", "Barkworth" },
            new List<string> { "Worm", "Verick"},
            new List<string> { "Dog", "Lovett" },
            new List<string> { "Fish", "Smyth" },
            new List<string> { "Cat", "Placido" },
            new List<string> { "Dog", "Gariff"},
            new List<string> { "Cat", "Burgiss" },
            new List<string> { "Worm", "Percival" },
            new List<string> { "Horse", "Narraway"},
            new List<string> { "Jellyfish", "Sakins" },
            new List<string> { "Dog", "Barkworth" },
            new List<string> { "Worm", "Verick"},
            new List<string> { "Dog", "Lovett" },
            new List<string> { "Fish", "Smyth" },
            new List<string> { "Cat", "O' Scallan" },
            new List<string> { "Worm", "Bevington"},
            new List<string> { "Dog", "Cow" },
            new List<string> { "Cat", "Northage" },
            new List<string> { "Dog", "Balsom" },
            new List<string> { "Fish", "Galgey" },
            new List<string> { "Fish", "Laurant" },
            new List<string> { "Fish", "Mabley" },
            new List<string> { "Worm", "Guillond" },
            new List<string> { "Spider", "Djuricic" },
            new List<string> { "Cat", "Adamovicz" },
            new List<string> { "Spider", "Goodacre" },
            new List<string> { "Spider", "Blow" },
            new List<string> { "Zebra", "Pritchett" },
            new List<string> { "Cat", "Filshin" },
            new List<string> { "Lama", "Goneau" },
            new List<string> { "Pig", "Mackrill" },
            new List<string> { "Pig", "Wadly"},
            new List<string> { "Fish", "Feedham" },
            new List<string> { "Fish", "Chestney" },
            new List<string> { "Fish", "Guilloux" },
            new List<string> { "Spider", "Huckstepp" },
            new List<string> { "Zebra", "Sancto" },
            new List<string> { "Spider", "Jeeves" },
            new List<string> { "Legra", "Jereatt" },
            new List<string> { "Zebra", "Ternouth" },
            new List<string> { "Lemur", "McMenamin" },
            new List<string> { "Cat", "Greenhalf" },
            new List<string> { "Mouse", "Fellgate" },
            new List<string> { "Mouse", "Dickens" },
            new List<string> { "Zebra", "McKaile" },
            new List<string> { "Lemur", "Aishford" },
            new List<string> { "Mouse", "Gauford" },
            new List<string> { "Mouse", "Seelbach" },
            new List<string> { "Lemur", "Winsper" },
            new List<string> { "Mouse", "Welds" },
            new List<string> { "Lemur", "Kerin" },
            new List<string> { "Lemur", "Tompkins" },
            new List<string> { "Mouse", "Clever" },
            new List<string> { "Mouse", "Denny" },
            new List<string> { "Octopus", "Scorah" },
            new List<string> { "Octopus", "McGow" },
            new List<string> { "Octopus", "Jannasch" },
            new List<string> { "Lemur", "Dommett" },
            new List<string> { "Zebra", "Norcop" },
            new List<string> { "Lemur", "Baline" },
            new List<string> { "Octopus", "Dorcey" },
            new List<string> { "Zebra", "Surplice" },
            new List<string> { "Octopus", "Dyott" },
            new List<string> { "Bear", "Connachan" },
            new List<string> { "Camel", "Anselmi" },
            new List<string> { "Camel", "McCowen" },
            new List<string> { "Cheetah", "Dossettor" },
            new List<string> { "Cheetah", "Ogdahl" },
            new List<string> { "Elephant", "Searle" },
            new List<string> { "Elephant", "MacLise" },
            new List<string> { "Cat", "Hillitt" },
            new List<string> { "Alligator", "Tumielli" },
            new List<string> { "Bear", "Dupey" },
            new List<string> { "Bear", "Heineke" },
            new List<string> { "Elephant", "Angric" },
            new List<string> { "Panda", "Steljes"  },
            new List<string> { "Panda", "Ashard"  },
            new List<string> { "Hippo", "Devons" },
            new List<string> { "Camel", "Undrell" },
            new List<string> { "Bear", "Langworthy" },
            new List<string> { "Alligator", "Minards" },
            new List<string> { "Alligator", "Bennion" },
            new List<string> { "Zebra", "Norridge" },
            new List<string> { "Tiger", "Traske" },
            new List<string> { "Panda", "McCard" },
            new List<string> { "Monkey", "Capstaff" },
            new List<string> { "Lion", "Sleford" },
            new List<string> { "Iguana", "Nary" },
            new List<string> { "Hyena", "Lukianov" },
            new List<string> { "Hippo", "Durkin" },
            new List<string> { "Gorilla", "Coronas" },
            new List<string> { "Giraffe", "Keener",  },
            new List<string> { "Flamingo", "Wynett" },
            new List<string> { "Elephant", "Cordelle" },
            new List<string> { "Alligator", "Deport" },
            new List<string> { "Cheetah", "Perchard" },
            new List<string> { "Camel", "Iceton" },
            new List<string> { "Bear", "Beadell" }
        };

        public static IEnumerable<Animal> GetAnimals()
        {
            var species = SampleSpecies.GetSpecies().ToList();
            var enclosures = SampleEnclosures.GetEnclosures().ToList();
            return Enumerable.Range(0, _data.Count - 1).Select(i => CreateRandomAnimal(i, species, enclosures));
        }

        private static Animal CreateRandomAnimal(int index, IList<Species> species, IList<Enclosure> enclosures)
        {
            var rnd = new Random();
            var start = new DateTime(1950, 1, 1);
            var range = (DateTime.Today - start).Days;
            var dob = start.AddDays(rnd.Next(range));

            return new Animal
            {
                Species = species[rnd.Next(18)],
                Name = _data[index][1],
                Sex = (Sex)rnd.Next(3),
                Dob = dob,
                DateAcquired = dob.AddDays(rnd.Next((DateTime.Today - dob).Days)),
                Enclosure = enclosures[rnd.Next(5)]
            };
        }
    }
}
