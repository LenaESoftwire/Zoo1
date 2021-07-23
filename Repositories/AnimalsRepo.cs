using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using zoo.Request;
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
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AnimalViewModel> GetAnimalsList(SearchFilter pageFilter)
        {
            Logger.Info("Getting a list of animals ordered by Id");
            var animals = _context.Animals
                .Include(animal => animal.Species)
                .Include(animal => animal.Enclosure)
                .Include(a => a.Keeper)
                .OrderBy(animal => animal.Enclosure.Name)
                .ThenBy(animal => animal.Name)
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                .Take(pageFilter.PageSize)
                .ToList();
            var animalsList = animals.Select(animal => new AnimalViewModel(animal));
            return animalsList;
        }

        public AnimalViewModel GetAnimalById(int id)
        {
            return new AnimalViewModel(_context.Animals
                    .Include(animal => animal.Species)
                    .Include(animal => animal.Enclosure)
                    .Include(a => a.Keeper)
                    .Single(animal => animal.Id == id));
        }

        public void AddAnimal(AddAnimalViewModel addAnimalViewModel)
        {
            var classification = addAnimalViewModel.Classification;
            var enclosure = _context.Enclosures
                .Include(enclosure => enclosure.Animals)
                //.Include(a => a.Keeper)
                .SingleOrDefault(enclosure => enclosure.Name == addAnimalViewModel.Enclosure);

            if (addAnimalViewModel.Dob>DateTime.Now || addAnimalViewModel.DateAcquired>DateTime.Now 
                || addAnimalViewModel.DateAcquired<addAnimalViewModel.Dob)
            {
                Logger.Error("Date of birth and date acquired must not be later than today, date of birth must not be later than date acquired");
                throw new Exception("Date of birth and date acquired must not be later than today, date of birth must not be later than date acquired");
            }

            if (enclosure.Capacity <= enclosure.Animals.Count)
            {
                Logger.Error($"Animal can't be added as {enclosure.Name} enclosure is full");
                throw new Exception($"Animal can't be added as {enclosure.Name} enclosure is full");
            }

            var species = _context.Species.SingleOrDefault(species => species.Name.ToLower() == addAnimalViewModel.Species.ToLower())
               ?? new Species()
               {
                   Name = addAnimalViewModel.Species,
                   Classification = addAnimalViewModel.Classification
               };
            var keeper = 
                _context.Keepers
                .Include(k => k.Enclosures)
                .SingleOrDefault(keeper => keeper.Name.ToLower() == addAnimalViewModel.KeeperName.ToLower())
      
               ?? new Keeper()
               {
                   Name = addAnimalViewModel.KeeperName,
                   Enclosures = new List<Enclosure>(),
                   Animals = new List<Animal>()          
               };
            keeper.Enclosures.Add(enclosure);

        var newAnimal = new Animal()
            {
                Species = species,
                Name = addAnimalViewModel.Name,
                Sex = addAnimalViewModel.Sex,
                Dob = addAnimalViewModel.Dob,
                DateAcquired = addAnimalViewModel.DateAcquired,
                Enclosure = enclosure,
                Keeper = keeper
            };
            _context.Animals.Add(newAnimal);
            _context.SaveChanges();
        }

        public IEnumerable<SpeciesViewModel> GetSpeciesList(SearchFilter pageFilter)
        {
            var species = _context.Species
                .Include(species => species.Animals)
                .ThenInclude(animal => animal.Enclosure)
                .ThenInclude(a => a.Keeper)
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
               .Where(a => string.IsNullOrEmpty(search.Species) || a.Species.Name.ToLower() == search.Species.ToLower())
               .Where(a => search.Classification == null || search.Classification == (int)a.Species.Classification)
               .Where(a => search.Age == null || search.Age == DateTime.Today.Year - a.Dob.Year)
               .Where(a => search.DateAcquired == null || search.DateAcquired.Value.Date == a.DateAcquired.Date)
               //.Where(a => search.DateAcquired == null || search.DateAcquired.Value.Date == a.DateAcquired.Date)
               .Where(a => search.Enclosure == null || search.Enclosure == (int)a.Enclosure.Name);

            query = orderBy switch
            {
                "classification" => query.OrderBy(a => a.Species.Classification),
                "dob" => query.OrderBy(a => a.Dob),
                "name" => query.OrderBy(a => a.Name),
                "dateacquired" => query.OrderBy(a => a.DateAcquired),
                "enclosure" => query.OrderBy(a => a.Enclosure.Name),
                _ => query.OrderBy(a => a.Species.Name),
            };
            return query
               .Include(a => a.Species)
               .Include(a => a.Enclosure)
               .Include(a => a.Keeper)
               .Skip((search.PageNumber - 1) * search.PageSize)
               .Take(search.PageSize)
               .Select(a => new AnimalViewModel(a));
        }
    }
}
