using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using zoo.Response;
using Zoo;
using Zoo.Filters;

namespace zoo.Repositories
{
    public interface IFiltersRepo
    {
        IEnumerable<AnimalViewModel> SearchAnimals(AnimalsSearchRequest search);
    }
    public class FiltersRepo : IFiltersRepo
    {
        private readonly ZooDbContext _context;

        public FiltersRepo(ZooDbContext context)
        {
            _context = context;
        }
       
        public IEnumerable<AnimalViewModel> SearchAnimals(AnimalsSearchRequest search)
        {
            return _context.Animals
                //.OrderByDescending(p => p.PostedAt)
                .Where(a => search.Name == null || a.Name == search.Name)
                .Where(a => search.Species == null || a.Species.SpeciesName == search.Species)
                .Include(a => a.Species)
                .Skip((search.PageNumber - 1) * search.PageSize)
                .Take(search.PageSize)
                .Select(a => new AnimalViewModel(a));
        }
    }

}