using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using zoo.Response;
using Zoo;
using Zoo.DBModels;
using Zoo.Filters;

namespace zoo.Repositories
{
    public interface IAnimalsRepo
    {
        IEnumerable<AnimalViewModel> GetAnimalsList(SearchFilter pageFilter);
        AnimalViewModel GetAnimalById(int id);
        void AddAnimal(AddAnimalViewModel addAnimalViewModel);
        IEnumerable<SpeciesViewModel> GetSpeciesList(SearchFilter pageFilter);
        IEnumerable<AnimalViewModel> SearchAnimals(AnimalsSearchRequest search);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AnimalViewModel> GetAnimalsList(SearchFilter pageFilter)
        {
            var animals = _context.Animals
                .Include(animal => animal.Species)
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize)
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

        public IEnumerable<SpeciesViewModel> GetSpeciesList(SearchFilter pageFilter)
        {
            var species = _context.Species
                .Include(species => species.Animals)
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize)
                .ToList();
            var speciesList = species.Select(animal => new SpeciesViewModel(animal));
            return speciesList;
        }

        public IEnumerable<AnimalViewModel> SearchAnimals(AnimalsSearchRequest search)
        {
            var orderBy = string.IsNullOrEmpty(search.OrderBy) ? "default" : search.OrderBy.ToLower();
            var query = _context.Animals
               .Where(a => string.IsNullOrEmpty(search.Name) || a.Name.ToLower() == search.Name.ToLower())
               .Where(a => string.IsNullOrEmpty(search.Species) || a.Species.SpeciesName.ToLower() == search.Species.ToLower())
               .Where(a => search.Classification == null || search.Classification == (int)a.Species.Classification)
               .Where(a => search.Age == null || search.Age == DateTime.Today.Year - a.Dob.Year)
               .Where(a => search.DateAcquired == null || search.DateAcquired.Value.Date == a.DateAcquired.Date);
            switch (orderBy)
            {
                case "classification":
                    query = query
                        .OrderBy(a => a.Species.Classification);
                    break;
                case "dob":
                    query = query
                        .OrderBy(a => a.Dob);
                    break;
                case "name":
                    query = query
                        .OrderBy(a => a.Name);
                    break;
                case "dateacquired":
                    query = query
                        .OrderBy(a => a.DateAcquired);
                    break;
                default:
                    query = query
                        .OrderBy(a => a.Species.SpeciesName);
                    break;
            }

            return query
               .Include(a => a.Species)
               .Skip((search.PageNumber - 1) * search.PageSize)
               .Take(search.PageSize)
               .Select(a => new AnimalViewModel(a));
        }
    }
}
