using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using zoo.DBModels.Enums;

namespace zoo.Request
{
    public class AddKeeperViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enclosure is required")]
        public List<EnclosureName> Enclosures { get; set; }
        [Required(ErrorMessage = "An animal is required")]
        public List<int> AnimalIds { get; set; }
    }
}