namespace BestQA.QueryService.Grid
{
    public class BaseGridParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }
        public string SortColumn { get; set; }
    }
}