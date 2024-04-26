namespace App_Todo_Backend.Data.Models
{
    public class QueryParameters
    {
        private int _pageSize = 10;

        const int maxPageSize = 50;        
        public int PageNumber { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
