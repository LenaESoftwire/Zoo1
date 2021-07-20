using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using zoo.Response;
using Zoo;
using Zoo.DBModels;

namespace zoo.Repositories
{
    public interface IAnimalsRepo
    {
        IEnumerable<AnimalViewModel> GetAnimalsList();
        AnimalViewModel GetAnimalById(int id);
        void AddAnimal(AddAnimalViewModel addAnimalViewModel);
        IEnumerable<SpeciesViewModel> GetSpeciesList();
    }
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AnimalViewModel> GetAnimalsList()
        {
            var animals = _context.Animals
                .Include(animal => animal.Species)
                .ToList();
            var animalsList = animals.Select(animal => new AnimalViewModel(animal));
            return animalsList;
        }

        public AnimalViewModel GetAnimalById(int id)
        {
            var animal = _context.Animals
                .Include(animal => animal.Species)
                .Single(animal => animal.Id == id);

            return new AnimalViewModel(animal);
        }

        public void AddAnimal(AddAnimalViewModel addAnimalViewModel)
        {
            var species = _context.Species.SingleOrDefault(species => species.SpeciesName == addAnimalViewModel.Species)
               ?? new Species()
               {
                   SpeciesName = addAnimalViewModel.Species,
                   Classification = addAnimalViewModel.Classification
               };
            var newAnimal = new Animal()
            {
                Species = species,
                Name = addAnimalViewModel.Name,
                Sex = addAnimalViewModel.Sex,
                Dob = addAnimalViewModel.Dob,
                DateAcquired = addAnimalViewModel.DateAcquired
            };
            _context.Animals.Add(newAnimal);
            _context.SaveChanges();
        }

        public IEnumerable<SpeciesViewModel> GetSpeciesList()
        {
            var species = _context.Species
                .Include(species => species.Animals)
                .ToList();
            var speciesList = species.Select(animal => new SpeciesViewModel(animal));
            return speciesList;
        }
    }
}
