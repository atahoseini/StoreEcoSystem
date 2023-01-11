using Microsoft.AspNetCore.Mvc;
using StoreSample.ShopUI.Models;

namespace StoreSample.ShopUI.Controlles
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private int pageSize = 4;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(string category="",int pageNumber = 1)
        {
            var viewModel = new ProductListViewModel
            {
                CurrentCategory = category,
                Data = productRepository.GetAll(pageNumber, pageSize, category)
            };
            return View(viewModel); 
        }
    }
}
