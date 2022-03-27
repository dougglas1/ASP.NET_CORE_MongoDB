using System.Collections.Generic;

namespace ASP.NET_CORE_MongoDB.Contracts.Paginated
{
    public class PaginatedData<T>
    {
        public PaginatedData(int currentPage, int total, int perPage, IEnumerable<T> data)
        {
            CurrentPage = currentPage;
            Total = total;
            PerPage = perPage;
            Data = data;
        }
        
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public int PerPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
