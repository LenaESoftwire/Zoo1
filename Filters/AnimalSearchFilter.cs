namespace Zoo.Filters
{
    public class AnimalsSearchRequest : SearchFilter
    {
        public string? Name { get; set; }
        public string? Species { get; set; }
    }
    
}
