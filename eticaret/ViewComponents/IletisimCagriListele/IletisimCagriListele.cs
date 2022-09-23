using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eticaret.ViewComponents.IletisimCagriListele
{
    public class IletisimCagriListele : ViewComponent
    {
        IletisimManager iletisimmanager = new IletisimManager(new EfIletisimRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Iletisims.ToList();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.PhoneCagri = list.PhoneCagri.ToString();
            return View(liste);
        }
    }
}