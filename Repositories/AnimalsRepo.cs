using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zoo.Response;
using Zoo;

namespace zoo.Repositories
{
    public interface IAnimalsRepo
    {
        IEnumerable<AnimalViewModel> GetAnimalsList();
        AnimalViewModel GetAnimalById(int id);

        //void AddAnimal (addAnimalViewModel addBookViewModel);

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
            return  animalsList;
        }

        public AnimalViewModel GetAnimalById(int id)
        {
            var animal = _context.Animals
                .Include(animal => animal.Species)
                .Single(animal => animal.Id == id);

            return new AnimalViewModel(animal);
        }
    }
}
