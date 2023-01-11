namespace StoreSample.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public EfProductRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public PageData<Product> GetAll(int pageNumber, int pageSize,string category)
        {
            var result = new PageData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };
            result.Data = storeDbContext.Products.Where(c => string.IsNullOrEmpty(category) || c.Category == category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = storeDbContext.Products.Where(c => string.IsNullOrEmpty(category) || c.Category == category).Count();
            return result;
        }
    }
}
