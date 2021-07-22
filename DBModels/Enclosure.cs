using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using zoo.DBModels.Enums;

namespace Zoo.DBModels
{
    public class Enclosure
    {
        public int Id { get; set; }
        public EnclosureName Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Keeper> Keeper { get; set; }
    }
}