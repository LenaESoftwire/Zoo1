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
        Keeper AddKeeper(AddKeeperViewModel addKeeperViewModel);
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

        public Keeper AddKeeper(AddKeeperViewModel addKeeperViewModel)
        {
            var enclosures = new List<Enclosure>();
            foreach (var enclosureName in addKeeperViewModel.Enclosures)
            {
                try
                {
                    var enclosure = _context.Enclosures.Single(e => enclosureName == e.Name);
                    enclosures.Add(enclosure);
                }
                catch
                {
                    Logger.Error($"Enclosure {enclosureName} is not found. It must be an integer between 0 and 4");
                    throw new Exception($"Enclosure {enclosureName} is not found. It must be an integer between 0 and 4");
                }
            }

            var animals = new List<Animal>();
            foreach (var id in addKeeperViewModel.AnimalIds)
            {
                try
                {
                    var animal = _context.Animals
                        .Include(a => a.Enclosure)
                        .Single(a => id == a.Id);
                    animals.Add(animal);
                    if (!enclosures.Contains(animal.Enclosure))
                    {
                        enclosures.Add(animal.Enclosure);
                    }
                }
                catch
                {
                    Logger.Error($"Animal with id {id} is not found");
                    throw new Exception($"Animal with id {id} is not found");
                }
            }
            var newKeeper = new Keeper()
            {
                Name = addKeeperViewModel.Name,
                Enclosures = enclosures,
                Animals = animals
            };
            _context.Keepers.Add(newKeeper);
            _context.SaveChanges();
            return newKeeper;
        }
    }
}
