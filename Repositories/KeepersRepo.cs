using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Linq;
using zoo.Request;
using Zoo;
using Zoo.DBModels;

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
            var keeper = _context.Keepers
                    .Include(k => k.Enclosures)
                    .ThenInclude(e => e.Animals.Where(a => a.Keeper.Id == id))
                    .ThenInclude(a => a.Species)
                    .Include(k => k.Enclosures)
                    .ThenInclude(e => e.Animals)
                    .ThenInclude(a => a.Keeper)
                    .SingleOrDefault(k => k.Id == id);

            return keeper == null ? null : new KeeperViewModel(keeper);
        }

        public Keeper AddKeeper(AddKeeperViewModel addKeeperViewModel)
        {
            var enclosures = _context.Enclosures.Where(e => addKeeperViewModel.Enclosures.Contains(e.Name)).ToList();

            if (enclosures.Count != addKeeperViewModel.Enclosures.Count)
            {
                var falseEnclosureNames = addKeeperViewModel.Enclosures.Where(eName => !enclosures.Any(e => e.Name == eName));
                Logger.Error($"Enclosure(s) {string.Join(", ", falseEnclosureNames)} not found. It must be an integer between 0 and 4");
                throw new Exception($"Enclosure(s) {string.Join(", ", falseEnclosureNames)} not found. It must be an integer between 0 and 4");
            }

            var animals = _context.Animals
                .Include(a => a.Enclosure)
                .Where(a => addKeeperViewModel.AnimalIds.Contains(a.Id)).ToList();
            if (animals.Count != addKeeperViewModel.AnimalIds.Count)
            {
                var falseAnimals = addKeeperViewModel.AnimalIds.Where(id => !animals.Any(a => a.Id == id));
                Logger.Error($"Animal(s) {string.Join(", ", falseAnimals)} not found");
                throw new Exception($"Animal(s) {string.Join(", ", falseAnimals)} not found");
            }

            enclosures.AddRange(animals.Select(a => a.Enclosure).Where(e => !enclosures.Any(e1 => e == e1)));

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
