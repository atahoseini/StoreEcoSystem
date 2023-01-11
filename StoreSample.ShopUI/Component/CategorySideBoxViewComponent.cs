using Microsoft.AspNetCore.Mvc;

namespace StoreSample.ShopUI.Component
{
    public class CategorySideBoxViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
