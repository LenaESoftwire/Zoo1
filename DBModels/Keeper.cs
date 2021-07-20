using System;
using System.Collections.Generic;
using zoo.DBModels.Enums;

namespace Zoo.DBModels
{
    public class Keeper
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime DOB { get; set; }

        public List<Animal> KeepersAnimals { get; set; }
    }
}