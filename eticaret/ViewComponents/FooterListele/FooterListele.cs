using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eticaret.ViewComponents.FooterListele
{
    public class FooterListele : ViewComponent
    {
        FooterManager footermanager = new FooterManager(new EfFooterRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Footers.ToList();
            var list = c.Footers.FirstOrDefault();
            ViewBag.Baslik = list.Baslik.ToString();
            ViewBag.Description = list.Description.ToString();
            ViewBag.KayitOlBaslik = list.KayitOlBaslik.ToString();
            ViewBag.KayitOlDescription = list.KayitOlDescription.ToString();
            return View(liste);
        }
    }
}