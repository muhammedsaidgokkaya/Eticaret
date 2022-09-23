using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using eticaret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        HakkimizdaManager hakkimizdamanager = new HakkimizdaManager(new EfHakkimizdaRepository());
        IletisimManager iletisimmanager = new IletisimManager(new EfIletisimRepository());
        ReferanslarManager referansmanager = new ReferanslarManager(new EfReferanslarRepository());
        AdminMesajManager adminmesajmanager = new AdminMesajManager(new EfAdminMesajRepository());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            Context c = new Context();
            var list = c.Hakkimizdas.FirstOrDefault();
            ViewBag.Baslik = list.Baslik.ToString();
            ViewBag.Description = list.Description.ToString();
            ViewBag.MisyonumuzBaslik = list.MisyonumuzBaslik.ToString();
            ViewBag.MisyonumuzDescription = list.MisyonumuzDescription.ToString();
            ViewBag.VizyonBaslik = list.VizyonBaslik.ToString();
            ViewBag.VizyonDescription = list.VizyonDescription.ToString();
            ViewBag.NedenBizBaslik = list.NedenBizBaslik.ToString();
            ViewBag.NedenBizDescription = list.NedenBizDescription.ToString();
            ViewBag.BizKimizBaslik = list.BizKimizBaslik.ToString();
            ViewBag.BizKimizDescription = list.BizKimizDescription.ToString();
            var hakkimizdalistesi = hakkimizdamanager.GetList();
            return View(hakkimizdalistesi);
        }

        public IActionResult Iletisim()
        {
            Context c = new Context();
            var list = c.Iletisims.FirstOrDefault();
            ViewBag.Adres = list.Adres.ToString();
            ViewBag.Eposta = list.Eposta.ToString();
            ViewBag.Phone = list.Phone.ToString();
            ViewBag.PhoneCagri = list.PhoneCagri.ToString();
            ViewBag.Saatler = list.Saatler.ToString();
            var iletisimlistesi = iletisimmanager.GetList();
            return View(iletisimlistesi);
        }

        public IActionResult Referanslar()
        {
            var referanslistesi = referansmanager.GetList();
            return View(referanslistesi);
        }

        public IActionResult ReferansDetay(int id)
        {
            var referans = referansmanager.TGetById(id);
            return View(referans);
        }

        public IActionResult DestekPortali()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DestekPortali(AdminMesaj adminMesaj)
        {
            adminmesajmanager.TAdd(adminMesaj);
            return RedirectToAction("DestekPortali", "Home");
        }

        public IActionResult Details()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
