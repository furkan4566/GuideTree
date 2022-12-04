using Business.Abstarct;
using Microsoft.AspNetCore.Mvc;

namespace GuideTree.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent//Componentler controller a ihtiyaç duymadan model ile iletişime geçmeye yarar
    {
         private ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
           this._categoryService = categoryService;
        }

        public IViewComponentResult Invoke()//Invoke metodu Default.cshtml getirir//Veri tabanı işlemleri gerçekleştirebilir
        {
            if (RouteData.Values["category"]!=null)
                 ViewBag.SelectedCategory=RouteData?.Values["category"];

            return View(_categoryService.GetAll());
        }
    }
}
