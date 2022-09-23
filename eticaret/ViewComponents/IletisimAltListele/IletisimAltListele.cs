using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eticaret.ViewComponents.IletisimAltListele
{
    public class IletisimAltListele : ViewComponent
    {
        IletisimManager iletisimmanager = new IletisimManager(new EfIletisimRepository());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var liste = c.Iletisims.ToList();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Adres = list.Adres.ToString();
            ViewBag.Eposta = list.Eposta.ToString();
            ViewBag.Facebook = list.Facebook.ToString();
            ViewBag.Instagram = list.Instagram.ToString();
            ViewBag.LinkedIn = list.LinkedIn.ToString();
            ViewBag.Phone = list.Phone.ToString();
            ViewBag.Saatler = list.Saatler.ToString();
            ViewBag.Twitter = list.Twitter.ToString();
            return View(liste);
        }
    }
}