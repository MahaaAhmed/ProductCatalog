namespace Product_Catalog.BLL.Repositories
{
    public enum ProductSortingOptions
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
    }
    public class ProductQueryParameters
    {
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        private int pageSize = DefaultPageSize;

        public int? CategoryId { get; set; }
        public ProductSortingOptions Options { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get => pageSize; set => pageSize = value > 0 && value < MaxPageSize ? value : DefaultPageSize; }
    }
}