namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSiage = 50;
        public int PageIndex {get; set;} = 1;

        private int _pageSize = 6 ;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSiage) ? MaxPageSiage : value;
        }

        public int? BrandID {get; set;}

        public int? TypeId { get; set; }    

        public string Sort { get; set; }

        private string _search;

        public string Search
        { 
            get => _search; 
            set => _search = value.ToLower(); 
        }
    }
}