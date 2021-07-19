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
        List<AnimalViewModel> AnimalsList();

        //void AddAnimal (addAnimalViewModel addBookViewModel);

    }
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooDbContext _context;

        public AnimalsRepo(ZooDbContext context)
        {
            _context = context;
        }


    }
}
