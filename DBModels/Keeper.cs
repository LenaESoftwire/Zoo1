using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo.DBModels
{
    public class Keeper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Enum Sex { get; set; }
        public DateTime DOB { get; set; }
        
        public List<Animal> KeepersAnimals { get; set; }
    }
}