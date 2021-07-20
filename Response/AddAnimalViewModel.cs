using System;
using System.ComponentModel.DataAnnotations;
using zoo.DBModels.Enums;

namespace zoo.Response
{
    public class AddAnimalViewModel
    {
        [Required]
        [Display(Name = "Species")]
        public string Species { get; set; }
        [Required]
        [Display(Name = "Classfication")]
        public Classification Classification { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Sex")]
        public Sex Sex { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }
        [Required]
        [Display(Name = "Date Acquired")]
        public DateTime DateAcquired { get; set; }

    }
}
