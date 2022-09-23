using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace eticaret.ViewComponents.ReferansListele
{
    public class ReferansListele : ViewComponent
    {
        ReferanslarManager referanslarmanager = new ReferanslarManager(new EfReferanslarRepository());
        public IViewComponentResult Invoke()
        {
            var referanslistesi = referanslarmanager.GetList();
            return View(referanslistesi);
        }
    }
}