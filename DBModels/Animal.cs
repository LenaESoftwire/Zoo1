using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zoo.DBModels.Enums;

namespace Zoo.DBModels
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public ClassificationEnum Classification { get; set; }
        public string Name { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DateAcquired { get; set; }

     
    }
}