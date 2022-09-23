using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eticaret.ViewComponents.LogInFooterListele
{
    public class LogInFooterListele : ViewComponent
    {
        FooterManager footermanager = new FooterManager(new EfFooterRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Footers.ToList();
            var list = c.Footers.FirstOrDefault();
            ViewBag.KayitOlBaslik = list.KayitOlBaslik.ToString();
            ViewBag.KayitOlDescription = list.KayitOlDescription.ToString();
            return View(liste);
        }
    }
}