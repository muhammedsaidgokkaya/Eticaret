using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace eticaret.ViewComponents.CategoryListele
{
    public class CategoryListele : ViewComponent
    {
        CategoryManager categorymanager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var categorylistesi = categorymanager.GetList();
            return View(categorylistesi);
        }
    }
}