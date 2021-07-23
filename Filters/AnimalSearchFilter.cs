using System;
using System.ComponentModel.DataAnnotations;

namespace Zoo.Filters
{
    public class AnimalsSearchRequest : SearchFilter
    {
        public string? Name { get; set; }
        public string? Species { get; set; }
        [Range(0, 5, ErrorMessage = "Classification must be between 0 and 5")]
        public int? Classification { get; set; }
        public int? Age { get; set; }
        [DataType(DataType.Date, ErrorMessage = "This field is recieving date format: dd/mm/yyyy")]
        public DateTime? DateAcquired { get; set; }
        public string? OrderBy { get; set; }
        [Range(0, 4, ErrorMessage = "Enclouser must be between 0 and 4")]
        public int? Enclosure { get; set; }
        public int? KeeperId { get; set; }
    }
}
