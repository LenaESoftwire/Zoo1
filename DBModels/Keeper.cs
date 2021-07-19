using System;
using System.Collections.Generic;

namespace Zoo.DBModels
{
    public class Keeper
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Enum Sex { get; set; }
        public DateTime DOB { get; set; }

        public List<Animal> KeepersAnimals { get; set; }
    }
}