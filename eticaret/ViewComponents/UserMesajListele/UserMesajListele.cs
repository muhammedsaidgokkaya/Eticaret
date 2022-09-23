using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using Microsoft.AspNetCore.Mvc;

namespace eticaret.ViewComponents.UserMesajListele
{
    public class UserMesajListele : ViewComponent
    {
        UserMesajManager usermesajmanager = new UserMesajManager(new EfUserMesajRepository());
        public IViewComponentResult Invoke()
        {
            var usermesajlistesi = usermesajmanager.GetList();
            return View(usermesajlistesi);
        }
    }
}