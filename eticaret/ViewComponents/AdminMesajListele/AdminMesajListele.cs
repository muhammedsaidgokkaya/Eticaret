using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace eticaret.ViewComponents.AdminMesajListele
{
    public class AdminMesajListele : ViewComponent
    {
        AdminMesajManager adminmesajmanager = new AdminMesajManager(new EfAdminMesajRepository());
        public IViewComponentResult Invoke()
        {
            var adminmesajlistesi = adminmesajmanager.GetList();
            return View(adminmesajlistesi);
        }
    }
}