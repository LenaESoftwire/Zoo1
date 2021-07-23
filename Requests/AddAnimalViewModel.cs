using System;
using System.ComponentModel.DataAnnotations;
using zoo.DBModels.Enums;

namespace zoo.Request
{
    public class AddAnimalViewModel
    {
        [Required(ErrorMessage = "Species is required")]
        public string Species { get; set; }
        [Required(ErrorMessage = "Classification is required")]
        [Range(0,5, ErrorMessage = "Classification must be between 0 and 5")]
        public Classification Classification { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sex is required")]
        [Range(0, 2, ErrorMessage = "Sex must be between 0 and 2")]
        public Sex Sex { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date,ErrorMessage = "This field is recieving date format: dd/mm/yyyy")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Date acquired is required")]
        [DataType(DataType.Date, ErrorMessage = "This field is recieving date format: dd/mm/yyyy")]
        public DateTime DateAcquired { get; set; }
        [Required(ErrorMessage = "Enclosure is required")]
        [Range(0, 4, ErrorMessage = "Enclosure must be between 0 and 4")]
        public EnclosureName Enclosure { get; set; }
        [Required(ErrorMessage = "Keeper is required")]
        public string KeeperName { get; set; }
    }
}
