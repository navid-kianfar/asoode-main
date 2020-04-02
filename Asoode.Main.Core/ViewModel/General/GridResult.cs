namespace Asoode.Main.Core.ViewModel.General
{
    public class GridResult<T>
    {
        public T[] Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}