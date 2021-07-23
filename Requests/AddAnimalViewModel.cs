using System;
using System.ComponentModel.DataAnnotations;
using zoo.DBModels.Enums;

namespace zoo.Request
{
    public class AddAnimalViewModel
    {
        [Required(ErrorMessage = "Species is required")]
        [Display(Name = "Species")]
        public string Species { get; set; }
        [Required(ErrorMessage = "Classification is required")]
        [Range(0,5, ErrorMessage = "Classification must be between 0 and 5")]
        [Display(Name = "Classfication")]
        public Classification Classification { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sex is required")]
        [Range(0, 2, ErrorMessage = "Sex must be between 0 and 2")]
        [Display(Name = "Sex")]
        public Sex Sex { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date,ErrorMessage = "This field is recieving date format: dd/mm/yyyy")]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Date acquired is required")]
        [DataType(DataType.Date, ErrorMessage = "This field is recieving date format: dd/mm/yyyy")]
        [Display(Name = "Date Acquired")]
        public DateTime DateAcquired { get; set; }
        [Required(ErrorMessage = "Enclosure is required")]
        [Range(0, 4, ErrorMessage = "Enclosure must be between 0 and 4")]
        [Display(Name = "Enclosure")]
        public EnclosureName Enclosure { get; set; }
        [Required(ErrorMessage = "Keeper is required")]
        [Display(Name = "Keeper")]
        public string KeeperName { get; set; }
    }
}
