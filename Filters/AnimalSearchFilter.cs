using System;

namespace Zoo.Filters
{
    public class AnimalsSearchRequest : SearchFilter
    {
        public string? Name { get; set; }
        public string? Species { get; set; }
        public int? Classification { get; set; }
        public int? Age { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string? OrderBy { get; set; }
    }
    
}
