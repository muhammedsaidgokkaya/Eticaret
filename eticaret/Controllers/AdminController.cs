using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using eticaret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using EntityLayer.Enums;

namespace eticaret.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly ILogger<AdminController> _logger;

        IletisimManager iletisimManager = new IletisimManager(new EfIletisimRepository());
        FooterManager footerManager = new FooterManager(new EfFooterRepository());
        ReferanslarManager referanslarManager = new ReferanslarManager(new EfReferanslarRepository());
        HakkimizdaManager hakkimizdaManager = new HakkimizdaManager(new EfHakkimizdaRepository());
        AdminMesajManager adminmesajManager = new AdminMesajManager(new EfAdminMesajRepository());
        UserMesajManager usermesajManager = new UserMesajManager(new EfUserMesajRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        UrunManager urunManager = new UrunManager(new EfUrunRepository());

        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var usernamesurname = c.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userSayisi = c.Users.Count().ToString();
            var uyeidleri = c.Users.Select(y => y.Id).ToList();
            var adminsayisi = c.UserRoles.Where(x => x.RoleId == (int)UserRolTypeEnum.Admin).Count().ToString();
            var uyesayisi = c.UserRoles.Where(x => x.RoleId == (int)UserRolTypeEnum.Uye).Count().ToString();
            var telefon = c.Iletisims.FirstOrDefault();

            ViewBag.Phone = telefon.Phone;
            ViewBag.PhoneCagri = telefon.PhoneCagri;
            ViewBag.Eposta = telefon.Eposta;
            ViewBag.kullaniciAdi = username;
            ViewBag.adsoyad = usernamesurname;
            ViewBag.mail = usermail;
            ViewBag.adminsayisi = adminsayisi;
            ViewBag.uyesayisi = uyesayisi;
            return View();
        }

        public IActionResult MesajKutusu()
        {
            return View();
        }

        public IActionResult AdminMesajSil(int id)
        {
            var silinecek = adminmesajManager.TGetById(id);
            adminmesajManager.TDelete(silinecek);
            return RedirectToAction("MesajKutusu", "Admin");
        }
        
        public IActionResult UserMesajSil(int id)
        {
            var silinecek = usermesajManager.TGetById(id);
            usermesajManager.TDelete(silinecek);
            return RedirectToAction("MesajKutusu", "Admin");
        }

        public IActionResult Profilim()
        {
            return View();
        }

        //

        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            urunManager.TAdd(urun);
            return RedirectToAction("Urunlerim", "Admin");
        }

        public IActionResult UrunDuzenle(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunDuzenle(Urun urun)
        {
            urunManager.TUpdate(urun);
            return RedirectToAction("Urunlerim", "Admin");
        }

        public IActionResult UrunSil(int id)
        {
            var silinecek = urunManager.TGetById(id);
            urunManager.TDelete(silinecek);
            return RedirectToAction("Urunlerim", "Admin");
        }

        public IActionResult Urunlerim()
        {
            var urunlistesi = urunManager.GetList();
            return View(urunlistesi);
        }

        public IActionResult Siparisler()
        {
            return View();
        }

        public IActionResult Satislar()
        {
            return View();
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            categoryManager.TAdd(category);
            return View();
        }

        public IActionResult CategoryDuzenle(int id)
        {
            var duzenlenecek = categoryManager.TGetById(id);
            return View(duzenlenecek);
        }

        [HttpPost]
        public IActionResult CategoryDuzenle(Category category)
        {
            categoryManager.TUpdate(category);
            return RedirectToAction("CategoryAdd", "Admin");
        }

        public IActionResult CategorySil(int id)
        {
            var silinecek = categoryManager.TGetById(id);
            categoryManager.TDelete(silinecek);
            return RedirectToAction("CategoryAdd", "Admin");
        }

        //

        public IActionResult IletisimBilgileri()
        {
            Context c = new Context();
            var iletisim = c.Iletisims.FirstOrDefault();

            IletisimBilgileriDto dto = new IletisimBilgileriDto
            {
                Id = iletisim.Id,
                Adres = iletisim.Adres,
                Eposta = iletisim.Eposta,
                Facebook = iletisim.Facebook,
                Instagram = iletisim.Instagram,
                LinkedIn = iletisim.LinkedIn,
                Phone = iletisim.Phone,
                PhoneCagri = iletisim.PhoneCagri,
                Saatler = iletisim.Saatler,
                Twitter = iletisim.Twitter,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult IletisimBilgileri(IletisimBilgileriDto dto)
        {
            Context c = new Context();
            Iletisim iletisim = new Iletisim
            {
                Id = dto.Id,
                Adres = dto.Adres,
                Eposta = dto.Eposta,
                Facebook = dto.Facebook,
                Instagram = dto.Instagram,
                LinkedIn = dto.LinkedIn,
                Phone = dto.Phone,
                PhoneCagri = dto.PhoneCagri,
                Saatler = dto.Saatler,
                Twitter = dto.Twitter,
            };
            c.Iletisims.Update(iletisim);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult FooterDuzenle()
        {
            Context c = new Context();
            var footer = c.Footers.FirstOrDefault();

            FooterDto dto = new FooterDto
            {
                Id = footer.Id,
                Baslik = footer.Baslik,
                Description = footer.Description,
                KayitOlBaslik = footer.KayitOlBaslik,
                KayitOlDescription = footer.KayitOlDescription,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult FooterDuzenle(FooterDto dto)
        {
            Context c = new Context();
            Footer footer = new Footer
            {
                Id = dto.Id,
                Baslik = dto.Baslik,
                Description = dto.Description,
                KayitOlBaslik = dto.KayitOlBaslik,
                KayitOlDescription = dto.KayitOlDescription,
            };
            c.Footers.Update(footer);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult HakkimizdaDuzenle()
        {
            Context c = new Context();
            var hakimizda = c.Hakkimizdas.FirstOrDefault();

            HakkimizdaDto dto = new HakkimizdaDto
            {
                Id = hakimizda.Id,
                Baslik = hakimizda.Baslik,
                Description = hakimizda.Description,
                MisyonumuzBaslik = hakimizda.MisyonumuzBaslik,
                MisyonumuzDescription = hakimizda.MisyonumuzDescription,
                VizyonBaslik = hakimizda.VizyonBaslik,
                VizyonDescription = hakimizda.VizyonDescription,
                NedenBizBaslik = hakimizda.NedenBizBaslik,
                NedenBizDescription = hakimizda.NedenBizDescription,
                BizKimizBaslik = hakimizda.BizKimizBaslik,
                BizKimizDescription = hakimizda.BizKimizDescription,
                EkibimizBaslik = hakimizda.EkibimizBaslik,
                EkibimizDescription = hakimizda.EkibimizDescription,
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult HakkimizdaDuzenle(HakkimizdaDto dto)
        {
            Context c = new Context();
            Hakkimizda hakimizda = new Hakkimizda
            {
                Id = dto.Id,
                Baslik = dto.Baslik,
                Description = dto.Description,
                MisyonumuzBaslik = dto.MisyonumuzBaslik,
                MisyonumuzDescription = dto.MisyonumuzDescription,
                VizyonBaslik = dto.VizyonBaslik,
                VizyonDescription = dto.VizyonDescription,
                NedenBizBaslik = dto.NedenBizBaslik,
                NedenBizDescription = dto.NedenBizDescription,
                BizKimizBaslik = dto.BizKimizBaslik,
                BizKimizDescription = dto.BizKimizDescription,
                EkibimizBaslik = dto.EkibimizBaslik,
                EkibimizDescription = dto.EkibimizDescription,
            };
            c.Hakkimizdas.Update(hakimizda);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult ReferansEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReferansEkle(Referanslar referanslar)
        {
            if (ModelState.IsValid)
            {
                if (referanslar.Resim == null)
                {
                    referanslarManager.TAdd(referanslar);
                }
                else if (referanslar.Resim != null)
                {
                    string wwwRootPath = _webHost.WebRootPath;
                    string filename = Path.GetFileNameWithoutExtension(referanslar.Resim.FileName);
                    string extension = Path.GetExtension(referanslar.Resim.FileName);
                    referanslar.ResimYol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Resimler/ReferansResim/", filename);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await referanslar.Resim.CopyToAsync(filestream);
                    }
                    referanslarManager.TAdd(referanslar);
                }
            }
            return View();
        }

        public IActionResult ReferansDuzenle(int id)
        {
            var duzenlenecek = referanslarManager.TGetById(id);
            return View(duzenlenecek);
        }

        [HttpPost]
        public async Task<IActionResult> ReferansDuzenle(Referanslar referanslar)
        {
            if (ModelState.IsValid)
            {
                if (referanslar.Resim == null)
                {
                    referanslarManager.TAdd(referanslar);
                }
                else if (referanslar.Resim != null)
                {
                    string wwwRootPath = _webHost.WebRootPath;
                    string filename = Path.GetFileNameWithoutExtension(referanslar.Resim.FileName);
                    string extension = Path.GetExtension(referanslar.Resim.FileName);
                    referanslar.ResimYol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Resimler/ReferansResim/", filename);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await referanslar.Resim.CopyToAsync(filestream);
                    }
                    referanslarManager.TUpdate(referanslar);
                }
            }
            return RedirectToAction("ReferansEkle", "Admin");
        }

        public IActionResult ReferansSil(int id)
        {
            var silinecek = referanslarManager.TGetById(id);
            referanslarManager.TDelete(silinecek);
            return RedirectToAction("ReferansEkle", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
