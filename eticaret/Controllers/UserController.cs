using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using eticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret.Controllers
{
    [Authorize(Roles = "Uye")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        UserMesajManager usermesajManager = new UserMesajManager(new EfUserMesajRepository());

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
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

            ViewBag.kullaniciAdi = username;
            ViewBag.adsoyad = usernamesurname;
            ViewBag.mail = usermail;
            ViewBag.uyesayisi = uyesayisi;
            return View();
        }

        //

        public IActionResult MesajKutusu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MesajKutusu(UserMesaj userMesaj)
        {
            usermesajManager.TAdd(userMesaj);
            return RedirectToAction("MesajKutusu", "User");
        }

        public IActionResult Profilim()
        {
            return View();
        }

        //

        public IActionResult Sepetim()
        {
            return View();
        }

        public IActionResult Favoriler()
        {
            return View();
        }

        public IActionResult Siparislerim()
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
