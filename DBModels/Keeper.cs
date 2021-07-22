using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using zoo.DBModels.Enums;

namespace Zoo.DBModels
{
    public class Keeper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Enclosure> Enclosures { get; set; }
    }
}