using System;
using zoo.DBModels.Enums;

namespace Zoo.DBModels
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public Classification Classification { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DateAcquired { get; set; }


    }
}