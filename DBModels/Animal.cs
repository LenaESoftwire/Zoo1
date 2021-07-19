using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo.DBModels
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Species { get; set; }
        public Enum Classification { get; set; }
        public string Name { get; set; }
        public Enum Sex { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateAcquired { get; set; }

        public Keeper AnimalKeeper { get; set; }
    }
}