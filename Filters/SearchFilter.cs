namespace Zoo.Filters
{
    public class SearchFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }

    public class AnimalsSearchRequest : SearchFilter
    {
        private string _name;
        private string _species;
        public string Name
        {
            get => _name?.ToLower();
            set => _name = value;
        }
        public string Species
        {
            get => _species?.ToLower();
            set => _species = value;
        }
        public override string Filters
        {
            get
            {
                var filters = "";

                if (Name != null)
                {
                    filters += $"&name={Name}";
                }

                if (Species != null)
                {
                    filters += $"&species={Species}";
                }

                return filters;
            }
        }
    }
}