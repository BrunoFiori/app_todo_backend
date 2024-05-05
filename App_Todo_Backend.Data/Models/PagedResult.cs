namespace App_Todo_Backend.Data.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int RecordNumber { get; set; }
        public List<T>? Items { get; set; }

        public PagedResult()
        {
        }

        public PagedResult(int totalCount, int pageNumber, int recordNumber, List<T> items)
        {
            TotalCount = totalCount;
            PageNumber = pageNumber;
            RecordNumber = recordNumber;
            Items = items;
        }
    }
}
