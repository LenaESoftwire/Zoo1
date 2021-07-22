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
    public interface IKeepersRepo
    {
        KeeperViewModel GetKeeperById(int id);
        //void AddAnimal(AddAnimalViewModel addAnimalViewModel);
    }

    public class KeepersRepo : IKeepersRepo
    {
        private readonly ZooDbContext _context;
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public KeepersRepo(ZooDbContext context)
        {
            _context = context;
        }


        public KeeperViewModel GetKeeperById(int id)
        {
            return new KeeperViewModel(_context.Keepers
                    .Include(k => k.Enclosures)
                    .ThenInclude(e => e.Animals.Where(a => a.Keeper.Id == id))
                    .ThenInclude(a => a.Species)
                    .Include(k => k.Enclosures)
                    .ThenInclude(e => e.Animals)
                    .ThenInclude(a => a.Keeper)
                    .Single(k => k.Id == id));
        }

        //public void AddAnimal(AddAnimalViewModel addAnimalViewModel)
        //{
        //    var classification = addAnimalViewModel.Classification;
        //    var enclosure = _context.Enclosures
        //        .Include(enclosure => enclosure.Animals)
        //        //.Include(a => a.Keeper)
        //        .SingleOrDefault(enclosure => enclosure.Name == addAnimalViewModel.Enclosure);

        //    if (addAnimalViewModel.Dob>DateTime.Now || addAnimalViewModel.DateAcquired>DateTime.Now 
        //        || addAnimalViewModel.DateAcquired<addAnimalViewModel.Dob)
        //    {
        //        Logger.Error("Date of birth and date acquired must not be later than today, date of birth must not be later than date acquired");
        //        throw new Exception("Date of birth and date acquired must not be later than today, date of birth must not be later than date acquired");
        //    }

        //    if (enclosure.Capacity <= enclosure.Animals.Count)
        //    {
        //        Logger.Error($"Animal can't be added as {enclosure.Name} enclosure is full");
        //        throw new Exception($"Animal can't be added as {enclosure.Name} enclosure is full");
        //    }

        //    var species = _context.Species.SingleOrDefault(species => species.Name.ToLower() == addAnimalViewModel.Species.ToLower())
        //       ?? new Species()
        //       {
        //           Name = addAnimalViewModel.Species,
        //           Classification = addAnimalViewModel.Classification
        //       };
        //    var newAnimal = new Animal()
        //    {
        //        Species = species,
        //        Name = addAnimalViewModel.Name,
        //        Sex = addAnimalViewModel.Sex,
        //        Dob = addAnimalViewModel.Dob,
        //        DateAcquired = addAnimalViewModel.DateAcquired,
        //        Enclosure = enclosure
        //    };
        //    _context.Animals.Add(newAnimal);
        //    _context.SaveChanges();
        //}

        
    }
}
