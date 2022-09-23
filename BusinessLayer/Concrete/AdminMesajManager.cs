using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminMesajManager : IAdminMesajService
    {
        IAdminMesajDal _adminmesajDal;

        public AdminMesajManager(IAdminMesajDal adminmesajDal)
        {
            _adminmesajDal = adminmesajDal;
        }

        public List<AdminMesaj> GetList()
        {
            return _adminmesajDal.GetListAll();
        }

        public void TAdd(AdminMesaj t)
        {
            _adminmesajDal.Insert(t);
        }

        public void TDelete(AdminMesaj t)
        {
            _adminmesajDal.Delete(t);
        }

        public AdminMesaj TGetById(int id)
        {
            return _adminmesajDal.GetById(id);
        }

        public void TUpdate(AdminMesaj t)
        {
            _adminmesajDal.Update(t);
        }
    }
}
